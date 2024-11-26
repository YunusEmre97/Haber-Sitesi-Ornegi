using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utility.Generics;

namespace Data.Repositories
{
	public class TagRepository : Repository<Tag>, ITagRepository
	{
		public TagRepository(MagazineContext context) : base(context) { }
	}
}
