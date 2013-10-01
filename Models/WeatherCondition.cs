using System;
using System.ComponentModel.DataAnnotations;

namespace Mitten.Models
{
	public class WeatherCondition
	{
		[Key]
		public int Id { get; set; }

		[DataType(DataType.Date)]
		public DateTime ObservationTime { get; set; }
		[Required(ErrorMessage = "TempC is required")]
		
		public int TempC { get; set; }
		[Required(ErrorMessage = "Visibility is required")]
		public int Visibility { get; set; }
		[Required(ErrorMessage = "Cloudcover is required")]
		public int Cloudcover { get; set; }
		[Required(ErrorMessage = "Humidity is required")]
		public int Humidity { get; set; }
		[Required(ErrorMessage = "Pressure is required")]
		public int Pressure { get; set; }
		[Required(ErrorMessage = "WindspeedKmph is required")]
		public int WindspeedKmph { get; set; }
		[Required(ErrorMessage = "WeatherDesc is required")]
		public string WeatherDesc { get; set; }
		[Required(ErrorMessage = "Lat is required")]
		public double Lat { get; set; }
		[Required(ErrorMessage = "Lng is required")]
		public double Lng { get; set; }
		
		public virtual Hip Hip { get; set; }
	}
}