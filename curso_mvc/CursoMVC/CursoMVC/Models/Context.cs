﻿using Microsoft.EntityFrameworkCore;

namespace CursoMVC.Models
{
    public class Context : DbContext
    {

        public Context(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=Cursomvc;Integrated Security=True");
        //}

        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
