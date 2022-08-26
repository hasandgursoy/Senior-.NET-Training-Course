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

// Hatayý middleware ile ele aldýk harika oldu. Kodlarý okumayý ihmal etme.
// Geliþtiric tipinde hata almak istiyorsak yukarýdaki if bloðu içinde yazmamýz gerekiyor
//app.ConfigureCustomExceptionMiddleware();
if (app.Environment.IsDevelopment())
{
    app.ConfigureCustomExceptionMiddleware();

}

app.UseAuthorization();

app.MapControllers();

app.Run();
