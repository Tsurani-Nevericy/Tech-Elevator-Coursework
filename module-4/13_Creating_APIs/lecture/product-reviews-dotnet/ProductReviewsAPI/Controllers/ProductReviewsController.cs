using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ProductReviewsAPI.Models;
using ProductReviewsAPI.Services;

namespace ProductReviewsAPI.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ProductReviewsController : ControllerBase 
    {
        private DataAccessLayer _db;

        public ProductReviewsController(DataAccessLayer dataAccessLayer)
        {
            _db = dataAccessLayer;
        }

        /// <summary>
        /// Get all the product reviews
        /// </summary>
        /// <returns>List of all the product reviews</returns>
        [HttpGet]
        public List<ProductReview> GetAll() 
        {
            return _db.GetAll();
        }

        [HttpGet("{id}", Name = "GetProductReview")]
        public ActionResult<ProductReview> GetProductReview(int id)
        {
            ActionResult<ProductReview> result = NotFound();

            var review = _db.Get(id);

            if( review != null )
            {
                result = review;
            }

            return result;
        }

        /// <summary>
        /// Adds a product review
        /// </summary>
        /// <param name="productReview">The product review to be added</param>
        /// <returns>The created product review</returns>
        [HttpPost]
        public ActionResult Create([FromBody] ProductReview productReview)
        {
            _db.Add(productReview);

            // Return a created at route to indicate where the resource can be found
            return CreatedAtRoute("GetProductReview", new { id = productReview.Id }, productReview);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, ProductReview updatedReview)
        {
            ActionResult result = NoContent();

            // Get the existing review
            var existingReview = _db.Get(id);

            // If that review does not exists, return 404
            if (existingReview == null)
            {
                result = NotFound();
            }
            else
            {
                // Copy over the fields we want to change
                existingReview.Name = updatedReview.Name;
                existingReview.Title = updatedReview.Title;
                existingReview.Review = updatedReview.Review;

                // Save back to the database
                _db.Update(existingReview);
            }

            // return a 204
            return result;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            ActionResult result = NoContent();

            var review = _db.Get(id);

            if (review == null)
            {
                // return HTTP 404
                result = NotFound();
            }
            else
            {
                // delete the resource
                _db.Delete(id);
            }

            // return HTTP 201
            return result;
        }

    }

}