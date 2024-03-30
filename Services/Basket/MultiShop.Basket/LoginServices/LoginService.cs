namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        //Giriş yapmış kullanıcının tokenden içerisinden aldığı SUB değerini yani userId'sini yakalıyorum.
        //boş olabilir hatası veriyor amam token ile id'yi alıp sepet ile ilişkilendireceğiz
        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
