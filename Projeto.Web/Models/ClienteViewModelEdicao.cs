using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //mapeamentos..

namespace Projeto.Web.Models
{
    //classe de modelo para o formulario da página de Edicao
    public class ClienteViewModelEdicao
    {
        [Display(Name = "Código:")] //label
        public int IdCliente { get; set; } //campo

        [MinLength(3, ErrorMessage = "Erro. Nome deve ter no minimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Erro. Nome deve ter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        [Display(Name = "Nome do Cliente:")] //label
        public string Nome { get; set; } //campo

        [EmailAddress(ErrorMessage = "Erro. Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        [Display(Name = "Email:")] //label 
        public string Email { get; set; } //campo

        [Display(Name = "Data de Cadastro:")] //label
        public DateTime DataCadastro { get; set; } //campo
    }
}