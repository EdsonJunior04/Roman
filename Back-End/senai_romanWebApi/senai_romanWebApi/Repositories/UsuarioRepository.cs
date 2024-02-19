using senai_romanWebApi.Context;
using senai_romanWebApi.Domains;
using senai_romanWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_romanWebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        RomanContext ctx = new RomanContext();

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
