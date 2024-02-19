using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_romanWebApi.Domains
{
    public partial class Projeto
    {
        public short IdProjeto { get; set; }        
        public short? IdUsuario { get; set; }
        [Required(ErrorMessage = "Necessário informar o tema!")]
        public byte? IdTema { get; set; }
        [Required(ErrorMessage = "Necessário informar um titulo!")]
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public virtual Tema IdTemaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
