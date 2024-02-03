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

    public ProductsController(IMapper mapper) {
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductModel>>> Get()
    {
        using var context = new ProductContext();

        var productEntities = await context.Product
            .Include(p => p.ProductDeliveryTimes)
            .ToListAsync();

        return FormatResult(_mapper.Map<IEnumerable<ProductModel>>(productEntities));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductModel>> Get(int id)
    {
        using var context = new ProductContext();

        var productEntity = await context.Product
            .Include(p => p.ProductDeliveryTimes)
            .FirstOrDefaultAsync(product => product.Id == id);

        if(productEntity == null)
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

        using var context = new ProductContext();

        await context.Product.AddAsync(entity);

        await context.SaveChangesAsync();

        var result = await context.Product
                            .FirstOrDefaultAsync();

        return FormatResult(_mapper.Map<ProductModel>(result));
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

        using var context = new ProductContext();

        context.Product.Update(entity);

        await context.SaveChangesAsync();

        var result = await context.Product
                            .FirstOrDefaultAsync();

        return FormatResult(_mapper.Map<ProductModel>(result));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> Delete(int id)
    {
        using var context = new ProductContext();

        var productEntity = await context.Product
            .FirstOrDefaultAsync(product => product.Id == id);

        if(productEntity == null)
        {
            return NotFound("Product not found");
        }
        context.Product.Remove(productEntity);

        await context.SaveChangesAsync();

        return FormatResult(id);
    }
}
