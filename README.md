# LibraryApp

LibraryApp bir kütüphanedeki kitapları resimleri ile birlikte görüntülemenizi sağlayan, ayrıca yeni kitap eklemenizi ve kitapları ödünç vermeyi sağlayan, .Net Framework ü ile katmanlı mimari kullanılarak yazılmış bir MVC uygulamasıdır.

Code First yaklaşımı kullanılarak Books ve BorrowedBooks tabloları oluşturulmuştur. 
```sh
add-migration Initial
update-database
```
Kitapların listelendiği tabloda ödünç verilmiş kitabı kimin aldığı ve ne zaman iade edeceği bilgisini göstermek için DataAccess katmanında LINQ sorgusu kullanılmıştır.
BorrowedBooks tablosunu önce BookId'ye göre gruplayıp, her grup için en büyük ReturnDate(iade tarihi) değeri bulunur, sonra bu bilgileri kullanarak iki tabloyu birleştirilir ve BookId, BorrowerName ve ReturnDate değerleri alınır.

## Anasayfa örnek görüntüsü
![Anasayfa](https://github.com/vedatdikgoz/LibraryApp/blob/master/LibraryApp.WebUI/wwwroot/img/anasayfa.jpg)

## Projeyi klonlayın:

 ```sh
  git clone https://github.com/vedatdikgoz/LibraryApp.git
 ``` 

<h3 align="left">Kullanılan Dil ve Araçlar:</h3>
<p align="left"> <a href="https://getbootstrap.com" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/bootstrap/bootstrap-plain-wordmark.svg" alt="bootstrap" width="40" height="40"/> </a> <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a> <a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="40" height="40"/> </a> <a href="https://www.w3.org/html/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/html5/html5-original-wordmark.svg" alt="html5" width="40" height="40"/> </a> <a href="https://www.microsoft.com/en-us/sql-server" target="_blank" rel="noreferrer"> <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="mssql" width="40" height="40"/> </a> </p>
