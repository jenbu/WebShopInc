using AutoMapper;
using EFDataAccessLibrary.DomainModels;
using EFDataAccessLibrary.Entities;

namespace WebShopInc.Mappings;

public class ProductDeliveryTimeMap : Profile
{
    public ProductDeliveryTimeMap()
    {
        CreateMap<ProductDeliveryTime, ProductDeliveryTimeModel>();
        CreateMap<ProductDeliveryTimeModel, ProductDeliveryTime>();
    }
}
