using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkReservation;
using ParkReservation.Models;
using ParkReservation.Models.Database;
using Security.BusinessLogic;
using Security.DAO;
using Security.Models;
using Security.Models.Database;
using System;
using System.Transactions;

namespace Capstone.Tests
{
    /// <summary>
    /// Integration tests for the ParkDAO class
    /// </summary>
    [TestClass]
    public class ParkDAOTests
    {
        /// <summary>
        /// The connection string used for the Park DAO and the User Manager
        /// </summary>
        private const string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=npcampground;Integrated Security=true";

        /// <summary>
        /// Used to begin a transaction during initialize and rollback during cleanup
        /// </summary>
        private TransactionScope _tran = null;

        /// <summary>
        /// The Park DAO object that is the object of these tests
        /// </summary>
        private IParkDAO _db = null;
        
        /// <summary>
        /// Used to create users for tests that need a user ID
        /// </summary>
        private UserManager _userMgr = null;

        /// <summary>
        /// Set up the database before each test  
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _db = new ParkDAO(_connectionString);
            _userMgr = new UserManager(new UserSecurityDAO(_connectionString));

            // Initialize a new transaction scope. This automatically begins the transaction.
            _tran = new TransactionScope();
        }

        /// <summary>
        /// Cleanup runs after every single test
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            _tran.Dispose(); //<-- disposing the transaction without committing it means it will get rolled back
        }

        /// <summary>
        /// Tests the Park DAO methods
        /// </summary>
        [TestMethod()]
        public void TestPark()
        {
            var park = CreatePark("Mt. Airy");

            var parks = _db.GetParks();
            park.Id = _db.AddPark(park);
            var newParks = _db.GetParks();
            Assert.AreEqual(parks.Count + 1, newParks.Count);

            bool foundPark = false;
            foreach(var newPark in newParks)
            {
                if(newPark.Id == park.Id)
                {
                    foundPark = true;
                }
            }
            Assert.IsTrue(foundPark);
        }
        
        /// <summary>
        /// Tests the campground DAO methods
        /// </summary>
        [TestMethod()]
        public void TestCampground()
        {
            var park = CreatePark("Mt. Airy");
            park.Id = _db.AddPark(park);

            var campgrounds = _db.GetCampgrounds(park.Id);
            Assert.AreEqual(0, campgrounds.Count);

            var bobGround = CreateCampground("Bob", park.Id);
            bobGround.Id = _db.AddCampground(bobGround);

            var timGround = CreateCampground("Tim", park.Id);
            timGround.Id = _db.AddCampground(timGround);

            campgrounds = _db.GetCampgrounds(park.Id);
            Assert.AreEqual(2, campgrounds.Count);

            foreach (var campground in campgrounds)
            {
                if (campground.Id == bobGround.Id)
                {
                    Assert.AreEqual(bobGround.Name, campground.Name);
                    Assert.AreEqual(bobGround.ParkId, campground.ParkId);
                    Assert.AreEqual(bobGround.OpenFromMonth, campground.OpenFromMonth);
                    Assert.AreEqual(bobGround.OpenToMonth, campground.OpenToMonth);
                    Assert.AreEqual(bobGround.DailyFee, campground.DailyFee);
                }
            }
        }

        /// <summary>
        /// Tests the get sites methods that returns all availables sites for a specific reservation request
        /// </summary>
        [TestMethod()]
        public void TestReservation()
        {
            var park = CreatePark("Mt. Airy");
            park.Id = _db.AddPark(park);
            var alphaGnd = CreateCampground("Alpha", park.Id);
            alphaGnd.Id = _db.AddCampground(alphaGnd);
            var site1 = CreateSite(alphaGnd.Id, 1);
            site1.Id = _db.AddSite(site1);
            var site2 = CreateSite(alphaGnd.Id, 2, true);
            site2.Id = _db.AddSite(site2);
            var site3 = CreateSite(alphaGnd.Id, 3, true, true);
            site3.Id = _db.AddSite(site3);
            var site4 = CreateSite(alphaGnd.Id, 4, true, true, 24);
            site4.Id = _db.AddSite(site4);
            var site5 = CreateSite(alphaGnd.Id, 5, true, true, 24, 16);
            site5.Id = _db.AddSite(site5);

            // Test the default criteria
            var resInfo = CreateReservationInfo(alphaGnd.Id, DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2), false, false, 0, 1);
            var availableSites = _db.GetSites(resInfo);
            Assert.AreEqual(5, availableSites.Count);

            // Test the default criteria with utilities
            resInfo.HasUtilities = true;
            availableSites = _db.GetSites(resInfo);
            Assert.AreEqual(4, availableSites.Count);

            // Test the default criteria with utilities and accessibility
            resInfo.IsAccessible = true;
            availableSites = _db.GetSites(resInfo);
            Assert.AreEqual(3, availableSites.Count);

            // Test the default criteria with utilities, accessibility, and rv length
            resInfo.RvLength = 24;
            availableSites = _db.GetSites(resInfo);
            Assert.AreEqual(2, availableSites.Count);
            resInfo.RvLength = 25;
            availableSites = _db.GetSites(resInfo);
            Assert.AreEqual(0, availableSites.Count);

            // Test the default criteria with utilities, accessibility, max occupancy, and rv length
            resInfo.RvLength = 24;
            resInfo.Occupancy = 17;
            availableSites = _db.GetSites(resInfo);
            Assert.AreEqual(0, availableSites.Count);
            resInfo.Occupancy = 16;
            availableSites = _db.GetSites(resInfo);
            Assert.AreEqual(1, availableSites.Count);

            // Test date conflict
            User user = new User();
            user.FirstName = "Chris";
            user.LastName = "Rupp";
            user.Email = "!@#$%^@tech.com";
            user.Username = "!@#$%^";
            user.Password = "bob";
            user.ConfirmPassword = "bob";
            _userMgr.RegisterUser(user);

            var res1 = CreateReservation(site5, DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(3));
            _db.MakeReservation(res1, _userMgr.User.Id);
            availableSites = _db.GetSites(resInfo);
            Assert.AreEqual(0, availableSites.Count);
        }

        /// <summary>
        /// Creates a reservation database object
        /// </summary>
        /// <param name="site">The site to be reserved</param>
        /// <param name="fromDate">The start date of the reservation</param>
        /// <param name="toDate">The end date of the reservation</param>
        /// <returns>A complete reservation database object</returns>
        private ReservationItem CreateReservation(SiteItem site, DateTime fromDate, DateTime toDate)
        {
            var reservation = new ReservationItem()
            {
                SiteId = site.Id,
                CreatedDate = DateTime.UtcNow,
                FromDate = fromDate,
                ToDate = toDate,
                Name = "Jones"
            };

            return reservation;
        }

        /// <summary>
        /// Creates a reservation info object used to request available sites for a potential reservation
        /// </summary>
        /// <param name="campgroundId">The id of the campground for the requested reservation</param>
        /// <param name="fromDate">The start date of the reservation</param>
        /// <param name="toDate">The end date of the reservation</param>
        /// <param name="hasUtilities">Specifies if the site should contain utilities</param>
        /// <param name="isAccessible">Specifies if the site should have handicap accessibility</param>
        /// <param name="rvLength">Specifies the sites minimum rv length</param>
        /// <param name="maxOccupancy">Specifies the sites required max occupancy</param>
        /// <returns>A populated reservation info object</returns>
        private ReservationInfo CreateReservationInfo(int campgroundId,
                                                      DateTime fromDate, 
                                                      DateTime toDate,
                                                      bool hasUtilities,
                                                      bool isAccessible,
                                                      int rvLength,
                                                      int maxOccupancy)
        {
            ReservationInfo info = new ReservationInfo()
            {
                CampgroundId = campgroundId,
                FromDate = fromDate,
                ToDate = toDate,
                HasUtilities = hasUtilities,
                IsAccessible = isAccessible,
                Occupancy = maxOccupancy,
                RvLength = rvLength
            };

            return info;
        }

        /// <summary>
        /// Creates a site database object
        /// </summary>
        /// <param name="campgroundId">The id of the campground the site belongs to</param>
        /// <param name="siteNumber">The site number</param>
        /// <param name="hasUtilities">Specifies if the site has utilities</param>
        /// <param name="isAccessible">Specifies if the site has handicap accessibility</param>
        /// <param name="rvLength">Specifies the maximup RV length the site supports</param>
        /// <param name="maxOccupancy">Specifies the sites maximum occupancy</param>
        /// <returns>A complete site item database object</returns>
        private SiteItem CreateSite(int campgroundId,
                                    int siteNumber,
                                    bool hasUtilities = false, 
                                    bool isAccessible = false, 
                                    int rvLength = 0, 
                                    int maxOccupancy = 8)
        {
            var site = new SiteItem()
            {
                CampgroundId = campgroundId,
                HasUtilities = hasUtilities,
                IsAccessible = isAccessible,
                MaxRvLength = rvLength,
                MaxOccupancy = maxOccupancy,
                SiteNumber = siteNumber
            };

            return site;
        }

        /// <summary>
        /// Creates a Park database object
        /// </summary>
        /// <param name="name">The name of the park</param>
        /// <returns>A completed database park object with dummy data</returns>
        private ParkItem CreatePark(string name)
        {
            var park = new ParkItem()
            {
                Area = 10,
                Description = "description",
                EstablishedDate = DateTime.Now,
                Location = "Ohio",
                Name = name,
                Visitors = 100000
            };

            return park;
        }

        /// <summary>
        /// Creates a Campround database object with dummy data
        /// </summary>
        /// <param name="name">The name of the campground</param>
        /// <param name="parkId">The id of the park the campground belongs to</param>
        /// <returns>A complete database object with dummy data</returns>
        private CampgroundItem CreateCampground(string name, int parkId)
        {
            var campground = new CampgroundItem()
            {
                Name = name,
                ParkId = parkId,
                OpenFromMonth = 6,
                OpenToMonth = 11,
                DailyFee = 100M
            };

            return campground;
        }

    }
}
