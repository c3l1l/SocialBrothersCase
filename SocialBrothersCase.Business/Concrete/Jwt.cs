using Microsoft.IdentityModel.Tokens;
using SocialBrothersCase.Business.Abstract;
using SocialBrothersCase.DataAccess;
using SocialBrothersCase.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialBrothersCase.Business.Concrete
{
    public class Jwt:IJwt
    {
        private string _key;
        
        public Jwt(string key)
        {
            _key = key;
           
        }
        public string Authenticate(string username, string password)
        {
            string strToken = null;
            ApplicationDBContext db = new ApplicationDBContext();
            User user = db.Users.Where(u => u.Name == username && u.Password == password).SingleOrDefault();
            if (user != null)
            {
                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var bytKey = Encoding.UTF8.GetBytes(_key); 
                var date= DateTime.UtcNow;
                var tokenDesc = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, username) }),
                    // Expires = DateTime.Now.AddHours(1), 
                    Expires = date.AddMinutes(10),
                    NotBefore = date,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytKey), SecurityAlgorithms.HmacSha256Signature) 
                };

                var token = tokenHandler.CreateToken(tokenDesc); //Token descriptor bilgileri kullanilarak Token burada olusturulur.
                strToken = tokenHandler.WriteToken(token);
            }

            return strToken;
        }
    }
}
