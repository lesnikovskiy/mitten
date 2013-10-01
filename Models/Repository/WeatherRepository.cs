using System;
using System.Collections.Generic;
using System.Linq;

namespace Mitten.Models.Repository
{
	public class WeatherRepository : IWeatherRepository, IDisposable
	{
		private readonly MittenContext _context;

		public WeatherRepository()
		{
			_context = new MittenContext();
		}

		public IEnumerable<WeatherCondition> GetAll()
		{
			return _context.WeatherConditions;
		}

		public WeatherCondition GetLastCondition()
		{
			return _context.WeatherConditions.LastOrDefault();
		}

		public WeatherCondition GetConditionByHours(int hours)
		{
			return _context.WeatherConditions.LastOrDefault(w => w.ObservationTime == DateTime.UtcNow.AddHours(hours));
		}

		public WeatherCondition GetConditionByDays(int days)
		{
			return _context.WeatherConditions.LastOrDefault(w => w.ObservationTime == DateTime.UtcNow.AddDays(days));
		}

		public WeatherCondition Insert(WeatherCondition condition)
		{
			condition.ObservationTime = DateTime.UtcNow;
			_context.WeatherConditions.Add(condition);
			_context.SaveChanges();

			return condition;
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}