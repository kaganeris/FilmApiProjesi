
# FilmAPI Projesi Dökümantasyonu

Bu API, film, oyuncu ve kategori verilerine erişim sağlar. Kullanıcılar, filmler, oyuncular ve kategoriler ilgili bilgileri alabilir, yeni film, oyuncu ve kategori ekleyebilir, güncelleyebilir veya silebilirler.

## Genel Bakış

Bu API, film, oyuncu ve kategori verilerini JSON formatında sunar. Kullanıcılar, farklı endpoint'ler aracılığıyla çeşitli işlemler yapabilirler.

## Projeyi Başlatma

Projeyi yerel ortamınızda çalıştırmak için takip etmeniz gereken adımlar:

   - `Proje.API` projesini başlatın.
   - API, varsayılan olarak SwaggerUI kullanarak `https://localhost:[portNumaranız]/swagger/index.html` adresinde çalışacaktır.

### Temel URLLER

`https://localhost:[portNumaranız]/api/films`

`https://localhost:[portNumaranız]/api/oyunculars`

`https://localhost:[portNumaranız]/api/kategoris`

## Endpoint'ler

### Film İşlemleri
 - `GET: api/films`: Tüm Filmlerin listesini getirir.
 - `POST: api/films`: Yeni Film eklemeyi sağlar.
 - `PUT: api/films/{id}`: Verilen ID numarasına sahip filmi günceller. 
 - `DELETE: api/films/{id}}`: Verilen ID numarasına sahip filmi siler.
 - `GET: api/films/{id}`: Verilen ID numarasına sahip filmi getirir.
 - `GET: api/films/GetAllInclude`: Tüm Filmleri oyuncuları ve kategorileriyle getirir.
 - `GET: api/films/GetInclude/{id}`: Verilen ID numarasına sahip filmi oyuncuları ve kategorileriyle getirir.

### Kategori İşlemleri
 - `GET: api/kategoris`: Tüm Kategorilerin listesini getirir.
 - `POST: api/kategoris`: Yeni Kategori eklemeyi sağlar.
 - `PUT: api/kategoris/{id}`: Verilen ID numarasına sahip kategoriyi günceller. 
 - `DELETE: api/kategoris/{id}}`: Verilen ID numarasına sahip kategoriyi siler.
 - `GET: api/kategoris/{id}`: Verilen ID numarasına sahip kategoriyi getirir.
 - `GET: api/kategoris/GetAllInclude`: Tüm Kategorileri filmleriyle getirir.
 - `GET: api/kategoris/GetInclude/{id}`: Verilen ID numarasına sahip kategoriyi filmleriyle getirir.


### Oyuncu İşlemleri
 - `GET: api/oyuncus`: Tüm Oyuncuların listesini getirir.
 - `POST: api/oyuncus`: Yeni Oyuncu eklemeyi sağlar.
 - `PUT: api/oyuncus/{id}`: Verilen ID numarasına sahip oyuncuyu günceller. 
 - `DELETE: api/oyuncus/{id}}`: Verilen ID numarasına sahip oyuncuyu siler.
 - `GET: api/oyuncus/{id}`: Verilen ID numarasına sahip oyuncuyu getirir.
 - `GET: api/oyuncus/GetAllInclude`: Tüm Oyuncuları filmleriyle getirir.
 - `GET: api/oyuncus/GetInclude/{id}`: Verilen ID numarasına sahip oyuncuyu filmleriyle getirir.
## Kullanılan Teknolojiler ve Kütüphaneler

- ASP.NET 6 WEB API
- Entity Framework CORE
- SQL Server
- AutoMapper
- Fluent Validation

