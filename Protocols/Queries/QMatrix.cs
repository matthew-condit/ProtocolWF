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
        private const string SponsorInfoQuery = @"
            SELECT Submitters.SubmitterCode,
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
	               Submitters.SubmitterClass,
                   Submitters.SubmitterTelex AS Email
            FROM Submitters
            WHERE Submitters.SubmitterName LIKE @SponsorName
            AND Submitters.RecordStatus = 1";

        private const string SponsorInfoBySponsorCode = @"
            SELECT Submitters.SubmitterCode,
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
	               Submitters.SubmitterClass,
                   Submitters.SubmitterTelex AS Email
            FROM Submitters
            WHERE Submitters.SubmitterCode = @SponsorCode
            AND Submitters.RecordStatus = 1";

        public static IList GetSponsorInfo(string sponsorName)
        {
            IList results = new ArrayList();
            sponsorName += "%";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(SponsorInfoQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@SponsorName", SqlDbType.NVarChar).Value = sponsorName;

                        SqlDataReader reader = command.ExecuteReader();
                        while(reader.Read())
                        {
                            Sponsor sponsor = CreateNewSponsor(reader);
                            results.Add(sponsor);
                        }
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                Debug.WriteLine(sqlEx.ToString());
            }
            return results;
        }

        public static Sponsor GetSponsorBySponsorCode(string sponsorCode)
        {
            Sponsor result = new Sponsor();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(SponsorInfoBySponsorCode, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@SponsorCode", SqlDbType.NVarChar).Value = sponsorCode;

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
                Debug.WriteLine(sqlEx.ToString());
            }
            return result;
        }

        private static Sponsor CreateNewSponsor(SqlDataReader reader)
        {
            Sponsor sponsor = new Sponsor();
            sponsor.SponsorCode = reader[0].ToString().Trim();
            sponsor.SponsorName = reader[1].ToString().Trim();
            sponsor.SponsorContact = reader[2].ToString().Trim();
            sponsor.Address = reader[3].ToString().Trim();
            sponsor.City = reader[4].ToString().Trim();
            sponsor.State = reader[5].ToString().Trim();
            sponsor.ZipCode = reader[6].ToString().Trim();
            sponsor.PhoneNumber = reader[8].ToString().Trim();
            sponsor.FaxNumber = reader[9].ToString().Trim();
            sponsor.Email = reader[11].ToString().Trim();
            return sponsor;
        }
    }
}
