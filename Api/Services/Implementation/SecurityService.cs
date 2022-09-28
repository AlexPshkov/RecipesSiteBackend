using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RecipesSiteBackend.Auth;
using RecipesSiteBackend.Storage.Entities.Implementation;

namespace RecipesSiteBackend.Services.Implementation;

public class SecurityService : ISecurityService
{

    private readonly AuthOptions _authOptions;

    public SecurityService( IOptions<AuthOptions> authOptions )
    {
        _authOptions = authOptions.Value;
    }

    public string HashPassword( string password )
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt();
        return BCrypt.Net.BCrypt.HashPassword( password, salt );
    }
    
    public bool VerifyPassword( string password, string passwordHash )
    {
        return BCrypt.Net.BCrypt.Verify( password, passwordHash );
    }
    
    public string GetToken( UserEntity userEntity )
    {
        var credentials = new SigningCredentials( _authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256 );

        var claims = new List<Claim>
        {
            new( JwtRegisteredClaimNames.Name, userEntity.Login ),
            new( JwtRegisteredClaimNames.Sub, userEntity.UserId.ToString() ),
            new ( "role", userEntity.Role.ToString())
        };

        var token = new JwtSecurityToken( 
            _authOptions.Issuer,
            _authOptions.Audience,
            claims,
            expires: DateTime.Now.AddSeconds( _authOptions.TokenLifetime ),
            signingCredentials: credentials );

        return new JwtSecurityTokenHandler().WriteToken( token );
    }
}