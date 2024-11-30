using DALWHOLEPOS.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALWHOLEPOS.EF
{
    public class Context : DbContext
    {
        public DbSet<Business> Businesses { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }    

        public DbSet<LoginToken> LoginTokens { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<QuickSell> QuickSells { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Sell> Sells { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Transfer> Transfers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ... existing code ...

                modelBuilder.Entity<Supplier>()
                    .HasRequired(s => s.Business)
                    .WithMany()
                    .WillCascadeOnDelete(false);

                modelBuilder.Entity<QuickSell>()
            .HasRequired(q => q.Customer)
            .WithMany()
            .WillCascadeOnDelete(false);

                modelBuilder.Entity<QuickSell>()
           .HasRequired(q => q.Invoice)
           .WithMany()
           .WillCascadeOnDelete(false);

                modelBuilder.Entity<Sell>()
           .HasRequired(s => s.Customer)
           .WithMany()
           .WillCascadeOnDelete(false);

                modelBuilder.Entity<Sell>()
            .HasRequired(s => s.Invoice)
            .WithMany()
            .WillCascadeOnDelete(false);

                modelBuilder.Entity<Sell>()
           .HasRequired(s => s.Product)
           .WithMany()
           .WillCascadeOnDelete(false);


            modelBuilder.Entity<Transfer>()
                .HasRequired(t => t.Product)
                .WithMany()
                .HasForeignKey(t => t.ProductId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transfer>()
                .HasRequired(t => t.FromBusiness)
                .WithMany()
                .HasForeignKey(t => t.FromBusinessId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transfer>()
                .HasRequired(t => t.ToBusiness)
                .WithMany()
                .HasForeignKey(t => t.ToBusinessId)
                .WillCascadeOnDelete(false);
        }
    }
}
