using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_roman_WebApi.Interfaces;
using senai_roman_WebApi.Repositories;
using senai_romanWebApi.Domains;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_romanWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private IProjetoRepository _projetoRepository { get; set; }

        public ProjetosController ()
        {
            _projetoRepository = new ProjetoRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Projeto> lista = _projetoRepository.ListarTodos();

                return Ok(lista);   
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(Projeto novoProjeto)
        {
            try
            {
                novoProjeto.IdUsuario = Convert.ToInt16(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _projetoRepository.Cadastrar(novoProjeto);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
