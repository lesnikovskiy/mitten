using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Mitten.Models
{
	public class MittenContext : DbContext
	{
		public MittenContext()
			: base("DefaultConnection")
		{

		}

		public DbSet<Hip> Hips { get; set; }
		public DbSet<Location> Location { get; set; }
		public DbSet<WeatherCondition> WeatherConditions { get; set; } 

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

			modelBuilder.Entity<Hip>()
						.HasRequired(h => h.Location)
						.WithMany()
						.WillCascadeOnDelete(false);
			modelBuilder.Entity<WeatherCondition>()
						.HasRequired(w => w.Hip)
						.WithMany()
						.WillCascadeOnDelete(false);

			base.OnModelCreating(modelBuilder);
		}
	}
}