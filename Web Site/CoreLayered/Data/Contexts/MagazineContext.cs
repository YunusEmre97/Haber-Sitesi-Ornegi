using Core.Concretes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Contexts
{
	public class MagazineContext : DbContext
	{
		public MagazineContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<Article>? Articles { get; set; }
		public DbSet<Comment>? Comments { get; set; }
		public DbSet<Category>? Categories { get; set; }
		public DbSet<ArticleCategory>? ArticleCategories { get; set; }
		public DbSet<Tag>? Tags { get; set; }
		public DbSet<Media>? Medias { get; set; }
		public DbSet<Setting>? Settings { get; set; }
		public DbSet<Log>? Logs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// ArticleCategory için birincil anahtarı tanımla
			modelBuilder.Entity<ArticleCategory>()
				.HasKey(ac => new { ac.ArticleId, ac.CategoryId });

			// Article ile Comment arasında birden fazla yorumu ilişkilendir
			modelBuilder.Entity<Comment>()
				.HasOne(c => c.Article)
				.WithMany(a => a.Comments)
				.HasForeignKey(c => c.ArticleId);

			// Article ile Category arasında çoklu ilişki
			modelBuilder.Entity<ArticleCategory>()
				.HasOne(ac => ac.Article)
				.WithMany(a => a.ArticleCategories)
				.HasForeignKey(ac => ac.ArticleId);

			modelBuilder.Entity<ArticleCategory>()
				.HasOne(ac => ac.Category)
				.WithMany(c => c.ArticleCategories)
				.HasForeignKey(ac => ac.CategoryId);

			// Article ile Tag arasında çoklu ilişki
			modelBuilder.Entity<Tag>()
				.HasMany(t => t.Articles)
				.WithMany(a => a.Tags);

			// Article ile Media arasında birden fazla medya dosyasını ilişkilendir
			modelBuilder.Entity<Media>()
				.HasOne(m => m.Article)
				.WithMany(a => a.Media)
				.HasForeignKey(m => m.ArticleId);
		}
	}
}
