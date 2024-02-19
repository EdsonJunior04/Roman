using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_romanWebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Projetos = new HashSet<Projeto>();
        }

        public short IdUsuario { get; set; }
        public byte? IdTipoUsuario { get; set; }

        [Required(ErrorMessage ="É necessário informar o e-mail!")]
        [EmailAddress(ErrorMessage = "Informe um endereço de e-mail válido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage ="É necessário informar a senha!")]
        public string Senha { get; set; }
        public string Nome { get; set; }

        public virtual Tipousuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
