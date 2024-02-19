using senai_romanWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_romanWebApi.Interfaces
{
    interface ITemaRepository
    {

        /// <summary>
        /// Listar todos os temas
        /// </summary>
        /// <returns></returns>
        List<Tema> ListarTodos();

    }
}
