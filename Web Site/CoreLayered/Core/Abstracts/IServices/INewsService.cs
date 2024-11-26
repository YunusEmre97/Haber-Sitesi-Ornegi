using Core.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
	public interface INewsService
	{
		Task<IEnumerable<ArticleListItem>> GetArticlesAsync(Func<ArticleListItem, bool>? expression = null);
		Task<IEnumerable<ArticleListItem>> GetArticlesByCategoryAsync(string category_slug);
		Task<IEnumerable<ArticleListItem>> GetArticlesByTagAsync(string tag_slug);
		Task<ArticleDetail> GetArticleAsync(string slug);
		Task<IEnumerable<TagListItem>> GetTagAsync();
		Task<IEnumerable<CategoryListItem>> GetCategoriesAsync();
		Task<CategoryListItem> GetCategoryAsync(string slug);

	}
}
