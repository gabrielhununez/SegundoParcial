using Microsoft.EntityFrameworkCore;
using SegundoParcial.Abstractions.Interfaces;
using SegundoParcial.Data.EF;
using SegundoParcial.Data.Repository;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("CONNECTIONSTRING");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
builder.Services.AddDbContext<DBContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// Add services to the container.
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();