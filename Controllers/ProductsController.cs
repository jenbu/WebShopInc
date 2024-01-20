using AutoMapper;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.DomainModels;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShopInc.ApiWrappings;

namespace WebShopInc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper) {
            _mapper = mapper;
        }

        //TODO: vurdere å bruke async
        [HttpGet]
        public ActionResult<ApiResponse<IEnumerable<Product>>> Get()
        {
            using var context = new ProductContext();
            //throw new Exception("abc");

            IEnumerable<Product> productList = context.Product
                .Include(p => p.ProductDeliveryTimes)
                .ToList();

            return Format(productList);
        }

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<Product>> Get(int id)
        {
            using var context = new ProductContext();

            Product product = context.Product
                .Include(p => p.ProductDeliveryTimes)
                .FirstOrDefault(product => product.Id == id);

            
            return Format(product);
            
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
