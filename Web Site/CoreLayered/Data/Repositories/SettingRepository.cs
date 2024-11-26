using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utility.Generics;

namespace Data.Repositories
{
	public class SettingRepository : Repository<Setting>, ISettingRepository
	{
		public SettingRepository(MagazineContext context) : base(context) { }
	}
}
