using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.DAL;

namespace WorldGeography
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use this as is, it will allow you access to the data in appsettings.json file
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            // Replace world with the key name used for your connection string in the appsettings.json file
            string connectionString = configuration.GetConnectionString("World");
            
            ICityDAO cityDAO = new CitySqlDAO(connectionString);
            ICountryDAO countryDAO = null;
            ILanguageDAO languageDAO = new LanguageSqlDAO(connectionString);

            WorldGeographyCLI cli = new WorldGeographyCLI(cityDAO, countryDAO, languageDAO);
            cli.RunCLI();
        }
    }
}
