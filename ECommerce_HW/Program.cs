using ECommerce_HW.Business.Services.Abstracts;
using ECommerce_HW.Business.Services.Concretes;
using ECommerce_HW.DataAccess.Abstraction;
using ECommerce_HW.DataAccess.Concrete;
using ECommerce_HW.Entities;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")).UseLazyLoadingProxies());

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductDal, EFProductDal>();
builder.Services.AddScoped<IOrderDal, EFOrderDal>();
builder.Services.AddScoped<ICustomerDal, EFCustomerDal>();

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
