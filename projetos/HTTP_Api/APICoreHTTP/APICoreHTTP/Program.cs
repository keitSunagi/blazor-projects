
using APICoreHTTP.Data;
using APICoreHTTP.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace APICoreHTTP
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
            //Conexão com o banco
            var connectionString = builder.Configuration.GetConnectionString("PostGressSQLString");
            builder.Services.AddDbContext<MusicAppContext>(options => options.UseNpgsql(connectionString));

            //Injeção de Dependência Scoped
            builder.Services.AddScoped<IMusicService, MusicService>();

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
