### **Abstracts Klasörü:**
1. **IUnitOfWork Interface:** Veritabanı işlemleri için bir birim iş birliği (Unit of Work) tasarımı sağlıyor. Bu, tüm repository'leri bir arada yönetmek ve veri işlemleri arasında tutarlılık sağlamak için kullanılır. 
   
2. **Repository Interfaces (IArticleRepository, ICategoryRepository vb.):** Her varlık (Entity) için bir repository arabirimi oluşturulmuş. Bu repository'ler, veritabanına yönelik CRUD (Create, Read, Update, Delete) işlemleri gerçekleştirmek için kullanılır.

3. **BaseEntity:** Tüm varlıkların (Entity) sahip olacağı ortak özellikleri tanımlar, örneğin `Id`, `CreateDate`, `Active` ve `Deleted`.

4. **INewsService:** Haberleri yönetmek için servis katmanında kullanılacak metodları belirler. `GetArticlesAsync`, `GetArticleAsync` gibi metotlarla haberleri almak mümkündür.

### **Concretes Klasörü:**
1. **DTOs (Data Transfer Objects):** `ArticleListItem`, `CategoryListItem` ve `TagListItem` gibi DTO sınıfları, veritabanı ile uygulama arasındaki veri transferini sağlar. Bu sınıflar genellikle frontend'e gönderilecek verilere yönelik yapılardır.

2. **Entities:** `Article`, `Category`, `Comment` vb. sınıflar, veritabanı ile etkileşimde kullanılan varlıkları temsil eder. Bu varlıklar arasında ilişkiler de mevcuttur (örneğin, bir `Article` birçok `Tag` ve `Category` ile ilişkili olabilir).

3. **Mapping Profiles:** AutoMapper kullanarak veritabanı varlıklarını DTO'lara dönüştüren sınıflar. Örneğin, `ArticleProfile`, `CategoryProfile`, ve `TagProfile` sınıfları, `Article` varlıklarını `ArticleListItem` DTO'suna dönüştürür.

4. **Entities İçindeki İlişkiler:** `ArticleCategory`, `Article` ve `Category` gibi sınıflar arasındaki ilişkileri düzenler. Bu ilişkiler, her bir makalenin bir veya daha fazla kategoriye ait olmasını sağlar.

### **Genel Yapı:**
- **UnitOfWork Pattern** kullanımı, farklı repository'leri birleştirerek, bir işlem boyunca tüm veritabanı işlemlerini koordine eder.
- **AutoMapper** ile DTO'lar arasında veri dönüşümleri gerçekleştirilir, bu da kodun daha modüler ve bakımı kolay hale gelmesini sağlar.
- **BaseEntity** kullanımı, her varlığın ortak özelliklere sahip olmasını sağlar ve kodun tekrarını önler.

Bu yapılar, katmanlı mimariyi takip ederek uygulamanın daha modüler, sürdürülebilir ve test edilebilir olmasını sağlar.
