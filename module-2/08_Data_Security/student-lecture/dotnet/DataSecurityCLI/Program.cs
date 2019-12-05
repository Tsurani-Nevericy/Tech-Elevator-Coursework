using Microsoft.Extensions.Configuration;
using Security.BusinessLogic;
using Security.DAO;
using Security.Exceptions;
using Security.Models;
using System;
using System.IO;

namespace DataSecurityCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("UserSecurity");

            UserSecurityDAO dao = new UserSecurityDAO(connectionString);
            UserManager mgr = new UserManager(dao);

            // RegisterUser();

            Console.WriteLine($"Is Authenticate: {mgr.IsAuthenticated}");
            if (!mgr.IsAuthenticated)
            {
                Login(mgr);
            }

            Console.WriteLine($"Is Authenticate: {mgr.IsAuthenticated}");
            if (mgr.IsAuthenticated)
            {
                mgr.LogoutUser();
            }
            Console.WriteLine($"Is Authenticate: {mgr.IsAuthenticated}");
            Console.ReadKey();
        }

        public static void Login(UserManager mgr)
        {
            try
            {
                mgr.LoginUser("bg", "a");
                Console.WriteLine("Login successful");
            }
            catch(UserDoesNotExistException)
            {
                Console.WriteLine("User does not exist.");
            }
            catch (PasswordMatchException)
            {
                Console.WriteLine("Password does not match");
            }

            Console.ReadKey();
        }

        public static void RegisterUser(UserManager mgr)
        {
            User user = new User();
            user.FirstName = "Bill";
            user.LastName = "Gray";
            user.Email = "bill@yahoo.com";
            user.Password = "a";
            user.ConfirmPassword = "a";
            user.Username = "bg";
            mgr.RegisterUser(user);
        }
    }
}
