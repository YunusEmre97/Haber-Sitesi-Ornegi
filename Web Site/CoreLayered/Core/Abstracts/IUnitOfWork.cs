using Core.Abstracts.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts
{
	public interface IUnitOfWork :IAsyncDisposable
	{
		IArticleRepository ArticleRepository { get; }
		IArticleCategoryRepository ArticleCategoryRepository { get; }
		ICategoryRepository CategoryRepository { get; }
		ITagRepository TagRepository { get; }
		IMediaRepository MediaRepository { get; }
		ILogRepository LogRepository { get; }
		ISettingRepository SettingRepository { get; }
		ICommentRepository CommentRepository { get; }

		Task CommitAsync();
	}
}
