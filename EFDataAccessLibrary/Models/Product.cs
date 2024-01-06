using System.Collections.Generic;

namespace EFDataAccessLibrary.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Unit {  get; set; }

        public List<ProductDeliveryTime> ProductDeliveryTimes { get; set;}
    }
}
