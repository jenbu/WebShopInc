using System.Collections.Generic;

namespace EFDataAccessLibrary.DomainModels
{
    public class ProductModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Unit {  get; set; }

        public List<ProductDeliveryTimeModel> ProductDeliveryTimes { get; set;}
    }
}
