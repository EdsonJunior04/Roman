using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_romanWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using senai_romanWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using senai_romanWebApi.Domains;

namespace senai_romanWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemaController : ControllerBase
    {

        private ITemaRepository _temaReposiory { get; set; }

        public TemaController()
        {
            _temaReposiory = new TemaRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Tema> lista = _temaReposiory.ListarTodos();

                return Ok(lista);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
               
            }
        }

    }
}
