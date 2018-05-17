using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; //connectionstring..
using System.Data.Entity; //entityframework..
using Projeto.DAL.Configurations; //mapeamentos..
using Projeto.Entities; //entidades

namespace Projeto.DAL.DataSource
{
    //Regra 1) Herdar DbContext
    public class Conexao : DbContext
    {
        //Regra 2) Construtor que envie a connectionstring para o DbContext..
        public Conexao()
            : base(ConfigurationManager.ConnectionStrings["aula"].ConnectionString)
        {

        }

        //Regra 3) Sobrescrever o método OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //definir cada classe de mapeamento..
            modelBuilder.Configurations.Add(new ClienteConfiguration());
        }

        //Regra 4) Declarar um DbSet (CRUD) para cada entidade..
        public DbSet<Cliente> Cliente { get; set; }
    }
}
