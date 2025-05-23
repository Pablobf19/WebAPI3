using Microsoft.EntityFrameworkCore;
using ShoppingAPI.DAL.Entities;

namespace ShoppingAPI.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }
        //este metodo que es propio de ef core me sirve para configurar unos indices de cada campo de una tabla de bd
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); //aqui creo indice de campo name
        }

        #region DbSets

        public DbSet<Country> Countries { get; set; }
       
        #endregion
    }
}
