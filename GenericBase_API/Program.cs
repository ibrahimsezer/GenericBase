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

//Add Repo
builder.Services.AddScoped<IUserRepo,UserRepo>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();

//Add BusinessService
builder.Services.AddScoped<IUserBusinessService,UserBusinessService>();
builder.Services.AddScoped<IProductBusinessService, ProductBusinessService>();

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
