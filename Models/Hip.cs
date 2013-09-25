using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mitten.Models
{
	[Table("Hips")]
	public class Hip
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required")]
		[DataType(DataType.EmailAddress)]
		[StringLength(255)]
		[RegularExpression(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)", ErrorMessage = "Email is invalid")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[StringLength(18)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public string Key { get; set; }

		//[ForeignKey("Location")]
		//public int LocationId { get; set; }
		public virtual Location Location { get; set; }
	}
}