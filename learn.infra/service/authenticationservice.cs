using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace learn.infra.service
{
    public class authenticationservice : IAuthenticationservice
    {
        private readonly IAuthentication authentication;
        public authenticationservice(IAuthentication authentication)
        {
            this.authentication = authentication;
        }
        public string Authentication_jwt(login_api login)
        {
            var res = authentication.auth(login);
            if (res == null)
            {
                return null;
            }
            else
            {
                var tokenhandler = new JwtSecurityTokenHandler();
                //"[SECRET Used To Sign And Verify Jwt Token,It can be any string]"
                var tokenkey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]");
                var tokenDescirptor = new SecurityTokenDescriptor
                {

                    Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                    new Claim(ClaimTypes.Email, res.email),
                    new Claim(ClaimTypes.Role,res.rolename),
                    new Claim(ClaimTypes.Name, res.password.ToString())

                    }
                    ),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
                };
                var generatetoken = tokenhandler.CreateToken(tokenDescirptor);
                return tokenhandler.WriteToken(generatetoken);
            }
        }
    }
}
