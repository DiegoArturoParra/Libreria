using Libreria.Entidades.Models;
using Microsoft.EntityFrameworkCore;
namespace Libreria.Repositorio
{
    public class MapeoCore : Microsoft.EntityFrameworkCore.DbContext
    {
        public static string connectionString = "Server=.\\SQLEXPRESS; Database=libreria; Trusted_Connection=True";

        public DbSet<Autor> TablaAutores { get; set; }
        public DbSet<Libro> TablaLibros { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
