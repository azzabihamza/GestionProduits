using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

using Domain.Entities;


namespace Data
{
    public class GestionProduitsContext : DbContext
    {
        public GestionProduitsContext()
        {
            //this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer(@"Server=localhost;Database=GestionProduitDb;Trusted_Connection=True;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Facture> Factures { get; set; }
    }
}
