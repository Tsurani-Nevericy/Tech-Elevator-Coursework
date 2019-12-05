using Capstone.Exceptions;
using ParkReservation;
using ParkReservation.Models;
using ParkReservation.Models.Database;
using Security.BusinessLogic;
using Security.Models;
using Security.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    /// <summary>
    /// The main console class for the park reservation system
    /// </summary>
    public class ParkReservationCLI
    {
        /// <summary>
        /// Used to get the month names given the month numeric value
        /// </summary>
        private Dictionary<int, string> _monthNames = new Dictionary<int, string>
        {
            {1, "January" },
            {2, "February" },
            {3, "March" },
            {4, "April" },
            {5, "May" },
            {6, "June" },
            {7, "July" },
            {8, "August" },
            {9, "September" },
            {10, "October" },
            {11, "November" },
            {12, "December" }
        };
        
        // These represent the user menu selection options
        private const string Option_Login = "1";
        private const string Option_Register = "2";
        private const string Option_Logout = "l";
        private const string Option_Quit = "q";
        private const string Option_Return = "b";
        private const string Option_ReservationHistory = "r";
        private const string Option_ParkSearchReservation = "2";
        private const string Option_CampgroundSearchReservation = "1";
        private const string Option_ViewCampgrounds = "1";
        private const string Option_ViewUpcomingReservations = "3";

        // These are user messages that are used more than once
        private const string Message_InvalidSelection = "Invalid selection, please try again.";
        private const string Message_PressKeyContinue = "Press any key to continue...";
        private const string Message_EnterSelection = "Please enter selection...";
        private const string Message_SelectCommand = "Select a Command";
        private const string Message_ReEnterDepartureDate = "Do you want to re-enter the departure date(Y/N)?";
        private const string Message_ReEnterArrivalDate = "Do you want to re-enter the arrival date(Y/N)?";

        /// <summary>
        /// The user manager object used for user registration, login, and authorization
        /// </summary>
        private UserManager _userMgr = null;

        /// <summary>
        /// The dao used for all park related db access
        /// </summary>
        private IParkDAO _db = null;

        /// <summary>
        /// Constructor for the ParkReservationCLI
        /// </summary>
        /// <param name="userManager">Used for user registration, login, and authorization</param>
        /// <param name="db">Used for all park related db access</param>
        public ParkReservationCLI(UserManager userManager, IParkDAO db)
        {
            _userMgr = userManager;
            _db = db;
        }
        
        /// <summary>
        /// The starting point for the menu system
        /// </summary>
        public void StartMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                DisplayColored(Message_SelectCommand);
                Console.WriteLine(" (1) Login");
                Console.WriteLine(" (2) Register");
                Console.WriteLine(" (Q) Quit");
                Console.WriteLine();

                string choice = CLIHelper.GetString(Message_EnterSelection);
                                               
                if (choice == Option_Login)
                {
                    DisplayLogin();
                }
                else if (choice == Option_Register)
                {
                    DisplayRegister();
                }
                else if (choice == Option_Quit)
                {
                    exit = true;
                }
                else
                {
                    DisplayInvalidSelection();
                }
            }
        }

        /// <summary>
        /// Login Menu
        /// </summary>
        private void DisplayLogin()
        {
            Console.Clear();
            string username = CLIHelper.GetString("Enter username:");
            string password = CLIHelper.GetString("Enter password:");
            try
            {
                _userMgr.LoginUser(username, password);
                DisplayWelcome();
                DisplayParkMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Registration Menu
        /// </summary>
        private void DisplayRegister()
        {
            Console.Clear();

            User user = new User();
            user.Username = CLIHelper.GetString("Enter username: ");
            user.Password = CLIHelper.GetString("Enter password: ");
            user.ConfirmPassword = CLIHelper.GetString("Enter password again: ");
            user.Email = CLIHelper.GetString("Enter email: ");
            user.FirstName = CLIHelper.GetString("Enter first name: ");
            user.LastName = CLIHelper.GetString("Enter last name: ");

            try
            {
                _userMgr.RegisterUser(user);
                DisplayWelcome();
                DisplayParkMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Welcome screen
        /// </summary>
        private void DisplayWelcome()
        {
            Console.Clear();
            DisplayColored($"Welcome {_userMgr.User.FirstName} {_userMgr.User.LastName} to the park reservation service.");
            Console.WriteLine();
            Console.WriteLine(Message_PressKeyContinue);
            Console.ReadKey();
        }

        /// <summary>
        /// Park selection menu
        /// </summary>
        private void DisplayParkMenu()
        {
            var parks = _db.GetParks();
            Dictionary<int, ParkItem> menu = new Dictionary<int, ParkItem>();

            bool exit = false;
            while (!exit)
            {
                menu.Clear();
                Console.Clear();
                DisplayColored("Select a park for further details...");

                for (int i = 1; i <= parks.Count; i++)
                {
                    menu.Add(i, parks[i - 1]);
                    Console.WriteLine($" ({i}) {parks[i - 1].Name}");
                }
                Console.WriteLine(" (R) Reservation History");
                Console.WriteLine(" (L) Logout");
                Console.WriteLine();

                var selection = CLIHelper.GetString(Message_EnterSelection);
                
                if(selection.ToLower() == Option_Logout)
                {
                    _userMgr.LogoutUser();
                    exit = true;
                }
                else if(selection.ToLower() == Option_ReservationHistory)
                {
                    var reservations = _db.GetReservationsForUserId(_userMgr.User.Id);
                    DisplayReservationHistory(reservations);
                }
                else
                {
                    try
                    {
                        var parkSel = int.Parse(selection);
                        if(menu.ContainsKey(parkSel))
                        {
                            DisplayParkDetailsMenu(menu[parkSel]);
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch(ExitToMainException)
                    {
                        // do nothing, this is the main menu
                    }
                    catch(Exception e)
                    {
                        CLIHelper.DisplayDebugInfo(e);
                        DisplayInvalidSelection();
                    }
                }
                
            }
        }

        /// <summary>
        /// Writes the reservation history to the console
        /// </summary>
        /// <param name="reservations">List of reservation history objects</param>
        /// <param name="isForUser">Specifies if this is the history of a specific user</param>
        private void DisplayReservationHistory(List<ReservationHistory> reservations, bool isForUser = true)
        {
            const int col1Pad = 14;
            int col2Pad = GetReservationNamePadding(reservations);
            col2Pad = col2Pad > 18 ? col2Pad : 18;
            const int col3Pad = 14;
            const int col4Pad = 14;
            const int col5Pad = 16;

            Console.Clear();
            if (isForUser)
            {
                DisplayColored($"Reservation History for {_userMgr.User.FirstName} {_userMgr.User.LastName}");
            }
            else
            {
                DisplayColored($"Upcoming Reservations for the Next 30 Days");
            }
            Console.WriteLine();
            DisplayColored($"{"Confirmation".PadRight(col1Pad)}" +
                           $"{"Reservation Name".PadRight(col2Pad)}" +
                           $"{"Created Date".PadRight(col3Pad)}" +
                           $"{"Arrival Date".PadRight(col4Pad)}" +
                           $"{"Departure Date".PadRight(col5Pad)}" +
                           $"{"Campground"}");
            foreach (var reservationHistory in reservations)
            {
                var reservation = reservationHistory.Reservation;
                Console.WriteLine($"{reservation.Id.ToString().PadRight(col1Pad)}" +
                                  $"{reservation.Name.PadRight(col2Pad)}" +
                                  $"{reservation.CreatedDate.ToShortDateString().PadRight(col3Pad)}" +
                                  $"{reservation.FromDate.ToShortDateString().PadRight(col4Pad)}" +
                                  $"{reservation.ToDate.ToShortDateString().PadRight(col5Pad)}" +
                                  $"{reservationHistory.CampgroundName}");
            }
            Console.WriteLine();
            Console.WriteLine(Message_PressKeyContinue);
            Console.ReadKey();
        }
        
        /// <summary>
        /// Park details menu
        /// </summary>
        /// <param name="park">The park item to be displayed</param>
        private void DisplayParkDetailsMenu(ParkItem park)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                DisplayColored("Park Information Screen");
                Console.WriteLine($"{park.Name} National Park");
                Console.WriteLine($"Location:".PadRight(18) + $"{park.Location}");
                Console.WriteLine($"Established:".PadRight(18) + $"{park.EstablishedDate.ToShortDateString()}");
                Console.WriteLine($"Area:".PadRight(18) + $"{park.Area.ToString("N0")} sq km");
                Console.WriteLine($"Annual Visitors:".PadRight(18) + $"{park.Visitors.ToString("N0")}");
                Console.WriteLine();
                Console.WriteLine(park.Description);
                Console.WriteLine();
                DisplayColored(Message_SelectCommand);
                Console.WriteLine(" (1) View Campgrounds");
                Console.WriteLine(" (2) Search for Reservation");
                Console.WriteLine(" (3) View Upcoming Reservations");
                Console.WriteLine(" (B) Return to Previous Screen");
                Console.WriteLine();

                var selection = CLIHelper.GetString(Message_EnterSelection);
                if(selection == Option_Return)
                {
                    exit = true;
                }
                else if(selection == Option_ParkSearchReservation)
                {
                    DisplayParkWideReservation(park);
                }
                else if(selection == Option_ViewCampgrounds)
                {
                    DisplayCampgroundMenu(park);
                }
                else if(selection == Option_ViewUpcomingReservations)
                {
                    var reservations = _db.GetReservationsForNext30Days(park.Id);
                    DisplayReservationHistory(reservations, false);
                }
                else
                {
                    DisplayInvalidSelection();
                }
            }
        }
        
        /// <summary>
        /// Manages the reservation workflow for the entire park
        /// </summary>
        /// <param name="park">The park information the reservtion is for</param>
        private void DisplayParkWideReservation(ParkItem park)
        {
            ReservationInfo reservationInfo = new ReservationInfo();
            List<SiteInfo> siteInfos = new List<SiteInfo>();
            try
            {
                reservationInfo = GetReservationInfo(reservationInfo);
                var campgrounds = _db.GetCampgrounds(park.Id);
                foreach(var campground in campgrounds)
                {
                    reservationInfo.CampgroundId = campground.Id;
                    var sites = _db.GetSites(reservationInfo);
                    foreach (var site in sites)
                    {
                        siteInfos.Add(site.CreateSiteInfo(campground.DailyFee, campground.Name));
                    }
                }

                ReservationItem item = new ReservationItem();
                item.SiteId = GetSiteSelection(siteInfos, reservationInfo, "", true);
                DisplayCompleteReservation(reservationInfo, item);
                throw new ExitToMainException();
            }
            catch(ExitException)
            {
                // do nothing, the user cancelled the reservation process
            }
        }

        /// <summary>
        /// Campground menu
        /// </summary>
        /// <param name="park">The park that contains the campgrounds to be displayed</param>
        private void DisplayCampgroundMenu(ParkItem park)
        {
            var campgrounds = _db.GetCampgrounds(park.Id);

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                DisplayColored("Park Campgrounds");
                Console.WriteLine($"{park.Name} National Park Campgrounds");
                Console.WriteLine();
                DisplayCampgrounds(campgrounds);
                Console.WriteLine();
                DisplayColored(Message_SelectCommand);
                Console.WriteLine(" (1) Search for Reservation");
                Console.WriteLine(" (B) Return to Previous Screen");
                Console.WriteLine();

                var selection = CLIHelper.GetString(Message_EnterSelection);

                if (selection.ToLower() == Option_Return)
                {
                    exit = true;
                }
                else if(selection == Option_CampgroundSearchReservation)
                {
                    DisplaySearchMenu(park, campgrounds);
                }
                else
                {
                    DisplayInvalidSelection();
                }
            }
        }

        /// <summary>
        /// Writes the campground data to the screen
        /// </summary>
        /// <param name="campgrounds">The campgrounds that will be written to the screen</param>
        /// <param name="menu">Holds the campground items for a given user selection</param>
        private void DisplayCampgrounds(List<CampgroundItem> campgrounds, Dictionary<int, CampgroundItem> menu = null)
        {
            const int col1Pad = 5;
            int col2Pad = GetCampgroundNamePadding(campgrounds);
            const int col3Pad = 11;
            const int col4Pad = 11;

            DisplayColored($"".PadRight(col1Pad) +
                              $"{"Name".PadRight(col2Pad)}" +
                              $"{"Open".PadRight(col3Pad)}" +
                              $"{"Close".PadRight(col4Pad)}" +
                              $"{"Daily Fee"}");

            for (int i = 1; i <= campgrounds.Count; i++)
            {
                var campground = campgrounds[i - 1];
                if (menu != null)
                {
                    menu.Add(i, campground);
                }
                Console.WriteLine($"{$" #{i}".ToString().PadRight(col1Pad)}" +
                                  $"{campground.Name.PadRight(col2Pad)}" +
                                  $"{_monthNames[campground.OpenFromMonth].PadRight(col3Pad)}" +
                                  $"{_monthNames[campground.OpenToMonth].PadRight(col4Pad)}" +
                                  $"{campground.DailyFee.ToString("C")}");
            }
        }


        /// <summary>
        /// Displays a list of campgrounds and prompts user to select one of them
        /// </summary>
        /// <param name="park">The park the campgrounds belong to</param>
        /// <param name="campgrounds">List of campgrounds</param>
        private void DisplaySearchMenu(ParkItem park, List<CampgroundItem> campgrounds)
        {
            Dictionary<int, CampgroundItem> menu = new Dictionary<int, CampgroundItem>();
            decimal selectedDailyFee = 0.0M;
            string campgroundName = "";

            bool exit = false;
            while (!exit)
            {
                ReservationInfo reservation = new ReservationInfo();

                bool validSelection = false;
                while (!validSelection)
                {
                    menu.Clear();
                    Console.Clear();
                    DisplayColored("Search for Campground Reservation");
                    Console.WriteLine();
                    DisplayCampgrounds(campgrounds, menu);
                    Console.WriteLine();

                    var selection = CLIHelper.GetInteger("Which campground (enter 0 to cancel)?");
                    if (selection == 0)
                    {
                        exit = true;
                        validSelection = true;
                    }
                    else if (menu.ContainsKey(selection))
                    {
                        reservation.CampgroundId = menu[selection].Id;
                        selectedDailyFee = menu[selection].DailyFee;
                        campgroundName = menu[selection].Name;
                        validSelection = true;
                    }
                    else
                    {
                        DisplayInvalidSelection();
                    }
                }

                if (!exit)
                {
                    try
                    {
                        reservation = GetReservationInfo(reservation);
                    }
                    catch (ExitException)
                    {
                        exit = true;
                    }

                    try
                    {
                        DisplayCampsiteSelection(reservation, selectedDailyFee, campgroundName);
                        throw new ExitToMainException();
                    }
                    catch (NoAvailableCampsitesException)
                    {
                        Console.WriteLine();
                        Console.WriteLine("There are no campsites available that match your search criteria.");
                        Console.WriteLine(Message_PressKeyContinue);
                        Console.ReadKey();
                    }
                    catch (ExitException)
                    {
                        exit = true;
                    }
                    catch (ExitToMainException)
                    {
                        throw;
                    }
                    catch (Exception e)
                    {
                        CLIHelper.DisplayDebugInfo(e);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the reservation info from the user
        /// </summary>
        /// <param name="reservation">This is the object to add reservation info to. It already has campsite id populated.</param>
        /// <returns>The passed in reservation info with extra fields populated</returns>
        private ReservationInfo GetReservationInfo(ReservationInfo reservation)
        {
            bool validSelection = false;
            while (!validSelection)
            {
                reservation.FromDate = CLIHelper.GetDateTime("What is the arrival date  (mm/dd/yyyy)?");
                if (reservation.FromDate < DateTime.Now)
                {
                    Console.WriteLine("The arrival date cannot be earlier than today.");
                    var isTryAgain = CLIHelper.GetString(Message_ReEnterArrivalDate);
                    if (isTryAgain.ToLower() == "n")
                    {
                        throw new ExitException();
                    }
                }
                else
                {
                    validSelection = true;
                }
            }

            validSelection = false;
            while (!validSelection)
            {
                reservation.ToDate = CLIHelper.GetDateTime("What is the departure date (mm/dd/yyyy)?");
                if (reservation.ToDate < reservation.FromDate)
                {
                    Console.WriteLine("The departure date cannot be earlier than the arrival date.");
                    var isTryAgain = CLIHelper.GetString(Message_ReEnterDepartureDate);
                    if (isTryAgain.ToLower() == "n")
                    {
                        throw new ExitException();
                    }
                }
                else if((reservation.ToDate - reservation.FromDate).Days <= 0)
                {
                    Console.WriteLine("The reservation length must be at least 1 day or more.");
                    var isTryAgain = CLIHelper.GetString(Message_ReEnterDepartureDate);
                    if (isTryAgain.ToLower() == "n")
                    {
                        throw new ExitException();
                    }
                }
                else
                {
                    validSelection = true;
                }
            }
                        
            reservation.Occupancy = CLIHelper.GetInteger("What are your occupancy requirements (1-55)?", 1, 55);
            reservation.IsAccessible = CLIHelper.GetBool("Do you need handicap accessiblity (true/false)?");
            reservation.HasUtilities = CLIHelper.GetBool("Do you need utilities (true/false)?");
            reservation.RvLength = CLIHelper.GetInteger("What is your minimum RV length requirements (0-35)?", 0, 35);

            return reservation;
        }

        /// <summary>
        /// Prompts user to select a campsite then displays the completed reservation info
        /// </summary>
        /// <param name="reservation">Information about the reservation filters</param>
        /// <param name="dailyFee">The daily fee for the campground for the sites being reserved</param>
        /// <param name="campgroundName">The name of the campground the sites belong to</param>
        private void DisplayCampsiteSelection(ReservationInfo reservation, decimal dailyFee, string campgroundName)
        {
            var sites = _db.GetSites(reservation);
            if (sites.Count > 0)
            {
                var siteInfos = new List<SiteInfo>();
                foreach (var site in sites)
                {
                    siteInfos.Add(site.CreateSiteInfo(dailyFee, campgroundName));
                }
                Dictionary<string, SiteInfo> menu = new Dictionary<string, SiteInfo>();

                ReservationItem item = new ReservationItem();
                item.SiteId = GetSiteSelection(siteInfos, reservation, campgroundName);
                DisplayCompleteReservation(reservation, item);
            }
            else
            {
                throw new NoAvailableCampsitesException();
            }
        }

        /// <summary>
        /// Prompts user to select a campsite
        /// </summary>
        /// <param name="siteInfos">Details about each campsite</param>
        /// <param name="reservation">Information about the reservation filters</param>
        /// <param name="campgroundName">The name of the campground the sites belong to</param>
        /// <param name="isParkWide">Specifies if this is a park wide search or just a campground search</param>
        /// <returns></returns>
        private int GetSiteSelection(List<SiteInfo> siteInfos, ReservationInfo reservation, string campgroundName, bool isParkWide = false)
        {
            int campsiteId = BaseItem.InvalidId;
            bool validSelection = false;
            while (!validSelection)
            {
                Console.Clear();
                DisplayColored("Results Matching Your Search Criteria");
                Console.WriteLine();
                Dictionary<string, SiteInfo> menu = new Dictionary<string, SiteInfo>();
                DisplayCampsites(siteInfos, menu, reservation, isParkWide);
                Console.WriteLine();

                if (isParkWide)
                {
                    campgroundName = CLIHelper.GetString("Which campground should be reserved?");
                }

                var selection = CLIHelper.GetInteger("Which site should be reserved (enter 0 to cancel)?");
                if (selection == 0)
                {
                    throw new ExitException();
                }
                else if (menu.ContainsKey($"{campgroundName}{selection}"))
                {
                    campsiteId = menu[$"{campgroundName}{selection}"].Site.Id;
                    validSelection = true;
                }
                else
                {
                    DisplayInvalidSelection();
                }
            }

            return campsiteId;
        }
        
        /// <summary>
        /// Displays the reservation info to the user
        /// </summary>
        /// <param name="reservation">The reservation info used to filter the campsite selection options</param>
        /// <param name="item">The reservation details</param>
        private void DisplayCompleteReservation(ReservationInfo reservation, ReservationItem item)
        {
            item.Name = CLIHelper.GetString("What name should the reservation be made under?");

            item.FromDate = reservation.FromDate;
            item.ToDate = reservation.ToDate;
            item.CreatedDate = DateTime.UtcNow;

            var confirmationId = _db.MakeReservation(item, _userMgr.User.Id);
            Console.WriteLine();
            Console.WriteLine($"The reservation has been made and the confirmation id is {confirmationId}");
            Console.WriteLine(Message_PressKeyContinue);
            Console.ReadKey();
        }

        /// <summary>
        /// Displays campsite information
        /// </summary>
        /// <param name="siteInfos">List of campsites to display to the user</param>
        /// <param name="menu">Dictionary that will be populated with the campsite menu data</param>
        /// <param name="reservation">Reservation filters used in determining available campsites</param>
        /// <param name="isParkWide">Specifies if this is a park wide search or just a campground search</param>
        private void DisplayCampsites(List<SiteInfo> siteInfos, Dictionary<string, SiteInfo> menu, ReservationInfo reservation, bool isParkWide = false)
        {
            int col1Pad = GetSiteNamePadding(siteInfos);
            const int col2Pad = 10;
            const int col3Pad = 12;
            const int col4Pad = 13;
            const int col5Pad = 15;
            const int col6Pad = 9;

            string header = $"{"Site No.".PadRight(col2Pad)}" +
                            $"{"Max Occup.".PadRight(col3Pad)}" +
                            $"{"Accessible?".PadRight(col4Pad)}" +
                            $"{"Max RV Length".PadRight(col5Pad)}" +
                            $"{"Utility".PadRight(col6Pad)}" +
                            $"{"Cost"}";

            if (isParkWide)
            {
                header = $"Campground".PadRight(col1Pad) + header;
            }

            DisplayColored(header);

            foreach(var siteInfo in siteInfos)
            {
                var site = siteInfo.Site;
                menu.Add($"{siteInfo.Name}{site.SiteNumber}", siteInfo);

                string rowTxt = $"{site.SiteNumber.ToString().PadRight(col2Pad)}" +
                                $"{site.MaxOccupancy.ToString().PadRight(col3Pad)}" +
                                $"{(site.IsAccessible ? "Yes" : "No").PadRight(col4Pad)}" +
                                $"{(site.MaxRvLength == 0 ? "N/A" : site.MaxRvLength.ToString()).PadRight(col5Pad)}" +
                                $"{(site.HasUtilities ? "Yes" : "N/A").PadRight(col6Pad)}" +
                                $"{GetTotalCost(siteInfo.DailyFee, reservation.FromDate, reservation.ToDate).ToString("C")}";

                if (isParkWide)
                {
                    rowTxt = $"{siteInfo.Name.PadRight(col1Pad)}" + rowTxt;
                }

                Console.WriteLine(rowTxt);
            }
        }

        /// <summary>
        /// Returns the total cost of a reservation
        /// </summary>
        /// <param name="dailyFee">The daily fee for the campground</param>
        /// <param name="fromDate">The starting date of the reservation</param>
        /// <param name="toDate">The ending date of the reservation</param>
        /// <returns></returns>
        private decimal GetTotalCost(decimal dailyFee, DateTime fromDate, DateTime toDate)
        {
            return (toDate - fromDate).Days * dailyFee;
        }

        /// <summary>
        /// Displays invalid selection to the user
        /// </summary>
        private void DisplayInvalidSelection()
        {
            Console.WriteLine();
            Console.WriteLine(Message_InvalidSelection);
            Console.WriteLine(Message_PressKeyContinue);
            Console.ReadKey();
        }

        /// <summary>
        /// Displays an error message to the user
        /// </summary>
        /// <param name="message">The message to display</param>
        private void DisplayErrorMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine(Message_PressKeyContinue);
            Console.ReadKey();
        }

        /// <summary>
        /// Displays a message in a specified color
        /// </summary>
        /// <param name="message">The message to be displayed to the user</param>
        /// <param name="color">The color of the message to be displayed</param>
        private void DisplayColored(string message, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Gets the required padding for the campground names
        /// </summary>
        /// <param name="campgrounds">List of campgrounds that need name padding</param>
        /// <returns>Returns the max length of the campground names plus 2</returns>
        private int GetCampgroundNamePadding(List<CampgroundItem> campgrounds)
        {
            int result = 0;
            foreach(var campground in campgrounds)
            {
                if(campground.Name.Length > result)
                {
                    result = campground.Name.Length;
                }
            }
            return result + 2;
        }

        /// <summary>
        /// Gets the required padding for the site names
        /// </summary>
        /// <param name="siteInfos">List of sites that need name padding</param>
        /// <returns>Returns the max length of the site names plus 2</returns>
        private int GetSiteNamePadding(List<SiteInfo> siteInfos)
        {
            int result = 0;
            foreach (var siteInfo in siteInfos)
            {
                if (siteInfo.Name.Length > result)
                {
                    result = siteInfo.Name.Length;
                }
            }
            return result + 2;
        }

        /// <summary>
        /// Gets the required padding for the reservation names
        /// </summary>
        /// <param name="reservations">List of reservations that need name padding</param>
        /// <returns>Returns the max length of the reservation names plus 2</returns>
        private int GetReservationNamePadding(List<ReservationHistory> reservations)
        {
            int result = 0;
            foreach (var reservationHistory in reservations)
            {
                var reservation = reservationHistory.Reservation;
                if (reservation.Name.Length > result)
                {
                    result = reservation.Name.Length;
                }
            }
            return result + 2;
        }

    }
}
