namespace MultiShop.Basket.Dtos.BasketDto
{
    public class BasketItemDto
    {
        //Ürünler catalog web servisinden gelecek. Id değeri int olursa uuzn vadede sorun yaşarız.
        // Bu nedenle string yapıyoruz catalog ile aynı.
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
