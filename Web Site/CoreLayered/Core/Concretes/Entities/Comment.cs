using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
	public class Comment : BaseEntity
	{
		public required string Content { get; set; }
		public bool IsApproved { get; set; }

		// İlişkiler
		public int ArticleId { get; set; }
		public required Article Article { get; set; }
	}

}
