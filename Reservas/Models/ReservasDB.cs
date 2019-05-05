using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Reservas.Models
{
    public class ReservasDB : DbContext
    {

        // Identificador ReservasDB

        public ReservasDB() : base("ReservasDBConnectionString") { }

        // vamos colocar, aqui, as instruções relativas às tabelas do 'negócio'
        // descrever os nomes das tabelas na Base de Dados
        public virtual DbSet<Reservas> Reservas { get; set; } // tabela Multas
        public virtual DbSet<Clientes> Clientes { get; set; } // tabela Condutores
        public virtual DbSet<Tecnicos> Tecnicos { get; set; } // tabela Agentes
        public virtual DbSet<Viaturas> Viaturas { get; set; } // tabela Viaturas

        //Metódo a ser executado no inicio da criação do Modelo, pre construido na especificação da entity framework
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Elimina a convenção de atribuir automaticamente o 'onDeleteCascade' nas FK's
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}