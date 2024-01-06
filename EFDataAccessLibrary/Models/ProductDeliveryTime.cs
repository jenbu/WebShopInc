namespace EFDataAccessLibrary.Models
{
    public class ProductDeliveryTime
    {
        public int Id { get; set; }

        public int ProductId {  get; set; }

        public int FromDay { get; set; }

        public int ToDay { get; set; }

        public int Days { get; set; }
    }
}
