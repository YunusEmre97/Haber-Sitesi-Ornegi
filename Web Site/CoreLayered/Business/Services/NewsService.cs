using AutoMapper;
using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using System.Linq.Expressions;
using Utility.Extensions;

namespace Business.Services
{
	public class NewsService : INewsService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public NewsService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public async Task<ArticleDetail> GetArticleAsync(string slug)
		{
			var article = await unitOfWork.ArticleRepository.FindFirstAsync(x => x.Slug.Equals(slug));
			return new ArticleDetail { };
		}

		public async Task<IEnumerable<ArticleListItem>> GetArticlesAsync(Func<ArticleListItem, bool>? expression = null)
		{
			IEnumerable<Article> articles = await unitOfWork.ArticleRepository.FindManyAsync();

			IEnumerable<ArticleListItem> listItems = mapper.Map<IEnumerable<ArticleListItem>>(articles);

			return expression != null ? listItems.Where(expression) : listItems;
		}

		public async Task<IEnumerable<ArticleListItem>> GetArticlesByCategoryAsync(string category_slug)
		{
			return await GetArticlesAsync(x => x.Categories.Any(x => x.Slug == category_slug));
		}

		public async Task<IEnumerable<ArticleListItem>> GetArticlesByTagAsync(string tag_slug)
		{
			
			return await GetArticlesAsync(x => x.Tags.Any(x => x.Slug == tag_slug));
			
		}

		public async Task<IEnumerable<CategoryListItem>> GetCategoriesAsync()
		{
			var categories = await unitOfWork.CategoryRepository.FindManyAsync();
			return mapper.Map<IEnumerable<CategoryListItem>>(categories);
		}

		public async Task<CategoryListItem> GetCategoryAsync(string slug)
		{
			var categories = await GetCategoriesAsync();
			var category = categories.FirstOrDefault(x => x.Name.ToSlug() == slug);	
			return mapper.Map<CategoryListItem>(category);
		}

		public async Task<IEnumerable<TagListItem>> GetTagAsync()
		{
			var tags = await unitOfWork.TagRepository.FindManyAsync();
			return mapper.Map<IEnumerable<TagListItem>>(tags);
		}
	}
}
