
## Utility Katmanı - Yardımcı Fonksiyonlar ve Genel Yapılar

Bu projede **Utility** katmanı, uygulamanın farklı bölümlerinde tekrar eden kodların merkezi hale getirilmesi ve genel yardımcı işlevlerin sağlanması amacıyla tasarlanmıştır. Kullanım kolaylığı ve bakımı daha verimli hale getirebilmek için aşağıdaki yapılar sunulmuştur:

### **1. Extensions (Uzantılar)**
- **`StringExtensions`**: Bu sınıf, string tipinde yapılan bazı yaygın işlemleri kolaylaştıran bir uzantıdır. Örneğin, `ToSlug` metodu, bir metni SEO dostu bir slug formatına dönüştürmek için kullanılır. Türkçe karakterleri (örneğin, "ğ", "ç") uygun şekilde dönüştürür ve sadece alfanümerik karakterleri içeren bir slug oluşturur.

```csharp
public static string ToSlug(this string text)
{
    string slug = text.ToLowerInvariant();
    slug = slug.Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u").Replace("ş", "s").Replace("ö", "o").Replace("ç", "c");
    slug = Regex.Replace(slug,@"[^a-z0-9\s-]", "");
    slug = Regex.Replace(slug,@"\s+", " ").Trim();
    slug = slug.Replace(" ", "-");
    return slug;
}
```

### **2. Generics (Genel Yapılar)**
- **`IRepository<T>` ve `Repository<T>`**: Bu yapılar, veri erişimi için generic bir repository tasarımı sağlar. Repository deseni kullanarak, veritabanı işlemleri (ekleme, güncelleme, silme, sorgulama) daha modüler ve tekrar kullanılabilir hale getirilir.
  
```csharp
public interface IRepository<T> where T : class
{
    Task InsertOneAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteOneAsync(T entity);
    Task<T?> FindByKeyAsync(object entityKey);
}
```

- **`Pagination<T>`**: Bu sınıf, veri listesini sayfalara ayırmak için kullanılır. Sayfalama bilgilerini (örneğin, toplam sayfa sayısı, mevcut sayfa, başlangıç ve bitiş sayfa numaraları) yönetir. Bu sayede büyük veri setlerinde gezinmek daha kolay hale gelir.

```csharp
public class Pagination<T>
{
    public IEnumerable<T> Items { get; set; }
    public int Start { get; set; }
    public int End { get; set; }
    public int Total { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPages { get; set; }
    public int Limit { get; set; }

    public Pagination(IEnumerable<T> data, int page, int limit)
    {
        CurrentPages = page;
        Limit = limit;
        Total = data.Count();
        TotalPages = (int)Math.Ceiling((double)Total / limit);
        Start = CurrentPages - 3 > 1 ? CurrentPages - 3 : 1;
        End = CurrentPages + 3 < TotalPages ? CurrentPages + 3 : TotalPages;
        Items = data.Skip((page - 1) * limit).Take(limit);
    }
}
```

### **3. Models (Modeller)**
- **`LogLevel` ve `MediaType` Enumları**: Bu enum'lar, uygulama genelinde log seviyelerini (`Info`, `Warning`, `Error`, `Critical`) ve medya türlerini (`Image`, `Video`, `Audio`) tanımlamak için kullanılır. Bu tür yapılandırmalar, uygulamanın yönetimini ve genişletilmesini kolaylaştırır.

```csharp
public enum LogLevel
{
    Info,
    Warning,
    Error,
    Critical
}
```

```csharp
public enum MediaType
{
    Image,
    Video,
    Audio
}
```

---

### **Utility Katmanı Özellikleri:**
- **Yeniden kullanılabilirlik**: Yardımcı işlevlerin tek bir katmanda toplanması, kodun yeniden kullanılabilirliğini artırır ve projede tutarlılığı sağlar.
- **Esneklik**: Repository ve Pagination gibi generic yapılar, projede farklı veri tipleriyle kolayca çalışılmasına olanak tanır.
- **Okunabilirlik**: Her fonksiyon ve sınıf, belirli bir sorunu çözmek için tasarlanmıştır, bu da kodun anlaşılabilirliğini artırır.

---


