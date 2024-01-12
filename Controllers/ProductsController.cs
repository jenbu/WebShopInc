using AutoMapper;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.DomainModels;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebShopInc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper) {
            _mapper = mapper;
        }

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
        public void Add([FromBody] ProductModel model)
        {
            var entity = _mapper.Map<Product>(model);

            using var context = new ProductContext();

            context.Product.Add(entity);

            context.SaveChanges();
        }
    }

}
