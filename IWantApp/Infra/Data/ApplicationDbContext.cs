using IWantApp.Domain.Products;
using Microsoft.EntityFrameworkCore;
namespace IWantApp.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categoties { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    // Criacao das tabelas
    protected override void OnModelCreating(ModelBuilder buider)
    {
        // configurar determinada coluna da tabela
        buider.Entity<Product>()
            .Property(p => p.Name).IsRequired();

        buider.Entity<Product>()
            .Property(p => p.Description).HasMaxLength(255);

        buider.Entity<Category>()
            .Property(c => c.Name).IsRequired();
    }

    // Configura as colunas das tabelas
    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        // fara com que a propriedade do tipo string tenha 100 caracteres
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }

}
