using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;
using System.Net.Http;
using System.Security.Claims;

namespace MultiShop.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClientSettings _clientSettings;

        public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IOptions<ClientSettings> clientSettings)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _clientSettings = clientSettings.Value;
        }

        public async Task<bool> SignIn(SignInDto signInDto)
        {
            //GetDiscoveryDocumentAsync kullanabilmek için nuget pack. identityServer4.Storage kurmak gerekli,
            //Buradaki ayarlar 5001 portuna istek atarken identity serverin SSL olup olmamasını sağlamak
            // şu an identity server http: olarak çalışıyor eğer RequireHttp=true yaparsak ssl'li olarak çalışacak.

            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "http://localhost:5001",
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            //Adrese istek yaparken config sınıfındaki kullanıcılar için password ile giriş zorunlu olacak şekilde ayarlanacak
            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSettings.MultishopManagerClient.ClientId,
                ClientSecret = _clientSettings.MultishopManagerClient.ClientSecret,
                UserName = signInDto.Username,
                Password = signInDto.Password,
                Address = discoveryEndPoint.TokenEndpoint
            };

            // token oluşturma işlemi
            var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

            // istekte bulunduğum kullanıcının bilgilerine ihtiyacımız olacak.
            var userInfo = new UserInfoRequest
            {
                Token = token.AccessToken,
                Address = discoveryEndPoint.UserInfoEndpoint
            };

            var userValues = await _httpClient.GetUserInfoAsync(userInfo);
            //oluşturduğumuz tokeni kullanıcıya atama
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var authanticationProperties = new AuthenticationProperties();
            authanticationProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.AccessToken,
                    Value= token.AccessToken
                },
                new AuthenticationToken
                {
                      Name=OpenIdConnectParameterNames.RefreshToken,
                    Value= token.AccessToken
                },
                new AuthenticationToken
                {
                      Name=OpenIdConnectParameterNames.ExpiresIn,
                    Value= DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                },
            });

            //Giriş yaptığı anda daha sonrası için hatırlama false, her defasında giriş yapmak için
            authanticationProperties.IsPersistent = false;
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authanticationProperties);
            return true;
        }
    }
}
