using Microsoft.EntityFrameworkCore;
using Tiquetes.Naviera.Models;

namespace Tiquetes.Naviera.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
        //    var connection = "Server=tiquetesnaviera.cff7thc9uyue.us-east-1.rds.amazonaws.com;Port=3306;Database=TiquetesNaviera;Uid=admintickets;Pwd=Temporal01!;";
        //    optionsBuilder.UseMySql(connection, serverVersion);
        //}

        public DbSet<Tiquete> Tiquetes { get; set; }
    }
}
