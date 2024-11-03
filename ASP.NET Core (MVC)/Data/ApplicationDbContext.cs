using ASP.NET_Core__MVC_.Models;
using Microsoft.EntityFrameworkCore;


namespace ASP.NET_Core__MVC_.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(18,2)"); // Definindo a precisão como 18 dígitos, com 2 casas decimais.

            modelBuilder.Entity<Income>()
                .Property(i => i.Amount)
                .HasColumnType("decimal(18,2)"); // Definindo a precisão como 18 dígitos, com 2 casas decimais.

            base.OnModelCreating(modelBuilder);
        }


    }
}
