using Core.Abstracts;
using Core.Abstracts.IRepositories;
using Data.Contexts;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private MagazineContext context;

		public UnitOfWork(MagazineContext context)
		{
			this.context = context;
		}
		private IArticleRepository? articleRepository;
		public IArticleRepository ArticleRepository => articleRepository ??= new ArticleRepository(context);


		private IArticleCategoryRepository? articleCategoryRepository;
		public IArticleCategoryRepository ArticleCategoryRepository => articleCategoryRepository ??= new ArticleCategoryRepository(context);


		private ICategoryRepository? categoryRepository;
		public ICategoryRepository CategoryRepository => categoryRepository ??= new CategoryRepository(context);


		private ITagRepository? tagRepository;
		public ITagRepository TagRepository => tagRepository ??= new TagRepository(context);


		private IMediaRepository? mediaRepository;
		public IMediaRepository MediaRepository => mediaRepository ??= new MediaRepository(context);


		private ILogRepository? logRepository;
		public ILogRepository LogRepository => logRepository ??= new LogRepository(context);


		private ISettingRepository? settingRepository;
		public ISettingRepository SettingRepository => settingRepository ??= new SettingRepository(context);


		private ICommentRepository? commentRepository;
		public ICommentRepository CommentRepository => commentRepository ??= new CommentRepository(context);

		public async Task CommitAsync()
		{
			try
			{
				await context.SaveChangesAsync();
			}
			catch (Exception)
			{
				await DisposeAsync();
			}
		}

		public async ValueTask DisposeAsync()
		{
			await context.DisposeAsync();
		}
	}
}
