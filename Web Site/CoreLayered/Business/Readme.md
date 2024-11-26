### **Business Katmanı: Genel Bakış**  
Business katmanı, uygulamanın iş mantığını yönetir ve veritabanı işlemleriyle servisler arasında köprü görevi görür.

---

### **IOC.cs (Inversion of Control)**  
**IOC.cs**, Dependency Injection yapılandırmalarını içerir. Buradaki ayarlar:
- **AutoMapper Profilleri:** DTO'lar ile Entity'ler arasındaki dönüşüm kurallarını tanımlar.  
- **DbContext Ayarı:** SQLite bağlantısını yapılandırır.  
- **Scoped Servisler:** `IUnitOfWork` ve `INewsService` servislerini bağımlılık olarak ekler.  

**Amacı:**  
UI katmanında olması gerekmeyen, performans ve güvenlik açısından önemli ayarların burada tanımlanmasını sağlar.

---

### **NewsService.cs**  
Haberlerle ilgili iş mantığını barındırır ve şu işlemleri yapar:  

1. **GetArticleAsync:**  
   Belirli bir haberi `slug` parametresine göre getirir.

2. **GetArticlesAsync:**  
   Tüm haberleri veya bir filtreye göre belirli haberleri listeler.

3. **GetArticlesByCategoryAsync:**  
   Belirli bir kategoriye ait haberleri döner.

4. **GetArticlesByTagAsync:**  
   Belirli bir etikete ait haberleri döner.

5. **GetCategoriesAsync / GetCategoryAsync:**  
   Tüm kategorileri veya bir kategoriyi getirir.

6. **GetTagAsync:**  
   Tüm etiketleri listeler.

**Kullandığı Araçlar:**  
- **`IUnitOfWork`:** Veritabanı işlemlerini yönetir.  
- **`IMapper`:** Entity ile DTO arasında veri dönüşümü yapar.

--- 

