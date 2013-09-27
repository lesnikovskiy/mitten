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
    public class HipController : ApiController
    {
	    private readonly IHipRepository _repository;

		public HipController(IHipRepository hipRepository)
		{
			_repository = hipRepository;
		}

		// GET api/hip
		public IEnumerable<Hip> Get()
		{
			return _repository.GetAll();
		}

		// GET api/hip/5
		public HttpResponseMessage Get(int id)
		{
			var hip = _repository.Get(id);

			return hip != null
						? Request.CreateResponse(HttpStatusCode.OK, hip)
						: Request.CreateResponse(HttpStatusCode.NotFound);
		}

		// POST api/hip
		public HttpResponseMessage Post(Hip hip)
		{
			var h = _repository.Insert(hip);

			var response = Request.CreateResponse(HttpStatusCode.Created, hip);
			response.Headers.Location = new Uri(Request.RequestUri, String.Format("hip/{0}", h.Id));

			return response;
		}

		// PUT api/hip
		public HttpResponseMessage Put(Hip hip)
		{
			var nHip = _repository.Update(hip);

			var response = Request.CreateResponse(HttpStatusCode.Created, nHip);
			response.Headers.Location = new Uri(Request.RequestUri, String.Format("hip/{0}", nHip.Id));

			return response;
		}

		// DELETE api/hip/5
		public HttpResponseMessage Delete(int id)
		{
			_repository.Delete(id);

			return Request.CreateResponse(HttpStatusCode.NoContent);
		}
    }
}
