
namespace MiddleWare
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync($"Before Request {Environment.NewLine}");
                    await next();
                    await context.Response.WriteAsync($"After Request {Environment.NewLine}");
                });

                app.Run(async context =>
                {
                    await context.Response.WriteAsync($"Hello Readers!{Environment.NewLine}");
                });
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
