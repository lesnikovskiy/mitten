using System.Data.Entity;

namespace Mitten.Models
{
	public class MittenContextInitializer : DropCreateDatabaseIfModelChanges<MittenContext>
	{
		protected override void Seed(MittenContext context)
		{
			// TODO: Write migration here
			base.Seed(context);
		}
	}
}