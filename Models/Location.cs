using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mitten.Models
{
	[Table("Location")]
	public class Location
	{
		[Key]
		public int Id { get; set; }
		[Column("Lat")]
		public double Lat { get; set; }
		[Column("Lng")]
		public double Lng { get; set; }
	}
}