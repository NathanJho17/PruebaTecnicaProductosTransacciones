using Application.Mapping;
using Application.UsesCases;
using Domain.Interfaces;
using Domain.Services;
using Infrastructure.Persistence;
using Infrastructure.Repository;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddSingleton<IStockStrategy, AumentarStockStrategy>();
builder.Services.AddSingleton<IStockStrategy, DisminuirStockStrategy>();
builder.Services.AddSingleton<StockStrategyFactory>();
builder.Services.AddSingleton<StockService>();


// DI
builder.Services.AddScoped<IProductoExternoService, ProductoService>();
builder.Services.AddScoped<ITransaccionRepository, TransaccionRepository>();
builder.Services.AddScoped<CrearTransaccionUseCase>();
builder.Services.AddScoped<ListarTransaccionesUseCase>();
builder.Services.AddScoped<EditarTransaccionUseCase>();
builder.Services.AddScoped<ObtenerTransaccionUseCase>();
builder.Services.AddScoped<EliminarTransaccionSoftUseCase>();

builder.Services.AddHttpClient("ApiProductos", client =>
{
    client.BaseAddress = new Uri("http://localhost:5224");
});

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Micro servicio Transacción"
    });
});

//inyectar servicios de controladdor
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();




app.Run();

