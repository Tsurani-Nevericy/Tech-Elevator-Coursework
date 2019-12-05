using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MVCModels.Web.Models;

namespace MVCModels.Web.DAL
{
    public class ProductSqlDAO : IProductDAO
    {
        /// <summary>
        /// Connection string for the dao.
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Sort choices.
        /// </summary>
        private static Dictionary<ProductSortOrder, string> SortChoices = new Dictionary<ProductSortOrder, string>()
        {
            { ProductSortOrder.Default, "id ASC" },
            { ProductSortOrder.PriceHighToLow, "price DESC" },
            { ProductSortOrder.PriceLowToHigh, "price ASC" },
            { ProductSortOrder.RatingHighToLow, "average_rating DESC" }
        };

        /// <summary>
        /// Creates a new sql dao for retrieving products.
        /// </summary>
        /// <param name="connectionString">A connection string to a Sql Database</param>
        public ProductSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns></returns>
        public IList<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM products", connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        products.Add(MapRowToProduct(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine($"Exception occurred reading product data - ${ex}");
                throw;
            }

            return products;
        }

        public IList<Product> GetAll(ProductFilter filter, ProductSortOrder sortOrder)
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();

                    string sql = $"SELECT products.* FROM products " +
                        $"JOIN categories ON products.category_id = categories.id " +
                        $"WHERE (price BETWEEN {filter.MinPrice} AND {filter.MaxPrice}) " +
                        $"AND (average_rating >= {filter.MinRating}) "; 

                    if (!String.IsNullOrEmpty(filter.Category))
                    {
                        sql += $"AND (categories.name = @category)";
                        command.Parameters.AddWithValue("@category", filter.Category);
                    }

                    sql += $" ORDER BY {SortChoices[sortOrder]};";

                    command.CommandText = sql;
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        products.Add(MapRowToProduct(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine($"Exception occurred reading product data - ${ex}");
                throw;
            }

            return products;
        }

        public Product GetById(int id)
        {
            Product product = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM products WHERE id = @id", connection);
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        product = MapRowToProduct(reader);                        
                    }

                    return product;
                }
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine($"An error occurred reading product {id} - ${ex}");
                throw;
            }
        }

        private Product MapRowToProduct(SqlDataReader reader)
        {
            Product product = new Product();
            product.Id = Convert.ToInt32(reader["id"]);
            product.Name = Convert.ToString(reader["name"]);
            product.ImageName = Convert.ToString(reader["image_name"]);
            product.Description = Convert.ToString(reader["description"]);
            product.AverageRating = Convert.ToDouble(reader["average_rating"]);
            product.IsTopSeller = Convert.ToBoolean(reader["is_top_seller"]);
            product.RemainingStock = Convert.ToInt32(reader["quantity"]);
            product.Price = Convert.ToDecimal(reader["price"]);

            return product;
        }
    }
}
