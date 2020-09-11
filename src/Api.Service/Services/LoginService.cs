using System;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Domain.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfiguration _tokenConfiguration;

        public LoginService(IUserRepository userRepository, SigningConfigurations signingConfigurations, TokenConfiguration tokenConfiguration)
        {
            _userRepository = userRepository;
            _signingConfigurations = signingConfigurations;
            _tokenConfiguration = tokenConfiguration;
        }

        // TODO: USANDO IDENTITY, TODA ESSA REGRA É SOBREESCRITA
        public async Task<object> FindByLogin(LoginDto loginDto)
        {
            var baseUser = new UserEntity();
            if (loginDto != null && !string.IsNullOrWhiteSpace(loginDto.Email))
            {
                baseUser = await _userRepository.FindByLogin(loginDto.Email);
                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, baseUser.Email),
                            new Claim(ClaimTypes.Role, "Read")
                        }
                    );

                    var createDate = DateTime.UtcNow;
                    var expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    var token = CreateToken(identity, createDate, expirationDate, handler);

                    return new 
                    {
                        authenticated = true,
                        created = createDate.ToString("yyyy-MM-dd HH:nn:ss"),
                        expiration = expirationDate.ToString("yyyy-MM-dd HH:nn:ss"),
                        accessToken = token,
                        userName = baseUser.Email,
                        message = "Usuário logado com sucesso"
                    };
                }
            }

            return null;
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            return handler.WriteToken(securityToken);
        }
    }
}
