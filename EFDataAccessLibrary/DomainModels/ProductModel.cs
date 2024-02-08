namespace EFDataAccessLibrary.DomainModels;

public class ProductModel : BaseModel
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public string? Unit {  get; set; }

    public List<ProductDeliveryTimeModel> ProductDeliveryTimes { get; set;} = new List<ProductDeliveryTimeModel>();
}
