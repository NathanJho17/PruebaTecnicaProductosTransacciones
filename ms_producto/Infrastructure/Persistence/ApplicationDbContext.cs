using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

   public DbSet<Producto> Producto { get; set; }
    public DbSet<Categoria> Categoria { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Aquí puedes configurar las entidades, relaciones, etc.
       /*  modelBuilder.Entity<Producto>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Categoria>()
            .HasKey(c => c.Id); */
    }


}
