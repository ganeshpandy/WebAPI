
using Amazon.Entities.Data;
using Amazon.Entities.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Amazon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ProductContext>(optionsAction: options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("connectDB")));

            builder.Services.AddControllers();
            builder.Services.AddScoped<IOrder<User>, PatternRepository>();
            builder.Services.AddScoped<IOrder<Product>, PatternRepository>();
            builder.Services.AddScoped<IOrder<CartItem>, PatternRepository>();
            builder.Services.AddScoped<IOrder<Invoice>, PatternRepository>();


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
        }
    }
}
