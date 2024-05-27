namespace MultiShop.Cargo.Dto.Dtos.CargoCustomerDto
{
    public class CreateCargoCustomerDto
    {
        public string? CustomerTitle { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerAddress { get; set; }
        public string UserCustomerId { get; set; }
    }
}
