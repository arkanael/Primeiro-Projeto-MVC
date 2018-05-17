using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //entityframework..
using Projeto.DAL.DataSource; //conexão..
using Projeto.Entities; //entidades

namespace Projeto.DAL.Persistence
{
    public class ClienteDal
    {
        //método para inserir um cliente na base de dados..
        public void Insert(Cliente c)
        {
            using (Conexao Con = new Conexao())
            {
                Con.Entry(c).State = EntityState.Added; //inserindo..
                Con.SaveChanges(); //executando..
            }
        }

        //método para atualizar um cliente na base de dados..
        public void Update(Cliente c)
        {
            using (Conexao Con = new Conexao())
            {
                Con.Entry(c).State = EntityState.Modified; //atualizando..
                Con.SaveChanges(); //executando..
            }
        }

        //método para excluir um cliente na base de dados..
        public void Delete(Cliente c)
        {
            using (Conexao Con = new Conexao())
            {
                Con.Entry(c).State = EntityState.Deleted; //excluindo..
                Con.SaveChanges();
            }
        }

        //método para retornar todos os clientes..
        public List<Cliente> FindAll()
        {
            using (Conexao Con = new Conexao())
            {
                //select * from Cliente
                return Con.Cliente.ToList();
            }
        }

        //método para retornar 1 cliente pelo id..
        public Cliente FindById(int id)
        {
            using (Conexao Con = new Conexao())
            {
                //select * from Cliente where IdCliente = ?
                return Con.Cliente.Find(id);
            }
        }
    }
}
