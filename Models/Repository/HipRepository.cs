using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace Mitten.Models.Repository
{
	public class HipRepository : IHipRepository, IDisposable
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
			hip.Location.CreatedDate = DateTime.UtcNow;
			_context.Hips.Add(hip);
			try
			{
				_context.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				foreach (var l in e.EntityValidationErrors.SelectMany(errs => errs.ValidationErrors))
				{
				}
			}

			return hip;
		}

		// Only disconnected scenario will work with EF
		public Hip Update(Hip hip)
		{
			var oHip = _context.Hips.Include("Location").FirstOrDefault(h => h.Id == hip.Id);
			if (oHip == null)
				return Insert(hip);

			hip.Key = hip.Key ?? oHip.Key;
			hip.Name = hip.Name ?? oHip.Name;
			hip.Password = hip.Password ?? oHip.Password;
			hip.Location.Lat = hip.Location.Lat > 0 ? hip.Location.Lat : oHip.Location.Lat;
			hip.Location.Lng = hip.Location.Lng > 0 ? hip.Location.Lng : oHip.Location.Lng;
			hip.Location.CreatedDate = DateTime.UtcNow;

			var entry = _context.Entry(hip);
			var key = GetPrimaryKey(entry);

			if (entry.State == EntityState.Detached)
			{
				var hipEntry = _context.Hips.Find(key);
				if (hipEntry != null)
				{
					var attachedEntry = _context.Entry(hipEntry);
					attachedEntry.CurrentValues.SetValues(hip);
				}
				else
				{
					_context.Hips.Attach(hip);
					entry.State = EntityState.Modified;
				}
			}

			var locationEntry = _context.Entry(hip.Location);
			var locKey = GetPrimaryKey(locationEntry);

			if (locationEntry.State == EntityState.Detached)
			{
				var locEntry = _context.Location.Find(locKey);
				if (locEntry != null)
				{
					var attachedLocEntry = _context.Entry(locEntry);
					attachedLocEntry.CurrentValues.SetValues(hip.Location);
				}
				else
				{
					_context.Location.Attach(hip.Location);
					locationEntry.State = EntityState.Modified;
				}
			}

			try
			{
				_context.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				var errs = e.EntityValidationErrors.SelectMany(err => err.ValidationErrors)
							.ToDictionary(x => x.PropertyName, x => x.ErrorMessage);

			}

			return hip;
		}

		private static int GetPrimaryKey(DbEntityEntry entry)
		{
			var myObj = entry.Entity;
			var property =
				myObj.GetType().GetProperties().FirstOrDefault(prop => Attribute.IsDefined(prop, typeof (KeyAttribute)));

			if (property != null) 
				return (int) property.GetValue(myObj, null);

			return -1;
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

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}