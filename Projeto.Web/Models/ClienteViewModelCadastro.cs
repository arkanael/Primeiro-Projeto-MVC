using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //mapeamento..

namespace Projeto.Web.Models
{
    //classe para modelar os dados da página de cadastro..
    public class ClienteViewModelCadastro
    {   
        [MinLength(3, ErrorMessage = "Erro. Nome deve ter no minimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Erro. Nome deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        [Display(Name = "Nome do Cliente:")] //label..
        public string Nome { get; set; } //campo

        [EmailAddress(ErrorMessage = "Erro. Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        [Display(Name = "Email do Cliente:")] //label..
        public string Email { get; set; } //campo
    }
    
}