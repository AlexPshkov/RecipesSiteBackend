using RecipesSiteBackend.Extensions;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.AddCustomDbContext();
builder.AddCustomAuth();

builder.AddStorageInfrastructure();
builder.AddServices();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapControllers();

app.Run(); 
