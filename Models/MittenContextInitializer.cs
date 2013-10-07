using System.Data.Entity;

namespace Mitten.Models
{
	public class MittenContextInitializer : DropCreateDatabaseIfModelChanges<MittenContext>
	{
		protected override void Seed(MittenContext context)
		{
			// TODO: Add migration script here
			base.Seed(context);
		}
	}
}