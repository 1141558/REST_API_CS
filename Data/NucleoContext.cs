using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using nucleocs.Models;
using nucleocs.Models.Strategy;

namespace nucleocs.Data
{
    public class NucleoContext : DbContext
    {
        public NucleoContext(DbContextOptions<NucleoContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Finishing> Finishings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        public DbSet<MaterialFinishing> MaterialFinishings { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<Aggregation> Aggregations { get; set; }
        public DbSet<AlgoritmStrategy> Algoritms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<OccupationAlgoritm>();
            modelBuilder.Entity<DimensionAlgoritm>();
            modelBuilder.Entity<MaterialAlgoritm>();

            //-----------ProductMaterial
            modelBuilder.Entity<ProductMaterial>()
                .HasKey(t => new { t.ProductId, t.MaterialId });

             modelBuilder.Entity<ProductMaterial>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.ProductMaterials)
                .HasForeignKey(bc => bc.ProductId);

             modelBuilder.Entity<ProductMaterial>()
                .HasOne(bc => bc.Material)
                .WithMany(b => b.ProductMaterials)
                .HasForeignKey(bc => bc.MaterialId);
            
            //-----------MaterialFinishings
            modelBuilder.Entity<MaterialFinishing>()
                .HasKey(t => new {t.MaterialId, t.FinishingId});

            modelBuilder.Entity<MaterialFinishing>()
                .HasOne(bc => bc.Material)
                .WithMany(b => b.MaterialFinishings)
                .HasForeignKey(bc => bc.MaterialId);

            modelBuilder.Entity<MaterialFinishing>()
                .HasOne(bc => bc.Finishing)
                .WithMany(c => c.MaterialFinishings)
                .HasForeignKey(bc => bc.FinishingId);

            //-------------Aggregation Products

            modelBuilder.Entity<Aggregation>()
               .HasKey(t => new {t.ProductFatherId, t.ProductSonId});

            modelBuilder.Entity<Aggregation>()
            .HasOne(f => f.ProductF)
            .WithMany(s => s.ProdSon)
            .HasForeignKey(f => f.ProductFatherId);

            //-------------Restrictions

             modelBuilder.Entity<Restriction>()
            .HasOne(e => e.Aggregation)
            .WithMany(c => c.Restrictions);        

        }
    }
}