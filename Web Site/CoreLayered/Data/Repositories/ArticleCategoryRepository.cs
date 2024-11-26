using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utility.Generics;

namespace Data.Repositories
{
	public class ArticleCategoryRepository : Repository<ArticleCategory>, IArticleCategoryRepository
	{
		public ArticleCategoryRepository(MagazineContext context) : base(context) { }
	}
}
