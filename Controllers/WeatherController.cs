using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mitten.Models;
using Mitten.Models.Repository;

namespace Mitten.Controllers
{
    public class WeatherController : ApiController
    {
	    private readonly IWeatherRepository _repository;

		public WeatherController(IWeatherRepository repository)
		{
			_repository = repository;
		}

        // GET api/weather
        public IEnumerable<WeatherCondition> Get()
        {
	        return _repository.GetAll();
        }

        // GET api/weather/5
        public HttpResponseMessage Get(int hours)
        {
	        var w = _repository.GetConditionByHours(-hours);

	        return w != null
						? Request.CreateResponse(HttpStatusCode.OK, w)
						: Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // POST api/weather
        public HttpResponseMessage Post([FromBody]WeatherCondition condition)
        {
	        var w = _repository.Insert(condition);

	        var response = Request.CreateResponse(HttpStatusCode.Created, w);
			response.Headers.Location = new Uri(Request.RequestUri, String.Format("weather/{0}", w.Id));

	        return response;
        }
    }
}
