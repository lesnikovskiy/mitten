using System.Collections.Generic;

namespace Mitten.Models.Repository
{
	public interface IHipRepository
	{
		IEnumerable<Hip> GetAll();
		Hip Get(int id);
		Hip Get(string email);
		Hip Insert(Hip hip);
		Hip Update(Hip hip);
		bool Delete(int id);
	}
}