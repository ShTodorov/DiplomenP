using DiplomenP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiplomenP.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private readonly DbContextOptions<ApplicationDbContext> options;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.options = options;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .HasOne(c => c.OrderCart)
                .WithOne(o => o.Order)
                .HasForeignKey<Order>(k => k.OrderCartId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(c => c.OrderCustomer)
                .WithOne(o => o.Order)
                .HasForeignKey<Order>(k => k.OrderCustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.CartCustomer)
                .WithOne(ca => ca.Cart)
                .HasForeignKey<Cart>(k => k.CartCustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>()
                .HasMany(i => i.Items)
                .WithOne(c => c.Cart)
                .OnDelete(DeleteBehavior.Restrict);

            /*

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Customer)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            */

        }
        public void DetachAllEntities()
        {
            try
            {
                var changedEntries = ChangeTracker.Entries().ToList();
                foreach (var entry in changedEntries)
                {
                    entry.State = EntityState.Detached;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                //return;
            }

        }
        public ApplicationDbContext Clone()
        {
            return new ApplicationDbContext(options);
        }
    }
}
