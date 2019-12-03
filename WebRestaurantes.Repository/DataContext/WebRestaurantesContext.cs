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

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     //modelBuilder.Entity<
        // }
    }
}