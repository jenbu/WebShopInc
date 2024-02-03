using AutoMapper;
using EFDataAccessLibrary.DomainModels;
using EFDataAccessLibrary.Entities;

namespace WebShopInc.Mappings;

public class ProductMap : Profile
{
    public ProductMap()
    {
        CreateMap<Product, ProductModel>();
        CreateMap<ProductModel, Product>();
    }
}
