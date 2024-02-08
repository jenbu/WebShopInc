using EFDataAccessLibrary.DomainModels;

namespace EFDataAccessLibrary.Entities;

public class Product : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public string? Unit {  get; set; }

    public List<ProductDeliveryTime> ProductDeliveryTimes { get; set; } = new List<ProductDeliveryTime>();
}
