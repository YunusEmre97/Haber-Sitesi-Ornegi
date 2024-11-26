using Core.Abstracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
	public class Article : BaseEntity
	{

		public required string Title { get; set; }
		public required string Slug { get; set; } // URL-friendly başlık
		public required string Content { get; set; }
		public DateTime PublishedAt { get; set; }
		public int ViewCount { get; set; }
		public bool IsPublished { get; set; }

		// İlişkiler
		public required ICollection<Comment> Comments { get; set; }
		public required ICollection<ArticleCategory> ArticleCategories { get; set; }
		public required ICollection<Tag> Tags { get; set; }
		public required ICollection<Media> Media { get; set; }
	}

}
