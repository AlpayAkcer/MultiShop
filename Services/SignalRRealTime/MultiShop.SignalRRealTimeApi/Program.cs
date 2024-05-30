using MultiShop.SignalRRealTimeApi.Hubs;
using MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices;
using MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true)
               .AllowCredentials();
    });
});

builder.Services.AddSignalR();

builder.Services.AddScoped<ISignalRCommentService, SignalRCommentService>();
builder.Services.AddScoped<ISignalRMessageService, SignalRMessageService>();





//AllowAnyHeader(): Ýsteðin herhangi bir baþlýk içermesine izin verir.
//AllowAnyOrigin(): Ýsteðin herhangi bir kaynaktan (domainden/adresten/url) gelmesine izin verir.
//AllowAnyMethod(): Ýsteðin herhangi bir HTTP metodu/yordamý (GET, POST, PUT, DELETE, PATCH vb.) ile yapýlmasýna izin verir.
//SetIsOriginAllowed(): metodu, CORS politikalarýný kontrol etme imkaný sunduðu için güçlü bir araçtýr. Güvenlik açýsýndan doðru kullanýlmalýdýr. Yanlýþ bir kullanýmý güvenlik açýðýna içeriye amcalarýn dalmasýna neden olabilir.
//SetIsOriginAllowed(origin => {...}): Gelen isteðin kaynaðýný kontrol eden ve izin verilip verilmeyeceðine karar veren bir lambda ifadesi tanýmlar.
//SetIsOriginAllowed(): metodu, bir lambda ifadesi alýr ve bu ifade, gelen isteðin adresini parametre olarak alýr. Lambda ifadesi true dönerse, adres izin verilenler listesine dahil edilir; false dönerse, adres/istek reddedilir.
//AllowCredentials(): metodu, istemcinin kimlik bilgileriyle birlikte sunucuya istek göndermesine izin verir. Bu metod, CORS politikasýnýn bir parçasý olarak kullanýlýr ve doðru bir þekilde yapýlandýrýlmasý gerekir, aksi takdirde güvenlik riskleri ortaya çýkabilir. Kimlik bilgileri, genellikle çerezler, HTTP kimlik doðrulama bilgileri veya istemci tarafý SSL sertifikalarý gibi öðeleri içerir.



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

//Örnek: https://localhost:7157/swagger/category/index gibi veriye gitmesini saðlamak için. Baþlangýç portu aþaðýdan gelen degerden gelecek. Çaðýrýlacak olan sýnýfa baðlý olarak veriler gelecek. 
app.MapHub<SignalRHub>("/signalrhub");
app.Run();
