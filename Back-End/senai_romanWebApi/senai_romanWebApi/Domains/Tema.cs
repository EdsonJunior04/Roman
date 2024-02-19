using System;
using System.Collections.Generic;

#nullable disable

namespace senai_romanWebApi.Domains
{
    public partial class Tema
    {
        public Tema()
        {
            Projetos = new HashSet<Projeto>();
        }

        public byte IdTema { get; set; }
        public string Titulo { get; set; }

        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
