using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration; //mapeamento..
using Projeto.Entities; //entidades..

namespace Projeto.DAL.Configurations
{
    //Classe de mapeamento para a entidade Cliente..
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        //construtor..
        public ClienteConfiguration()
        {
            //nome da tabela..
            ToTable("CLIENTE");

            //chave primária..
            HasKey(c => c.IdCliente);

            //demais propriedades..
            Property(c => c.IdCliente)
                .HasColumnName("IDCLIENTE");

            Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.DataCadastro)
                .HasColumnName("DATACADASTRO")
                .IsRequired();
        }
    }
}
