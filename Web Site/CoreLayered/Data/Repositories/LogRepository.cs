using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utility.Generics;

namespace Data.Repositories
{
	public class LogRepository : Repository<Log>, ILogRepository
	{
		public LogRepository(MagazineContext context) : base(context) { }
	}
}
