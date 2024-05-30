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





//AllowAnyHeader(): �ste�in herhangi bir ba�l�k i�ermesine izin verir.
//AllowAnyOrigin(): �ste�in herhangi bir kaynaktan (domainden/adresten/url) gelmesine izin verir.
//AllowAnyMethod(): �ste�in herhangi bir HTTP metodu/yordam� (GET, POST, PUT, DELETE, PATCH vb.) ile yap�lmas�na izin verir.
//SetIsOriginAllowed(): metodu, CORS politikalar�n� kontrol etme imkan� sundu�u i�in g��l� bir ara�t�r. G�venlik a��s�ndan do�ru kullan�lmal�d�r. Yanl�� bir kullan�m� g�venlik a����na i�eriye amcalar�n dalmas�na neden olabilir.
//SetIsOriginAllowed(origin => {...}): Gelen iste�in kayna��n� kontrol eden ve izin verilip verilmeyece�ine karar veren bir lambda ifadesi tan�mlar.
//SetIsOriginAllowed(): metodu, bir lambda ifadesi al�r ve bu ifade, gelen iste�in adresini parametre olarak al�r. Lambda ifadesi true d�nerse, adres izin verilenler listesine dahil edilir; false d�nerse, adres/istek reddedilir.
//AllowCredentials(): metodu, istemcinin kimlik bilgileriyle birlikte sunucuya istek g�ndermesine izin verir. Bu metod, CORS politikas�n�n bir par�as� olarak kullan�l�r ve do�ru bir �ekilde yap�land�r�lmas� gerekir, aksi takdirde g�venlik riskleri ortaya ��kabilir. Kimlik bilgileri, genellikle �erezler, HTTP kimlik do�rulama bilgileri veya istemci taraf� SSL sertifikalar� gibi ��eleri i�erir.



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

//�rnek: https://localhost:7157/swagger/category/index gibi veriye gitmesini sa�lamak i�in. Ba�lang�� portu a�a��dan gelen degerden gelecek. �a��r�lacak olan s�n�fa ba�l� olarak veriler gelecek. 
app.MapHub<SignalRHub>("/signalrhub");
app.Run();
