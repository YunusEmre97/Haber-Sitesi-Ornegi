using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
	public class ArticleListItem
	{
		public required string Title { get; set; }
		public required string Slug { get; set; }
		public DateTime PublishedAt { get; set; }
		public int ViewCount { get; set; } = 0;
		public int CommentCount { get; set; } = 0;
		public IEnumerable<TagListItem> Tags { get; set; } = new HashSet<TagListItem>();
		public IEnumerable<CategoryListItem> Categories { get; set; } = new HashSet<CategoryListItem>();
		public required string Thumbnail { get; set; }
		public required string ShortContent { get; set; }
	}
}
