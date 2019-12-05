using SessionCart.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionCart.Web.DAL
{
    public interface IProductDAO
    {
        /// <summary>
        /// Gets all of the products.
        /// </summary>
        /// <returns></returns>
        IList<Product> GetProducts();

        /// <summary>
        /// Gets a single product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product GetProduct(int id);

    }
}
