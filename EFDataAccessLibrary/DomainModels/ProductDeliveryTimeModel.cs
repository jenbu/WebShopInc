namespace EFDataAccessLibrary.DomainModels
{
    public class ProductDeliveryTimeModel
    {

        public int ProductId {  get; set; }

        public int FromDay { get; set; }

        public int ToDay { get; set; }

        public int Days { get; set; }
    }
}
