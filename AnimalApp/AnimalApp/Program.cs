using AnimalDataAPI.Controllers;
using AnimalDataAPI.DataBase;
using AnimalDataAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IAnimalDataBase, AnimalDataBase>();
builder.Services.AddScoped<IAnimalService, AnimalService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();

app.Run();