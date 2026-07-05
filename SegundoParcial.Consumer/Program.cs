using SegundoParcial.Abstractions.Interfaces;
using SegundoParcial.Consumer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddServiceDiscovery();

builder.Services.AddHttpClient<IBackendClient, BackendClient>(client =>
{
    client.BaseAddress = new Uri("https+http://segundoParcialBackend");
})
.AddServiceDiscovery();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

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
