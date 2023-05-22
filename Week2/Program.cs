
using Microsoft.EntityFrameworkCore;
using Week2.Data;

namespace Week2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            string connectionString = string.Empty;

            if (args.Length > 0)
            {
                connectionString = args[0];
            }
            else
            {
                var env = builder.Configuration.GetValue<string>("Environment");

                switch(env?.ToLower())
                {
                    case "dev":
                        connectionString = "dev";
                        break;
                    case "prod":
                        connectionString = "prod";
                        break;
                    case "test":
                        connectionString = "test";
                        break;
                    default:
                        throw new Exception("Environment not set");
                }
            }

            builder.Services.AddDbContext<BusinessContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString(connectionString));
            });

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
        }
    }
}