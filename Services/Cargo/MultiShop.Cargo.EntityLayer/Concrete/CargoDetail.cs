namespace MultiShop.Cargo.EntityLayer.Concrete
{
    public class CargoDetail
    {
        public int CargoDetailId { get; set; }
        public string SenderCustomer { get; set; } // Gönderici firmaları
        public string ReceiverCustomer { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
        public CargoCompany CargoCompany { get; set; }
    }
}
