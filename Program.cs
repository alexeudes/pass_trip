using pass_trip.Business.Services;
using pass_trip.Business.Services.Interfaces;
using pass_trip.Helpers;
using pass_trip.Infra.Interfaces;
using pass_trip.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddDbContext<DataContext>();
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

app.UseSwagger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseSwaggerUI();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

