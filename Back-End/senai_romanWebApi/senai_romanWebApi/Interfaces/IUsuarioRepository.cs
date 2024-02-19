using senai_romanWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_romanWebApi.Interfaces
{
    interface IUsuarioRepository 
    {

        Usuario Login(string email, string senha);

    }
}
