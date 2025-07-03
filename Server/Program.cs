using dotenv.net;
using ZeDrive.Server.Data;
using ZeDrive.Server.Repositories;
using ZeDrive.Shared.Repositories;

internal class Program
{
    public static void Main(string[] arguments)
    {
        InitializeEnvironment();
        InitializeBuilder(arguments, out var builder);
        InitializeApplication(ref builder);
    }


    private static void InitializeEnvironment()
    {
        const EnvironmentVariableTarget process = EnvironmentVariableTarget.Process;
        DotEnv.Load();

        var env = DotEnv.Read();
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_URLS", env["APPLICATION_ENDPOINT"], process);
            Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", env["APPLICATION_ENVIRONMENT"], process);
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", env["APPLICATION_ENVIRONMENT"], process);
        }
    }

    private static void InitializeBuilder(string[] args, out WebApplicationBuilder builder)
    {
        builder = WebApplication.CreateBuilder(args);
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<DatabaseContext>();
            builder.Services.AddScoped<IPlanRepository, PlanRepository>();
            builder.Services.AddScoped<IStorageRepository, StorageRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
        }
    }

    private static void InitializeApplication(ref WebApplicationBuilder builder)
    {
        var app = builder.Build();
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapControllers();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.Run();
        }
    }
}