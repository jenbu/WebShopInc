using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebShopInc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController() { }

        [HttpGet]
        public List<Product> Get()
        {
            using var context = new ProductContext();

            List<Product> productList = context.Product
                .Include(p => p.ProductDeliveryTimes)
                .ToList();

            return productList;
        }

        [HttpPost]
        public void Add()
        {
            Product product = new Product{
                //Id = 666,
                Name = "Some Name",
                Description = "Some description",
                ImageUrl = null,
                Unit = "unit"
            };
        
            using var context = new ProductContext();

            context.Product.Add(product);

            context.SaveChanges();
        }
    }

}
