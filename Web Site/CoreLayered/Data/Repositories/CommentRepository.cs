using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utility.Generics;

namespace Data.Repositories
{
	public class CommentRepository : Repository<Comment>, ICommentRepository
	{
		public CommentRepository(MagazineContext context) : base(context) { }
	}
}
