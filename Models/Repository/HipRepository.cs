using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;

namespace Mitten.Models.Repository
{
	public class HipRepository : IHipRepository
	{
		private readonly MittenContext _context;

		public HipRepository()
		{
			_context = new MittenContext();
		}

		public IEnumerable<Hip> GetAll()
		{
			return _context.Hips;
		}

		public Hip Get(int id)
		{
			return _context.Hips.FirstOrDefault(h => h.Id == id);
		}

		public Hip Get(string email)
		{
			return _context.Hips.FirstOrDefault(h => h.Name == email);
		}

		public Hip Insert(Hip hip)
		{
			_context.Hips.Add(hip);
			try
			{
				_context.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				foreach (var errs in e.EntityValidationErrors)
				{
					foreach (var val in errs.ValidationErrors)
					{
						var l = val;
					}
				}
			}

			return hip;
		}

		public Hip Update(Hip hip)
		{
			_context.Entry(hip).State = EntityState.Modified;
			_context.SaveChanges();

			return hip;
		}

		public bool Delete(int id)
		{
			var h = Get(id);

			if (h == null)
				return false;

			_context.Hips.Remove(h);
			_context.SaveChanges();

			return true;
		}
	}
}