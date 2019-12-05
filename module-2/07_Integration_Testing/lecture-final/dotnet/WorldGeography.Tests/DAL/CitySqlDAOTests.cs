using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using WorldGeography.DAL;
using WorldGeography.Models;
using WorldGeography.Tests.DAL;

namespace WorldGeography.Tests
{
    [TestClass]
    public class CitySQLDALTests : WorldDAOTests
    {

        [DataTestMethod]
        [DataRow("USA", 1)]
        [DataRow("FRA", 0)]
        public void GetCitiesByCountryCode_Should_ReturnRightNumberOfCities(string countryCode, int expectedCityCount)
        {
            CitySqlDAO dao = new CitySqlDAO(ConnectionString);
            IList<City> cities = dao.GetCitiesByCountryCode(countryCode);
            Assert.AreEqual(expectedCityCount, cities.Count);
        }

        [TestMethod]
        public void AddCity_Should_IncreaseCountBy1()
        {
            // Arrange
            City city = new City();
            city.CountryCode = "USA";
            city.Name = "Doesn't matter";
            city.Population = 1;
            city.District = "Doesn't matter";
            CitySqlDAO dao = new CitySqlDAO(ConnectionString);
            int startingRowCount = GetRowCount("city");

            dao.AddCity(city);

            int endingRowCount = GetRowCount("city");
            Assert.AreNotEqual(startingRowCount, endingRowCount);
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void AddCity_Should_Fail_IfCountryDoesNotExist()
        {
            City city = new City()
            {
                CountryCode = "XYZ",
                Name = "Doesn't matter",
                Population = 1,
                District = "Doesn't matter"
            };
            CitySqlDAO dao = new CitySqlDAO(ConnectionString);

            dao.AddCity(city);
        }
    }
}
