using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Utility.Generics;

namespace UI.RazorPages.Pages
{
	public class CategoryModel : PageModel
	{
		private readonly INewsService service;

		public CategoryModel(INewsService service)
		{
			this.service = service;
		}
		public CategoryListItem? CategoryItem { get; set; }

		public Pagination<ArticleListItem> Articles;

		public async Task OnGetAsync(string slug, int p = 1)
		{

			//bool isFirst = int.TryParse(Request.Query["page"], out int page);
			p = p <= 0 ? 1 : p;

			var data = await service.GetArticlesByCategoryAsync(slug);

			Articles = Pagination<ArticleListItem>.Create(data, p, 6);

			CategoryItem = await service.GetCategoryAsync(slug);
		}
	}
}
