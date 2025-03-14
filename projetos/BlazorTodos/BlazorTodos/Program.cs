using BlazorTodos.Components;
using BlazorTodos.Data;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using BlazorTodos.Data;

namespace BlazorTodos;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddMudServices();

        //Pega a conection string lá do appsettings.json por favor e usa pra conectar por gentileza.
        var _connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<AppTodoContext>(options => options.UseNpgsql(_connectionString));

        //Adicionando a injeção de dependência
        builder.Services.AddScoped<ITodoService, TodoService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
