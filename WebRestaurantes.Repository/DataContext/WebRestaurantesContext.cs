using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebRestaurantes.Domain;
using WebRestaurantes.Domain.Identity;

namespace WebRestaurantes.Repository.DataContext
{
    public class WebRestaurantesContext : IdentityDbContext<Domain.Identity.User, Role, int,
                                                    IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                    IdentityRoleClaim<int>, IdentityUserToken<int>>
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

        public DbSet<Scheduling> Scheduling { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole => 
                {
                    userRole.HasKey(ur => new {ur.UserId, ur.RoleId});

                    userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();
                    
                    userRole.HasOne(ur => ur.User)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
                }
            );
            
            modelBuilder.Entity<RestaurantExtension>()
            .HasOne(s => s.DomainValue)
            .WithMany()
            .HasForeignKey(e => e.DomainValueId)            
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}