using Cinema.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataAccess.Sql
{
    /// <summary>
    /// Entity Framework context class for accessing
    /// <see cref="Movie"/> instances in the underlying
    /// database.
    /// </summary>
    public class MovieContext : DbContext
    {
        /// <summary>
        /// Provides IQueryable-access to the <see cref="Movie"/>
        /// instances in the underlying table.
        /// </summary>
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// Configures Entity Framework to use the SQL Express database.
        /// </summary>
        /// <param name="optionsBuilder">Options builder for configuration Entity Framework with your choices.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=90322;Trusted_Connection=True;");
        }
    }
}
