namespace Core.Concretes.Entities
{
	public class ArticleCategory
	{
		public int ArticleId { get; set; }
		public required Article Article { get; set; }
		public int CategoryId { get; set; }
		public required Category Category { get; set; }
	}

}
