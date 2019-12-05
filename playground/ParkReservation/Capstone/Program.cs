using Microsoft.Extensions.Configuration;
using ParkReservation;
using Security.BusinessLogic;
using Security.DAO;
using System;
using System.IO;

namespace Capstone
{
    /// <summary>
    /// Starting class for the park reservation cli application
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point for the park reservation cli
        /// </summary>
        /// <param name="args">Command line arguments which are currently ignored</param>
        static void Main(string[] args)
        {
            CLIHelper.EnableDebugInfo = true;

            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();

                string connectionString = configuration.GetConnectionString("npcampground");

                IParkDAO parkDb = new ParkDAO(connectionString);
                IUserSecurityDAO userSecurityDb = new UserSecurityDAO(connectionString);
                UserManager userMgr = new UserManager(userSecurityDb);

                ParkReservationCLI cli = new ParkReservationCLI(userMgr, parkDb);
                cli.StartMenu();
            }
            catch(Exception e)
            {
                CLIHelper.DisplayDebugInfo(e);
            }
        }
    }
}
