using Application;
using Application.UsesCases;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// DI
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<CrearProductoUseCase>();
builder.Services.AddScoped<EditarProductoCase>();
builder.Services.AddScoped<ListarProductosUseCase>();
builder.Services.AddScoped<EliminarProductoSoftUseCase>();
builder.Services.AddScoped<ObtenerProductoIdCase>();



builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Micro servicio Productos"
    });
});

//inyectar servicios de controladdor
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddDbContext<ApplicationDbContext>(options=>
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


