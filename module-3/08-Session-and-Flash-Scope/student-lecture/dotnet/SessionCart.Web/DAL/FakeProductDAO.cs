using SessionCart.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionCart.Web.DAL
{
    public class FakeProductDAO : IProductDAO
    {
        public Product GetProduct(int id)
        {
            return GetAllProducts().FirstOrDefault(p => p.Id == id);
        }

        public IList<Product> GetProducts()
        {
            return GetAllProducts();
        }

        private IList<Product> GetAllProducts()
        {
            return new List<Product>()
            {
                new Product() { Id = 5, Name = "Light switch", Cost = 3.99M},
                new Product() { Id = 8, Name = "Electric Drill", Cost = 64.59M},
                new Product() { Id = 13, Name = "Circular Saw", Cost = 135.99M},
                new Product() { Id = 15, Name = "Nails (24 ct.)", Cost = 4.99M},
                new Product() { Id = 19, Name = "Air Compressor", Cost = 305M}
            };
        }
    }
}
