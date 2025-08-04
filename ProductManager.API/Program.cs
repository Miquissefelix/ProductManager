using Microsoft.EntityFrameworkCore;
using ProductManager.Application;
//using ProductManager.Application.Interfaces;
using ProductManager.Application.UseCases.Produtos;
using ProductManager.Domain.Interfaces;
using ProductManager.Infrastructure.Data;
using ProductManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

//mydependece
builder.Services.AddDbContext<AppDbContext>(options =>options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof
    (AssemblyReference).Assembly));

// Registrar Repositórios e Serviços
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
//builder.Services.AddScoped<IProdutoService,ProdutoService>();

// Add services to the container.

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
