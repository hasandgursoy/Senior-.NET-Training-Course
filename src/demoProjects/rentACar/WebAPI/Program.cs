using Application;
using Core.CrossCuttingConcerns.Exceptions;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Hatay� middleware ile ele ald�k harika oldu. Kodlar� okumay� ihmal etme.
// Geli�tiric tipinde hata almak istiyorsak yukar�daki if blo�u i�inde yazmam�z gerekiyor
//app.ConfigureCustomExceptionMiddleware();
if (app.Environment.IsDevelopment())
{
    app.ConfigureCustomExceptionMiddleware();

}

app.UseAuthorization();

app.MapControllers();

app.Run();
