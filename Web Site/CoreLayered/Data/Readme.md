#### 1. **Context(DbContext):**
`MagazineContext` sınıfı, **Entity Framework Core**'un sağladığı `DbContext` sınıfını genişleterek veritabanı ile etkileşimi yönetir. Bu sınıf, veritabanı tablolarının karşılık geldiği **DbSet** özelliklerini içerir.

- **DbSet<Article> Articles**: Haberlerin (makalelerin) veritabanı tablosuna karşılık gelir.
- **DbSet<Comment> Comments**: Yorumlar tablosunu temsil eder.
- **DbSet<Category> Categories**: Kategoriler tablosunu temsil eder.
- **DbSet<ArticleCategory> ArticleCategories**: Makale ile kategori arasındaki ilişkiyi yöneten tabloyu temsil eder.
- **DbSet<Tag> Tags**: Etiketler tablosunu temsil eder.
- **DbSet<Media> Medias**: Medya dosyaları tablosunu temsil eder.
- **DbSet<Setting> Settings**: Sistem ayarları tablosunu temsil eder.
- **DbSet<Log> Logs**: Log verilerini tutan tabloyu temsil eder.

Bu sınıf, ayrıca **OnModelCreating** metodunda veritabanı ilişkilerini yapılandırarak doğru şemaların oluşmasını sağlar. Örneğin:

- **Makale ve Yorum** arasında bire-çok ilişki kurulmuş, her bir haber birden fazla yorumu barındırabilir.
- **Makale ve Kategori** arasında çoktan-çoğa ilişki kurulmuş, bir makale birden fazla kategoriye ait olabilir.
- **Makale ve Etiket** arasında çoktan-çoğa ilişki kurulmuş, bir makale birden fazla etikete sahip olabilir.

```csharp
public class MagazineContext : DbContext
{
    public MagazineContext(DbContextOptions options) : base(options) {}

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
        modelBuilder.Entity<ArticleCategory>()
            .HasKey(ac => new { ac.ArticleId, ac.CategoryId });

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Article)
            .WithMany(a => a.Comments)
            .HasForeignKey(c => c.ArticleId);

        modelBuilder.Entity<ArticleCategory>()
            .HasOne(ac => ac.Article)
            .WithMany(a => a.ArticleCategories)
            .HasForeignKey(ac => ac.ArticleId);

        modelBuilder.Entity<ArticleCategory>()
            .HasOne(ac => ac.Category)
            .WithMany(c => c.ArticleCategories)
            .HasForeignKey(ac => ac.CategoryId);

        modelBuilder.Entity<Tag>()
            .HasMany(t => t.Articles)
            .WithMany(a => a.Tags);

        modelBuilder.Entity<Media>()
            .HasOne(m => m.Article)
            .WithMany(a => a.Media)
            .HasForeignKey(m => m.ArticleId);
    }
}
```

#### 2. **Repositories:**
Veritabanı ile yapılan her türlü CRUD (Create, Read, Update, Delete) işlemi, **Repository** sınıfları aracılığıyla yapılır. Bu sınıflar, her varlık (makale, kategori, etiket, yorum, medya, vb.) için ayrı ayrı oluşturulmuştur. Repository sınıfları, veritabanı işlemlerini daha soyut ve yönetilebilir hale getirir.

Örnek olarak, **ArticleRepository**, **CategoryRepository**, **CommentRepository** gibi sınıflar bulunur. Bu repository'ler, ilgili varlıklarla veri işlemleri yapar. Aşağıda bir repository örneği:

```csharp
public class ArticleRepository : IArticleRepository
{
    private readonly MagazineContext _context;

    public ArticleRepository(MagazineContext context)
    {
        _context = context;
    }

    public async Task<Article> GetArticleByIdAsync(int id)
    {
        return await _context.Articles
            .Include(a => a.Comments)
            .Include(a => a.Tags)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Article>> GetAllArticlesAsync()
    {
        return await _context.Articles
            .Include(a => a.Comments)
            .Include(a => a.Tags)
            .ToListAsync();
    }

    public async Task AddArticleAsync(Article article)
    {
        await _context.Articles.AddAsync(article);
    }

    public void UpdateArticle(Article article)
    {
        _context.Articles.Update(article);
    }

    public void DeleteArticle(Article article)
    {
        _context.Articles.Remove(article);
    }
}
```

#### 3. **UnitOfWork.cs:**
**UnitOfWork**, tüm repository'lerin birleşimi gibi çalışır. Bu sınıf, birden fazla repository üzerinde yapılan işlemleri bir arada yönetir ve veritabanı işlemlerinin atomik bir şekilde yapılmasını sağlar. Yani, tüm veri işlemleri başarılı bir şekilde tamamlanana kadar commit edilmez. Bu katman, veritabanı işlemleri üzerinde tutarlılık sağlamak için oldukça önemlidir.

Aşağıda **UnitOfWork** sınıfı örneği verilmiştir:

```csharp
public class UnitOfWork : IUnitOfWork
{
    private readonly MagazineContext _context;

    public UnitOfWork(MagazineContext context)
    {
        _context = context;
    }

    private IArticleRepository? _articleRepository;
    public IArticleRepository ArticleRepository => _articleRepository ??= new ArticleRepository(_context);

    private ICategoryRepository? _categoryRepository;
    public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);

    private ITagRepository? _tagRepository;
    public ITagRepository TagRepository => _tagRepository ??= new TagRepository(_context);

    private ICommentRepository? _commentRepository;
    public ICommentRepository CommentRepository => _commentRepository ??= new CommentRepository(_context);

    private IMediaRepository? _mediaRepository;
    public IMediaRepository MediaRepository => _mediaRepository ??= new MediaRepository(_context);

    private ILogRepository? _logRepository;
    public ILogRepository LogRepository => _logRepository ??= new LogRepository(_context);

    private ISettingRepository? _settingRepository;
    public ISettingRepository SettingRepository => _settingRepository ??= new SettingRepository(_context);

    public async Task CommitAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            await DisposeAsync();
        }
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}
```

#### **Teknolojiler ve Bağımlılıklar:**

- **Entity Framework Core:** Veritabanı işlemleri için ORM aracı olarak kullanılır.
- **SQLite:** Hafif ve taşınabilir veritabanı olarak seçilmiştir.
- **ASP.NET Core:** Backend için kullanılan framework.
- **UnitOfWork ve Repository Deseni:** Veritabanı işlemleri için soyutlama sağlayarak kodun daha yönetilebilir ve sürdürülebilir olmasını sağlar.

---

