
using Contracts;
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace HotelManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ContextDb>(optionsAction: options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("connectDB")));

            builder.Services.AddControllers();
            builder.Services.AddScoped<ICustomer, HotelRepository>();
            builder.Services.AddScoped<IHotel, HotelRepository>();
            builder.Services.AddScoped<IRoom, HotelRepository>();
            builder.Services.AddScoped<ICheckOut, HotelRepository>();
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
