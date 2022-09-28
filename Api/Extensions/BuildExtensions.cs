using System.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RecipesSiteBackend.Auth;
using RecipesSiteBackend.Services;
using RecipesSiteBackend.Services.Implementation;
using RecipesSiteBackend.Storage.Repositories;
using RecipesSiteBackend.Storage.Repositories.Implementation;
using RecipesSiteBackend.Storage.Repositories.Interfaces;
using RecipesSiteBackend.Storage.UoW;

namespace RecipesSiteBackend.Extensions;

public static class BuildServiceExtensions
{

    /**
     * <exception cref="NoNullAllowedException"></exception>
     */
    public static void AddCustomDbContext( this WebApplicationBuilder builder )
    {
        var connectionString = builder.Configuration.GetValue<string>( "MySQLConnection" ) ?? 
                               throw new NoNullAllowedException("Please init MySQLConnection in conf file");
        builder.Services.AddDbContext<DataBaseContext>( c =>
        {
            c.UseMySql( connectionString, ServerVersion.AutoDetect( connectionString ),
                o => o.UseQuerySplittingBehavior( QuerySplittingBehavior.SplitQuery ) );
        } );
    }

    public static void AddCustomCorsPolicy( this WebApplicationBuilder builder, string policyName )
    {
        builder.Services.AddCors( options =>
        {
            options.AddPolicy( policyName,
                policyBuilder => policyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );
        } );
    }
    
    public static void AddCustomAuth( this WebApplicationBuilder builder)
    {
        var authOptions = builder.Configuration.GetSection( "Auth" ).Get<AuthOptions>();
        builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection("Auth"));
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = authOptions.Issuer,
                ValidAudience = authOptions.Audience,
                IssuerSigningKey = authOptions.GetSymmetricSecurityKey()
            };
        });
    } 
    
    public static void AddServices( this WebApplicationBuilder builder )
    {
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IRecipeService, RecipeService>();
        builder.Services.AddScoped<ISecurityService, SecurityService>();
        builder.Services.AddScoped<IImageService, ImageService>();
    }    
    
    public static void AddStorageInfrastructure( this WebApplicationBuilder builder )
    {
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
        builder.Services.AddScoped<ITagRepository, TagRepository>();
    }
}