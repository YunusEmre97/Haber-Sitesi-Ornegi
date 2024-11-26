using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utility.Generics;

namespace Data.Repositories
{
	public class MediaRepository : Repository<Media>, IMediaRepository
	{
		public MediaRepository(MagazineContext context) : base(context) { }
	}
}
