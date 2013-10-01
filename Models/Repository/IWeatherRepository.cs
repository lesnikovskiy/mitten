using System.Collections.Generic;

namespace Mitten.Models.Repository
{
	public interface IWeatherRepository
	{
		IEnumerable<WeatherCondition> GetAll();
		WeatherCondition GetLastCondition();
		WeatherCondition GetConditionByHours(int hours);
		WeatherCondition GetConditionByDays(int days);
		WeatherCondition Insert(WeatherCondition condition);
	}
}