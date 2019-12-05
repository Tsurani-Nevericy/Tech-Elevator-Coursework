using ParkGeek.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ParkGeek
{
    public interface IParkGeekDAO
    {
        Park GetPark(string code);
        IList<Park> GetParks();
        Park GetParkFromReader(SqlDataReader reader);
        int NewSurvey(Survey vm);
        IList<SurveyData> GetSurveyParks();
    }
}
