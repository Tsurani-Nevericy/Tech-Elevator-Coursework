using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Models;
using ShoppingListAPI.Services;

namespace ShoppingListAPI.Controllers
{
    /// <summary>
    /// Manages grocery items
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IDataAccessLayer<Item> _db;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataAccessLayer">Data Source</param>
        public ItemController(IDataAccessLayer<Item> dataAccessLayer)
        {
            _db = dataAccessLayer;
        }

    }
}