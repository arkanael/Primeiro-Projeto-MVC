using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Web.Models; //camada de modelo..
using Projeto.Entities; //entidades..
using Projeto.DAL.Persistence; //acesso a dados..

namespace Projeto.Web.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente/Cadastro
        [HttpGet] //default..
        public ActionResult Cadastro()
        {
            return View(); //abrir uma página..
        }
        
        // POST: Cliente/Cadastro
        [HttpPost] //receber o submit do formulário..
        public ActionResult Cadastro(ClienteViewModelCadastro model)
        {
            //verificar se a model passou nas validações..
            if(ModelState.IsValid) //não deu erro de validação?
            {
                try
                {
                    Cliente c = new Cliente(); //entidade..
                    c.Nome  = model.Nome;
                    c.Email = model.Email;
                    c.DataCadastro = DateTime.Now;

                    ClienteDal d = new ClienteDal(); //persistencia..
                    d.Insert(c); //gravando na base de dados..

                    ViewBag.Mensagem = "Cliente " + c.Nome + ", cadastrado com sucesso.";
                    ModelState.Clear(); //limpar os dados da model (formulario)
                }
                catch(Exception e)
                {
                    //imprimir mensagem de erro..
                    ViewBag.Mensagem = e.Message;
                }
            }            

            return View(); //abrir uma página..
        }


        // GET: Cliente/Consulta
        [HttpGet] //default..
        public ActionResult Consulta()
        {
            //declarar uma lista da classe de modelo..
            List<ClienteViewModelConsulta> lista = new List<ClienteViewModelConsulta>();

            try
            {
                ClienteDal d = new ClienteDal(); //persistencia..
                foreach(Cliente c in d.FindAll()) //varrendo todos os clientes..
                {
                    ClienteViewModelConsulta model = new ClienteViewModelConsulta();
                    model.IdCliente = c.IdCliente;
                    model.Nome = c.Nome;
                    model.Email = c.Email;
                    model.DataCadastro = c.DataCadastro;

                    lista.Add(model); //adicionar dentro da lista..
                }
            }
            catch(Exception e)
            {
                //exibir mensagem de erro..
                ViewBag.Mensagem = e.Message;
            }

            //enviar a lista para a página..
            return View(lista); //abrir uma página..
        }


        //método para abrir a página de Detalhes
        // GET: /Cliente/Detalhes/id
        public ActionResult Detalhes(int id)
        {
            //classe de modelo..
            ClienteViewModelConsulta model = new ClienteViewModelConsulta();

            try
            {
                //acessar a base de dados e buscar 1 cliente pelo id..
                ClienteDal d = new ClienteDal(); //persistencia..
                Cliente c = d.FindById(id); //buscando 1 cliente pelo id..

                //transferir os dados do cliente para a model..
                model.IdCliente = c.IdCliente;
                model.Nome = c.Nome;
                model.Email = c.Email;
                model.DataCadastro = c.DataCadastro;
            }
            catch(Exception e)
            {
                //exibir mensagem de erro..
                ViewBag.Mensagem = e.Message;
            }

            //enviando a model para a página..
            return View(model);
        }


        //método para abrir a página de Edicao
        // GET: /Cliente/Edicao/id
        public ActionResult Edicao(int id)
        {
            //classe de modelo..
            ClienteViewModelEdicao model = new ClienteViewModelEdicao();
            
            try
            {
                ClienteDal d = new ClienteDal(); //persistencia..
                Cliente c = d.FindById(id); //buscando 1 cliente pelo id..

                //transferir os dados da entidade para a model..
                model.IdCliente = c.IdCliente;
                model.Nome = c.Nome;
                model.Email = c.Email;
                model.DataCadastro = c.DataCadastro;
            }
            catch(Exception e)
            {
                //imprimir mensagem de erro..
                ViewBag.Mensagem = e.Message;
            }

            //enviando a classe de modelo para a página..
            return View(model);
        }


        //método para receber o envio dos dados da página de Edição..
        [HttpPost] //receber uma requisição do tipo POST
        public ActionResult Edicao(ClienteViewModelEdicao model)
        {
            //verificar se os dados da model passaram nas validações..
            if(ModelState.IsValid)
            {
                try
                {
                    Cliente c = new Cliente(); //entidade..
                    c.IdCliente = model.IdCliente;
                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.DataCadastro = model.DataCadastro;

                    //classe de persistencia..
                    ClienteDal d = new ClienteDal(); //persistencia..
                    d.Update(c); //atualizando..

                    ViewBag.Mensagem = "Cliente " + c.Nome + ", atualizado com sucesso.";
                }
                catch(Exception e)
                {
                    //exibir mensagem de erro..
                    ViewBag.Mensagem = e.Message;
                }
            }

            return View();
        }


        //Ação para excluir um cliente selecionado..
        // GET: /Cliente/Exclusao/id
        public ActionResult Exclusao(int id)
        {
            try
            {
                ClienteDal d = new ClienteDal(); //persistencia..
                //buscar o cliente pelo id..
                Cliente c = d.FindById(id);
                //excluir o cliente
                d.Delete(c);

                ViewBag.Mensagem = "Cliente " + c.Nome + ", excluido com sucesso.";
            }
            catch(Exception e)
            {
                //imprimir mensagem de erro..
                ViewBag.Mensagem = e.Message;
            }

            return View();
        }

        // GET: Cliente/ConsultarPorNome
        [HttpGet] //default..
        public ActionResult ConsultaPorNome()
        {
            return View(); //abrir uma página..
        }
    }
}