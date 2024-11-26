using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utility.Generics;

namespace Data.Repositories
{
	public class ArticleRepository : Repository<Article>, IArticleRepository
	{
		public ArticleRepository(MagazineContext context) : base(context) { }
		public override async Task<IEnumerable<Article>> FindManyAsync(Expression<Func<Article, bool>>? expression = null)
		{
			var data = _set.Include(x => x.ArticleCategories).ThenInclude(X => X.Category);

			if (expression != null)
			{
				return await data.Where(expression).ToListAsync();
			}
			else 
			{
				return await data.ToListAsync();
			}
		}
	}
}
