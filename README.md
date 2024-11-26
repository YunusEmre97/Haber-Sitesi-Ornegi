# Basit Haber Sitesi - .NET 8.0

Bu proje, **.NET 8.0** kullanılarak eğitim ve öğrenim teması altında geliştirilmiş bir haber sitesi örneğidir. Proje, katmanlı mimariye uygun bir şekilde tasarlanmıştır ve aşağıdaki katmanlardan oluşmaktadır:

- **UI (User Interface):** Kullanıcı arayüzü için **HTML5 UP** sitesinden **Editorial** teması kullanılmıştır.  
- **Business:** İş kuralları ve lojik katmanı.  
- **Core:** Uygulama genelinde kullanılan soyutlama ve temel yapı.  
- **Data:** Veri erişim katmanı.  
- **Utility:** Yardımcı araçlar ve genel işlevler.

## Özellikler

- **Ana Sayfa:** Günün haberleri ana sayfada sergilenir.  
- **Haber Kategorileri:** Kategoriler arasında gezinebilir ve ilgili haberler görüntülenebilir.  
- **Sayfalama:** Haberler, sayfalama özelliği ile düzenlenmiştir.  
- **Veritabanı:**  
  - Tüm veriler, **www.mockaroo.com** üzerinden oluşturulan fake datalardan oluşmaktadır.  
  - Veriler, **Db Browser for SQLite** kullanılarak bir veritabanına eklenmiş ve projeye **migration** yöntemiyle dahil edilmiştir.

## Teknik Detaylar

Bu proje, haber sitelerinin temel işlevlerini öğrenmek ve uygulamak için geliştirilmiştir. Katmanlı mimari yapısı, farklı katmanların birbirinden bağımsız ve yeniden kullanılabilir şekilde düzenlenmesini sağlar.

---

