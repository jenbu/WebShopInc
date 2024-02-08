using EFDataAccessLibrary.DomainModels;

namespace EFDataAccessLibrary.Entities;

public class ProductDeliveryTime: BaseModel
{
    public int ProductId {  get; set; }

    public int FromDay { get; set; }

    public int ToDay { get; set; }

    public int Days { get; set; }
}
