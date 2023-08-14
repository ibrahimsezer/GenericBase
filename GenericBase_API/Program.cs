using Business.Layer.Access.Concrete;
using Business.Layer.Access.Interface;
using Data.Layer.Access;
using Data.Layer.Access.Concrete;
using Data.Layer.Access.Entity;
using Data.Layer.Access.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DbContext, DataAccess>();

builder.Services.AddScoped<IProductRepo,ProductRepo<Product>>();
builder.Services.AddScoped<IBaseRepo<UserInfo>, BaseRepo<UserInfo>>();
builder.Services.AddScoped<IBusinessService, BusinessService>();


builder.Services.AddControllers();
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
