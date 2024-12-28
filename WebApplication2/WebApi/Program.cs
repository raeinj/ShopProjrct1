using System.Reflection;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication2.Application.DTOs;
using WebApplication2.Application.Interface;
using WebApplication2.Application.Services;
using WebApplication2.Domain.InterFaces;
using WebApplication2.Domain.Models;
using WebApplication2.Infrastructure.Context;
using WebApplication2.Infrastructure.Repossittories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//.Services.AddAutoMapper(typeof(Program)); // eror
builder.Services.AddDbContext<AppDbContext>(
    option => 
        option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository , ProductRepository>();

/*builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(
        option =>
        {
            option.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateAudience = true,
                ValidIssuer = builder.Configuration["Authentication:Issuer"],
                ValidAudience = builder.Configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
            };
        }
    );
*/



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
   