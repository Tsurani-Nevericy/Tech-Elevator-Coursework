using ParkGeek.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ParkGeek.DAL
{
    public class ParkGeekDAO : IParkGeekDAO
    {
        private readonly string _connectionString;
        public ParkGeekDAO(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public Park GetPark(string code)
        {
            Park result = new Park();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM park WHERE parkCode = @code;", conn);
                cmd.Parameters.AddWithValue("@code", code);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = GetParkFromReader(reader);
                }

                return result;

            }
        }

        public IList<Park> GetParks()
        {
            var result = new List<Park>();

            const string sql = "SELECT * FROM park";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Park product = GetParkFromReader(reader);
                    result.Add(product);
                }

            }
            return result;
        }

        public Park GetParkFromReader(SqlDataReader reader)
        {
            Park result = new Park();

            result.ParkCode = Convert.ToString(reader["parkCode"]);
            result.ParkName = Convert.ToString(reader["parkName"]);
            result.State = Convert.ToString(reader["state"]);
            result.Acreage = Convert.ToInt32(reader["acreage"]);
            result.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
            result.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
            result.NumberOfSites = Convert.ToInt32(reader["numberOfCampsites"]);
            result.Climate = Convert.ToString(reader["climate"]);
            result.YearFounded = Convert.ToInt32(reader["yearFounded"]);
            result.AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]);
            result.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
            result.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
            result.ParkDescription = Convert.ToString(reader["parkDescription"]);
            result.EntryFee = Convert.ToInt32(reader["entryFee"]);
            result.NumAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

            return result;
        }

        public int NewSurvey(Survey survey)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into survey_result (parkCode, emailAddress, state, activityLevel) " +
                    "values (@code, @email, @state, @activity); SELECT CAST(SCOPE_IDENTITY() as int) ", conn);
                cmd.Parameters.AddWithValue("@code", survey.FavoriteParkCode);
                cmd.Parameters.AddWithValue("@email", survey.Email);
                cmd.Parameters.AddWithValue("@state", survey.StateOfResidence);
                cmd.Parameters.AddWithValue("@activity", survey.ActivityLevel);
                result = (int)cmd.ExecuteScalar();
            }
            return result;
        }

        public IList<SurveyData> GetSurveyParks()
        {
            var result = new List<SurveyData>();

            const string sql = "select parkCode, COUNT(*) as numVotes from survey_result group by parkCode order by numVotes desc, parkCode";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SurveyData sd = new SurveyData();
                    sd.ParkCode = Convert.ToString(reader["parkCode"]);
                    sd.NumVotes = Convert.ToInt32(reader["numVotes"]);
                    result.Add(sd);
                }
            }
            return result;
        }
    }
}
