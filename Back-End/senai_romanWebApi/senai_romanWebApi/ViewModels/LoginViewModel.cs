
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_romanWebApi.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "É necessário informar o e-mail!")]
        [EmailAddress(ErrorMessage = "Informe um endereço de e-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário informar a senha!")]
        public string Senha { get; set; }

    }
}
