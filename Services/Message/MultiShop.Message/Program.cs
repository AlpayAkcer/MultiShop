using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Projeye JwtBearer yükledikten sonra bu ayarý yapmak gerekiyor. Catalog tokenini oluþturmak ve kontrol etmek için.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
//{
//    opt.Authority = builder.Configuration["IdentityServerUrl"];
//    opt.Audience = "ResourceMessage";
//    opt.RequireHttpsMetadata = false;
//});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MessageContext>(opt =>
{
    opt.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IUserMessageService, UserMessageService>();

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
