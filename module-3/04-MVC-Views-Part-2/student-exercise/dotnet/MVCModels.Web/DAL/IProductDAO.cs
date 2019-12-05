using MVCModels.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCModels.Web.DAL
{
    public interface IProductDAO
    {
        /// <summary>
        /// Gets all of the products.
        /// </summary>
        /// <returns></returns>
        IList<Product> GetAll();

        /// <summary>
        /// Gets all of the products with optional filters or sort orders applied.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        IList<Product> GetAll(ProductFilter filter, ProductSortOrder sortOrder);

        /// <summary>
        /// Gets a single product
        /// </summary>
        /// <param name="id">The product id</param>
        /// <returns></returns>
        Product GetById(int id);
    }
}
