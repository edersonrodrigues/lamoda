using Rgm.Domain.Entities.Entities;
using Rgm.Domain.Entities.Interfaces;
using Rgm.Repository.Context;
using Rgm.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;
using Rgm.Domain.Service.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rgm.BusinessEntities.Entities;

namespace Rgm.Domain.Service
{
    public class TokenService : IToken
    {
        SigningConfigurations _a;
        TokenConfigurations _b;
        IConfiguration _c;

        public TokenService(DataContext context, SigningConfigurations a, TokenConfigurations b, IConfiguration c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public TokenEntity GerarToken(string Login, string Senha, string appLogin, string appSenha, string appSecrect)
        {
            TokenEntity teste = null;
            if (Login == appLogin && Senha == appSenha)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(Login),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, Login),
                        }
                    );

                DateTime createDate = DateTime.UtcNow;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_b.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);
                teste = new TokenEntity { Id = 0, key = token };
            }
            return teste;
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _b.Issuer,
                Audience = _b.Audience,
                SigningCredentials = _a.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TokenEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TokenEntity> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<TokenEntity> Post(TokenEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TokenEntity> Put(TokenEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

