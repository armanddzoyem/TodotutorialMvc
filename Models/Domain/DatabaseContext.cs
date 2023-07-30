using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;

namespace TodoTutorial.Models.Domain
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> opts) :base(opts)
		{ 
		}
		public DbSet<Person> Person { get; set; }
	}
}
