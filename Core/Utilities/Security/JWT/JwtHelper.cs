using System.Security.Claims;
using Core.Utilities.Security.Encryption;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Core.Extensions;
using Microsoft.Extensions.Configuration;
using Core.Entities.Сoncrete;
namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _expiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _expiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityToken = new JwtSecurityTokenHandler();
            var token = jwtSecurityToken.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _expiration,
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {

            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                issuer: tokenOptions.Issuer,
                expires: _expiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                audience: tokenOptions.Audience
                );
            return jwt;

        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;
        }
    }
}
