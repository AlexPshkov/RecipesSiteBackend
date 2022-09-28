using RecipesSiteBackend.Extensions;

namespace RecipesSiteBackend;

public static class Program
{
    public static void Main( string[] args )
    {
        var applicationBuilder = WebApplication.CreateBuilder( args );

        applicationBuilder.AddCustomCorsPolicy( "AllowAll" );
        
        applicationBuilder.Services.AddControllers();
        applicationBuilder.Services.AddEndpointsApiExplorer();

        applicationBuilder.AddCustomDbContext();
        applicationBuilder.AddCustomAuth();

        applicationBuilder.AddStorageInfrastructure();
        applicationBuilder.AddServices();

        BuildAndRun( applicationBuilder );
    }

    private static void BuildAndRun( WebApplicationBuilder applicationBuilder )
    {
        var app = applicationBuilder.Build();

        app.UseCors( "AllowAll" );
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseStaticFiles();

        app.MapControllers();

        app.Run();
    }
}