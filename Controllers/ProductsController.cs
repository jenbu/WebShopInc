using AutoMapper;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.DomainModels;
using EFDataAccessLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShopInc.ApiWrappings;
using WebShopInc.Validations;

namespace WebShopInc.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : BaseController
{
    private readonly IMapper _mapper;
    private ProductValidator _productValidator = new ProductValidator();
    private readonly IRepository<Product> _productsRepository;


    public ProductsController(IMapper mapper,
        IRepository<Product> repository) {
        _mapper = mapper;
        _productsRepository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductModel>>> Get()
    {
        var productEntities = await _productsRepository.NoTracking
            .Include(p => p.ProductDeliveryTimes)
            .ToListAsync();

        return FormatResult(_mapper.Map<IEnumerable<ProductModel>>(productEntities));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductModel>> Get(int id)
    {
        var productEntity = await _productsRepository.NoTracking
            .Include(p => p.ProductDeliveryTimes)
            .FirstOrDefaultAsync(product => product.Id == id);

        if (productEntity == null)
        {
            return NotFound();
        }

        return FormatResult(_mapper.Map<ProductModel>(productEntity));
    }

    [HttpPost]
    public async Task<ActionResult<ProductModel>> Add([FromBody] ProductModel model)
    {
        var results = _productValidator.Validate(model);

        if(!results.IsValid)
        {
            return UnprocessableEntity(results.ToString());
        }

        var entity = _mapper.Map<Product>(model);

        await _productsRepository.InsertAsync(entity);

        return FormatResult(_mapper.Map<ProductModel>(entity));
    }

    [HttpPut]
    public async Task<ActionResult<ProductModel>> Edit([FromBody] ProductModel model)
    {
        var results = _productValidator.Validate(model);

        if (!results.IsValid)
        {
            return UnprocessableEntity(results.ToString());
        }

        var entity = _mapper.Map<Product>(model);

        await _productsRepository.UpdateAsync(entity);

        return FormatResult(_mapper.Map<ProductModel>(entity));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> Delete(int id)
    {
        var productEntity = await _productsRepository.NoTracking
            .FirstOrDefaultAsync(product => product.Id == id);

        if(productEntity == null)
        {
            return NotFound("Product not found");
        } 

        await _productsRepository.DeleteAsync(productEntity);
                
        return Ok();
    }
}
