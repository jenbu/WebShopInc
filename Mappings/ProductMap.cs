using AutoMapper;
using EFDataAccessLibrary.DomainModels;
using EFDataAccessLibrary.Models;

namespace WebShopInc.Mappings;

public class ProductMap : Profile
{
    public ProductMap()
    {
        CreateMap<Product, ProductModel>();
        CreateMap<ProductModel, Product>();
    }
}
