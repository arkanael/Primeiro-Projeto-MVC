using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //mapeamento..

namespace Projeto.Web.Models
{
    //classe para modelar os dados que serão exibidos
    //na página de consulta de clientes..
    public class ClienteViewModelConsulta
    {
        [Display(Name = "Código")] //titulo
        public int IdCliente { get; set; }

        [Display(Name = "Nome do Cliente")] //titulo
        public string Nome { get; set; }

        [Display(Name = "Endereço de Email")] //titulo
        public string Email { get; set; }

        [Display(Name = "Data de Cadastro")] //titulo
        public DateTime DataCadastro { get; set; }
    }
}