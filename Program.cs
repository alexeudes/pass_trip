using pass_trip.Business.Services;
using pass_trip.Business.Services.Interfaces;
using pass_trip.Infra.Interfaces;
using pass_trip.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI

//Infra
builder.Services.AddScoped<IPassportRepository, PassportRepository>();

//Business
builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<IPassportService, PassportService>();


#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

