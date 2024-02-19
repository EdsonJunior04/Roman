using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_romanWebApi.Domains;
using senai_romanWebApi.Interfaces;
using senai_romanWebApi.Repositories;
using senai_romanWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_romanWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
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
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("E-mail ou senha inváldos!");
                }

                var minhasClaims = new[]
               {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                    new Claim("role",usuarioBuscado.IdTipoUsuario.ToString())

                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("roman-lima-chave"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                        issuer: "Roman.webAPI",
                        audience: "Roman.webAPI",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
