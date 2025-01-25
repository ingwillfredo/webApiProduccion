using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApiProduccion.Entities;
using Microsoft.Extensions.Configuration;

namespace WebApiProduccion.Data.Data
{
    public class PasswordEncryptor
    {
        private readonly IConfiguration _configuration;
        public PasswordEncryptor()
        {
        }
        public PasswordEncryptor(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // Método para encriptar la contraseña
        public string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la contraseña en un array de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertir el array de bytes en una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        
        // Método para verificar si una contraseña coincide con su hash
        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string hashOfEnteredPassword = EncryptPassword(enteredPassword);
            return StringComparer.OrdinalIgnoreCase.Compare(hashOfEnteredPassword, storedHash) == 0;
        }

        //Generar JWT

        public string generateJWT(LoginUser user)
        {
            //Crea Info user para token
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email!)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //Detalle token
            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}

