using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using employeeAPI.Model;
using Microsoft.Extensions.Options;

namespace employeeAPI
{
    public  class generateJWTtoken
    {
		
	
        public  string GenerateToken(login login)
		{
			var mySecret = "this is my custom Secret key for authentication";
			var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));
			var myIssuer = "https://localhost:44346/";
			var myAudience = "https://localhost:44346/";
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
			       new Claim(ClaimTypes.NameIdentifier, login.email.ToString()),

				   new Claim(ClaimTypes.NameIdentifier, login.password.ToString()),
				}),
				Expires = DateTime.UtcNow.AddDays(1),
				Issuer = myIssuer,
				Audience = myAudience,
				SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
