using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
	public class Tag : BaseEntity
	{
		public required string Name { get; set; }

		// İlişkiler
		public required ICollection<Article> Articles { get; set; }
	}

}
