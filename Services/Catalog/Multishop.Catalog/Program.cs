using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Multishop.Catalog.Services.CategoryServices;
using Multishop.Catalog.Services.ProductDetailServices;
using Multishop.Catalog.Services.ProductPictureServices;
using Multishop.Catalog.Services.ProductServices;
using Multishop.Catalog.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductPictureService, ProductPictureService>();

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
