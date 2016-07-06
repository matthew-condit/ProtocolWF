using Toxikon.ProtocolManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Models.Protocols;

namespace Toxikon.ProtocolManager.Queries
{
    public static class QMatrix
    {
        private static string CONNECTION_STRING = Utility.GetLIMSConnectionString();
        private const string ErrorFormName = "QMatrix";
        private const string SelectSponsorContactsQuery = @"
            SELECT Submitters.SubmitterText1 AS SponsorCode,
		           Submitters.SubmitterCode AS ContactCode,
	               Submitters.SubmitterName AS SponsorName,
	               ISNULL(Submitters.SubmitterText2, '') + ' ' +
	               ISNULL(Submitters.SubmitterText3, '') AS ContactName,
	               ISNULL(Submitters.SubmitterAddress1, '') + 
	               ISNULL(Submitters.SubmitterAddress2, '') AS PostalAddress,
	               Submitters.SubmitterAddress4 AS City,
	               Submitters.SubmitterAddress5 AS State,
	               Submitters.SubmitterPostCode,
	               Submitters.SubmitterAddress3 AS Country,
	               Submitters.SubmitterTelephone AS PhoneNumber,
	               Submitters.SubmitterFax AS Fax,
                   Submitters.SubmitterTelex AS Email
            FROM Submitters
            WHERE Submitters.SubmitterName LIKE @SponsorName
            AND Submitters.RecordStatus = 1
            AND Submitters.SubmitterClass = 'Contact'
        ";
        private const string SelectSponsorContactsByCodeQuery = @"
            SELECT Submitters.SubmitterText1 AS SponsorCode,
		           Submitters.SubmitterCode AS ContactCode,
	               Submitters.SubmitterName AS SponsorName,
	               ISNULL(Submitters.SubmitterText2, '') + ' ' +
	               ISNULL(Submitters.SubmitterText3, '') AS ContactName,
	               ISNULL(Submitters.SubmitterAddress1, '') + 
	               ISNULL(Submitters.SubmitterAddress2, '') AS PostalAddress,
	               Submitters.SubmitterAddress4 AS City,
	               Submitters.SubmitterAddress5 AS State,
	               Submitters.SubmitterPostCode,
	               Submitters.SubmitterAddress3 AS Country,
	               Submitters.SubmitterTelephone AS PhoneNumber,
	               Submitters.SubmitterFax AS Fax,
                   Submitters.SubmitterTelex AS Email
            FROM Submitters
            WHERE Submitters.SubmitterText1 LIKE @SponsorCode
            AND Submitters.RecordStatus = 1
            AND Submitters.SubmitterClass = 'Contact'
        ";

        private const string GetEmail = @"
            SELECT Submitters.SubmitterTelex As Email
            FROM Submitters 
            WHERE ISNULL(Submitters.SubmitterText2, '') + ' ' +
	               ISNULL(Submitters.SubmitterText3, '') = @ContactName
            AND Submitters.RecordStatus = 1
            AND Submitters.SubmitterClass = 'Contact'
        ";

        private const string GetAllSponsors = @"
            SELECT Submitters.SubmitterText1 AS SponsorCode,
		           Submitters.SubmitterCode AS ContactCode,
	               Submitters.SubmitterName AS SponsorName,
	               ISNULL(Submitters.SubmitterText2, '') + ' ' +
	               ISNULL(Submitters.SubmitterText3, '') AS ContactName,
	               ISNULL(Submitters.SubmitterAddress1, '') + 
	               ISNULL(Submitters.SubmitterAddress2, '') AS PostalAddress,
	               Submitters.SubmitterAddress4 AS City,
	               Submitters.SubmitterAddress5 AS State,
	               Submitters.SubmitterPostCode,
	               Submitters.SubmitterAddress3 AS Country,
	               Submitters.SubmitterTelephone AS PhoneNumber,
	               Submitters.SubmitterFax AS Fax,
                   Submitters.SubmitterTelex AS Email
            FROM Submitters
            WHERE Submitters.SubmitterName LIKE @SponsorName
            AND Submitters.RecordStatus = 1
            AND Submitters.SubmitterClass = 'Sponsor'";

        private const string ContactInfoByContactCode = @"
            SELECT Submitters.SubmitterText1 AS SponsorCode,
		           Submitters.SubmitterCode AS ContactCode,
	               Submitters.SubmitterName AS SponsorName,
	               ISNULL(Submitters.SubmitterText2, '') + ' ' +
	               ISNULL(Submitters.SubmitterText3, '') AS ContactName,
	               ISNULL(Submitters.SubmitterAddress1, '') + 
	               ISNULL(Submitters.SubmitterAddress2, '') AS PostalAddress,
	               Submitters.SubmitterAddress4 AS City,
	               Submitters.SubmitterAddress5 AS State,
	               Submitters.SubmitterPostCode,
	               Submitters.SubmitterAddress3 AS Country,
	               Submitters.SubmitterTelephone AS PhoneNumber,
	               Submitters.SubmitterFax AS Fax,
                   Submitters.SubmitterTelex AS Email
            FROM Submitters
            WHERE Submitters.SubmitterCode = @ContactCode
            AND Submitters.RecordStatus = 1
            AND Submitters.SubmitterClass = 'Contact'";

