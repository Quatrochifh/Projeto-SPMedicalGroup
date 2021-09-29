using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_medical_webAPI.Domains;
using senai_medical_webAPI.Interfaces;
using senai_medical_webAPI.Repositories;
using senai_medical_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_medical_webAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    //http://localhost:5000/api/login

    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Logar(login.Email,login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou senha estão invalidos, Tente Novamente...");
                }

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email) ,
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdtipoUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdtipoUsuario.ToString()),
                new Claim("role", usuarioBuscado.IdtipoUsuario.ToString())
            };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("medicall-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        issuer: "medical.webApi",
                        audience: "medical.webApi",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: creds
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)

                });
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro); ;
            }
        }

    }
}
