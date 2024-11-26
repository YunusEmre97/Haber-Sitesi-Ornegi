using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
	public class Category : BaseEntity
	{
		public required string Name { get; set; }
		public required string Description { get; set; }

		// İlişkiler
		public required ICollection<ArticleCategory> ArticleCategories { get; set; }
	}

}