        private const string SelectSponsorNames = @"
            SELECT Submitters.SubmitterText1 AS SponsorCode,
	               Submitters.SubmitterName AS SponsorName
            FROM Submitters
            WHERE Submitters.SubmitterCode = @SponsorCode
            AND Submitters.RecordStatus = 1
            AND Submitters.SubmitterClass = 'Sponsor'";

        public static IList GetSponsorContacts(string sponsorName)
        {
            IList results = new ArrayList();
            sponsorName += "%";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(SelectSponsorContactsQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@SponsorName", SqlDbType.NVarChar).Value = sponsorName;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            SponsorContact sponsor = CreateNewSponsor(reader);
                            results.Add(sponsor);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetSponsorContacts", sqlEx);
            }

            return results;
        }

        //THIS IS MY NEW VERSION SINCE UGH
        public static IList GetSponsors(string sponsorName)
        {
            IList results = new ArrayList();
            sponsorName += "%";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(GetAllSponsors, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@SponsorName", SqlDbType.NVarChar).Value = sponsorName;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            SponsorContact sponsor = CreateNewSponsorNoContact(reader);
                            results.Add(sponsor);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetSponsorContacts", sqlEx);
            }

            return results;
        }

        public static string FindEmailByContact(string contactName)
        {
            try
            {
                string email = "";
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(GetEmail, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = contactName;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            email = reader[0].ToString();
                        }
                        
                    }
                }
                return email;
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetSponsorContacts_NameAndCodeOnly", sqlEx);
            }
            return "N/a";
        }

        public static IList GetSponsorContacts_NameAndCodeOnly(string sponsorName)
        {
            IList results = new ArrayList();
            sponsorName += "%";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(SelectSponsorContactsQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@SponsorName", SqlDbType.NVarChar).Value = sponsorName;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.Name = "Contact";
                            item.Value = reader[1].ToString();
                            item.Text = reader[3].ToString();
                            results.Add(item);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetSponsorContacts_NameAndCodeOnly", sqlEx);
            }
            return results;
        }

        //MINE
        public static IList GetSponsorContacts_NameAndCodeOnlyBySponsorCode(string sponsorCode)
        {
            IList results = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(SelectSponsorContactsByCodeQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@SponsorCode", SqlDbType.NVarChar).Value = sponsorCode;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.Name = "Contact";
                            item.Value = reader[1].ToString();
                            item.Text = reader[3].ToString();
                            results.Add(item);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetSponsorContacts_NameAndCodeOnly", sqlEx);
            }
            return results;
        }

        public static SponsorContact GetSponsorByContactCode(string contactCode)
        {
            SponsorContact result = new SponsorContact();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(ContactInfoByContactCode, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@ContactCode", SqlDbType.NVarChar).Value = contactCode;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            result = CreateNewSponsor(reader);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetSponsorByContactCode", sqlEx);
            }
            return result;
        }

        public static void GetSponsorNames(IList sponsors)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(SelectSponsorNames, connection))
                    {
                        command.CommandType = CommandType.Text;
                        foreach (Item item in sponsors)
                        {
                            command.Parameters.Clear();
                            command.Parameters.Add("@SponsorCode", SqlDbType.NVarChar).Value = item.Name;
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                item.Text = reader[1].ToString().Trim();
                            }
                            reader.Close();
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetSponsorNames", sqlEx);
            }
        }

        private static SponsorContact CreateNewSponsor(SqlDataReader reader)
        {
            SponsorContact sponsor = new SponsorContact();
            sponsor.SponsorCode = reader[0].ToString().Trim();
            sponsor.ContactCode = reader[1].ToString().Trim();
            sponsor.SponsorName = reader[2].ToString().Trim();
            sponsor.ContactName = reader[3].ToString().Trim();
            sponsor.Address = reader[4].ToString().Trim();
            sponsor.City = reader[5].ToString().Trim();
            sponsor.State = reader[6].ToString().Trim();
            sponsor.ZipCode = reader[7].ToString().Trim();
            sponsor.PhoneNumber = reader[9].ToString().Trim();
            sponsor.FaxNumber = reader[10].ToString().Trim();
            sponsor.Email = reader[11].ToString().Trim();
            return sponsor;
        }
        private static SponsorContact CreateNewSponsorNoContact(SqlDataReader reader)
        {
            SponsorContact sponsor = new SponsorContact();
            sponsor.ContactCode = "0";
            sponsor.SponsorCode = reader[0].ToString().Trim();
            sponsor.SponsorName = reader[2].ToString().Trim();
            sponsor.Address = reader[4].ToString().Trim();
            sponsor.City = reader[5].ToString().Trim();
            sponsor.State = reader[6].ToString().Trim();
            sponsor.ZipCode = reader[7].ToString().Trim();
            sponsor.PhoneNumber = reader[9].ToString().Trim();
            sponsor.FaxNumber = reader[10].ToString().Trim();
            return sponsor;
        }
    }
}
