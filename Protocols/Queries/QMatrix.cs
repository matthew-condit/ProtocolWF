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
            AND Submitters.SubmitterClass = 'Contact'";

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

        public static IList GetSponsorContacts(string sponsorName)
        {
            IList results = new ArrayList();
            sponsorName += "%";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(SelectSponsorContactsQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@SponsorName", SqlDbType.NVarChar).Value = sponsorName;

                        SqlDataReader reader = command.ExecuteReader();
                        while(reader.Read())
                        {
                            SponsorContact sponsor = CreateNewSponsor(reader);
                            results.Add(sponsor);
                        }
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetSponsorContacts", sqlEx);
            }
            return results;
        }

        public static IList GetSponsorContacts_NameAndCodeOnly(string sponsorName)
        {
            IList results = new ArrayList();
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
                            ListItem item = new ListItem();
                            item.ListName = ListNames.Contact;
                            item.ItemName = reader[3].ToString() + '-' + reader[1].ToString();
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
    }
}
