using Business.Layer.Access.Concrete;
using Business.Layer.Access.Interface;
using Data.Layer.Access;
using Data.Layer.Access.Concrete;
using Data.Layer.Access.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataAccess>(options=> options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductRepo,ProductRepo>();
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
