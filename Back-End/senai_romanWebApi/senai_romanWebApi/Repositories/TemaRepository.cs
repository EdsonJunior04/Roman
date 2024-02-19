using senai_romanWebApi.Context;
using senai_romanWebApi.Domains;
using senai_romanWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_romanWebApi.Repositories
{
    public class TemaRepository : ITemaRepository
    {
        RomanContext ctx = new RomanContext();

        public List<Tema> ListarTodos()
        {
            return ctx.Temas
                .Select(t => new Tema()
                {
                    Titulo = t.Titulo,
                    IdTema = t.IdTema
                })
                .ToList();
        }
    }
}
