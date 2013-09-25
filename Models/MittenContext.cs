using System.Data.Entity;

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

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Hip>()
						.HasRequired(h => h.Location)
						.WithMany()
						.WillCascadeOnDelete(true);

			base.OnModelCreating(modelBuilder);
		}
	}
}