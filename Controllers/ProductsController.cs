using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebShopInc.Models;

namespace WebShopInc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private string connectionString;

        public ProductsController()
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        [HttpGet]
        public List<ProductItem> Get()
        {
            List<ProductItem> productList = new List<ProductItem>();
            string queryProducts = "SELECT * FROM Products";
            string queryDeliveryTimes = "SELECT ProductDeliveryTimes.fromDay, ProductDeliveryTimes.toDay, ProductDeliveryTimes.days, ProductDeliveryTimes.ProductId FROM ProductDeliveryTimes INNER JOIN Products ON ProductDeliveryTimes.ProductId = Products.Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // create the command and the parameter objects
                SqlCommand command = new SqlCommand(queryProducts, connection);

                ProductItem product = new ProductItem();

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productList.Add(new ProductItem
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name"),
                                Description = reader.GetString("description"),
                                ImgURL = reader.GetString("img_url"),
                                Unit = reader.GetString("unit"),
                                deliveryTimeList = new List<ProductDeliveryTime>()
                            });
                        }
                    }

                    // Adds related entries in ProductDeliveryTimes table
                    command.CommandText= queryDeliveryTimes;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for(int it = 0; it < productList.Count; it++)
                            {
                                if (productList[it].Id == reader.GetInt32("ProductId"))
                                {
                                    productList[it].deliveryTimeList.Add(new ProductDeliveryTime
                                    {
                                        fromDays = reader.GetInt32("fromDay"),
                                        toDays = reader.GetInt32("toDay"),
                                        days = reader.GetInt32("Days")
                                    });
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return productList;
                }
            }
            return productList;
        }
    }

}
