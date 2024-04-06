using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Multishop.Catalog.Services.CategoryServices;
using Multishop.Catalog.Services.SliderServices;
using Multishop.Catalog.Services.ProductDetailServices;
using Multishop.Catalog.Services.ProductPictureServices;
using Multishop.Catalog.Services.ProductServices;
using Multishop.Catalog.Services.SpecialOfferServices;
using Multishop.Catalog.Services.DeliveryInfoServices;
using Multishop.Catalog.Services.OfferDiscountServices;
using Multishop.Catalog.Services.BrandServices;
using Multishop.Catalog.Settings;
using System.Reflection;
using Multishop.Catalog.Services.ContactServices;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductPictureService, ProductPictureService>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IDeliveryInfoService, DeliveryInfoService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//Projeye JwtBearer yükledikten sonra bu ayarý yapmak gerekiyor. Catalog tokenini oluþturmak ve kontrol etmek için.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCatalog";
    opt.RequireHttpsMetadata = false;
});

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DataBaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    //Database setting sýnýfýnýn içindeki valulara ulaþmasý için. 
    //Connection, Veritabaný adý, database tablolarýna ulaþmasýný saðlamak için.
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllers();

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
