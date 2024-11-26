using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
	public class Media : BaseEntity
	{

		public required string Url { get; set; }
		public required string MediaType { get; set; } // image, video vs.

		// İlişkiler
		public int ArticleId { get; set; }
		public required Article Article { get; set; }
	}

}
