namespace MultiShop.Cargo.Dto.Dtos.CargoDetailDto
{
    public class CreateCargoDetailDto
    {
        public string SenderCustomer { get; set; } // Gönderici firmaları
        public string ReceiverCustomer { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
    }
}
