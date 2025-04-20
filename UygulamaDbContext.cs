using RandevuSistemi.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models;

namespace RandevuSistemi.Data
{
    public class UygulamaDbContext : DbContext
    {
        public DbSet<Randevu> Randevular { get; set; }

        // Parametreli constructor ekleyin
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options)
            : base(options) // DbContextOptions'u base sınıfa iletirsiniz
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Randevu>()
                .HasKey(r => r.RandevuId);

            modelBuilder.Entity<Randevu>()
                .Property(r => r.RandevuId)
                .ValueGeneratedOnAdd(); // Otomatik artan olarak ayarla
        }



    }

}
