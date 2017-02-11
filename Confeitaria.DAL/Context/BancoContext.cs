using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;

namespace Confeitaria.DAL.Context
{
    public class BancoContext : DbContext
    {
        public BancoContext() : base("ConnDB") { }

        //public DbSet<Ingrediente> Ingredientes { get; set; }
        //public DbSet<Receita> Receitas { get; set; }
        //public DbSet<ReceitaItens> ReceitaItens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceitaItens>().ToTable("ReceitasItens");
            modelBuilder.Entity<Ingrediente>().ToTable("Ingredientes");            
            modelBuilder.Entity<Receita>().ToTable("Receitas");            
        }
    }
}
