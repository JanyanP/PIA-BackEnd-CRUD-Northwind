using Microsoft.AspNetCore.Authorization;    
using Microsoft.AspNetCore.Mvc;    
using Microsoft.Extensions.Configuration;    
using Microsoft.IdentityModel.Tokens;    
using System;    
using System.IdentityModel.Tokens.Jwt;    
using System.Security.Claims;    
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseFirstDWB.Models;
using System.Security.Cryptography;

namespace JWTAuthentication.Controllers
{
    //Controlador del JWT para logearse, espera un usuario y contraseña
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        //Si el método AuthenticateUser regresa el user model, se genera un nuevo Token
        private string GenerateJSONWebToken(LoginModel loginInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, loginInfo.Username),
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),  //Expiración de dos horas
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token); //Se devuelve el Token generado
        }

        //Método que valida las credenciales del usuario y regresa al UserModel
        private LoginModel AuthenticateUser(LoginModel login)
        {
            //Username: Juan 123
            //Password: Password123
            //Hashed Password: LVJc4+gPYqzez3o1Oo2eD9QNEN/foR+uTaGG93BpVyjTOSmE
            //Si el usuario es Juan, se cargan sus datos
            if (login.Username == "Juan 123")
            {
                string savedPasswordHash = "LVJc4+gPYqzez3o1Oo2eD9QNEN/foR+uTaGG93BpVyjTOSmE";
                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                var pbkdf2 = new Rfc2898DeriveBytes(login.HashedPassword, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);
                for (int i = 0; i < 20; i++)
                    if (hashBytes[i + 16] != hash[i])
                        return null;
                return login;
            }
            return null;
        }
    }
}