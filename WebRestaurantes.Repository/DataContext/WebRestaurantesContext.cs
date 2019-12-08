using System;
using Microsoft.EntityFrameworkCore;
using WebRestaurantes.Domain;

namespace WebRestaurantes.Repository.DataContext
{
    public class WebRestaurantesContext : DbContext
    {
        public WebRestaurantesContext(DbContextOptions<WebRestaurantesContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<RestaurantAddress> RestaurantAddress { get; set; }

        public DbSet<RestaurantExtension> RestaurantExtension { get; set; }

        public DbSet<Domain.Domain> Domain { get; set; }

        public DbSet<DomainValue> DomainValue { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<State> State { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantExtension>()
            .HasOne(s => s.DomainInfo)
            .WithMany()
            .HasForeignKey(e => e.OptionId);            
        }
    }
}