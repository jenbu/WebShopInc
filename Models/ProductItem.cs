namespace WebShopInc.Models
{
    public class ProductItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ImgURL { get; set; }

        public string Unit { get; set; }

        public List<ProductDeliveryTime> deliveryTimeList { get; set; }

    }
}
