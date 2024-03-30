using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;
using MultiShop.Basket.Settings;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

//Proje bazýnda authorize iþlemi yapýlandýrýlmasý - Bir kullanýcýnýn zorunlu olmasý gerektiðini verdik.
var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

//Projeye JwtBearer yükledikten sonra bu ayarý yapmak gerekiyor. Catalog tokenini oluþturmak ve kontrol etmek için.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceBasket";
    opt.RequireHttpsMetadata = false;
});

//Baðlanan kullanýcý bilgilerini almak için AddHttpContextAccessor eklememiz gerekiyor.
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));

//Redis configuration ayarlarý
builder.Services.AddSingleton<RedisService>(sp =>
{
    var redisseetings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
    var redis = new RedisService(redisseetings.Host, redisseetings.Port);
    redis.Connect();
    return redis;
});

builder.Services.AddControllers(opt =>
{
    //kullanýcýyý griþe zorlamýþ oluyoruz.
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
