**Ödev 1 || Soru 1-**
 Şehirlerin ilçelerini tutan bir Hashtable nesnesi yaratınız. Sonra bir döngü içerisinde klavyeden şehir ismini isteyiniz, sözlükten ona karşılık gelen ilçeleri bulup yazdırınız. 

Cevap 1 – Açıklaması

Bu uygulamada aslında şehirler ve ilçeler sözlüğü benzeri bi  yapı oluşturduk. Bunu yaparken de Hastable kullandım. Bu anahtar-değer yapısı gibi aslında bir şehir ismi yazınca ona karşılık gelen ilçeleri hemen bulmamızı sağlıyor. Yani şehir anahtar, ilçeler değer oluyor.
İlk olarak bir Hastable oluşturdum ve içine birkaç şehir ve ilçelerini ekledim. Mesela Antalya için ‘Konyaaltı, Lara, Kepez, Alanya’ gibi değerler verdim. Sonra kullanıcıdan sürekli şehir ismi alabilmek için bi while döngüsü kurdum. Kullanıcı şehir ismi giriyor, program önce bu şehrin sözlükte olup olmadığını ContainsKey ile kontrol ediyor. Eğer varsa ilçeleri ekrana yazdırıyor, yoksa ‘Bu şehir listede yok’ diye uyarı veriyor.
Kullanıcı çıkmak isterse ‘q’ tuşuna basıyor, program da döngüyü kırıp kapanıyor. 

<img width="931" height="482" alt="image" src="https://github.com/user-attachments/assets/acd695db-12fa-4736-9cf6-e48cde581ecf" />



**Ödev 1 || Soru 2-**
Bir string içerisindeki karakterlerin hepsinin farklı olup olmadığını aşağıda belirtilen yöntemle belirleyiniz. Sonra bir döngü içerisinde klavyeden string okuyarak sonuçları yazdırınız.

Cevap 2 – Açıklaması

Bir string içindeki bütün karakterlerin farklı olup olmadığını kontrol ediyoruz. Bunun için Hashtable kullandım çünkü bana karakterleri tek tek saklayabileceğim bir koleksiyon veriyor. Program çalışınca kullanıcıdan bir kelime ya da cümle istiyor. Bunu input değişkenine atıyoruz.
Sonra foreach (char c in input)) ile string’in her karakterini tek tek dolaşıyorum. Burada char veri tipi kullanılıyor, çünkü her seferinde sadece bir karakteri alıyoruz..
Programda tekrar eden karakterleri bulmak için Hashtable içindeki değerleri saydırdım. Her karakteri eklerken, eğer daha önce Hashtable’da varsa değeri 1 artırdım. Yani aynı karakter birden fazla görünürse, değeri 1’den büyük oluyor. Daha sonra Hashtable’ı dolaşarak her karakterin değerine baktım; değeri 1’den büyük olan karakterler, tekrar eden karakterler olarak kabul edildi ve ekrana yazdırıldı. Böylece kullanıcı hem hangi karakterin tekrar ettiğini hem de kaç kez tekrar ettiğini görebiliyor.
Eğer bir karakter 1’den fazla geçiyorsa, program ekrana "Karakter 'x' n kez tekrar ediyor" mesajını yazıyor. Eğer hiç tekrar eden karakter yoksa, "Tüm karakterler birbirinden farklı" mesajı gözüküyor.
Programı sonsuz bir döngü içinde yaptım, böylece kullanıcı istediği kadar string deneyebiliyor. Çıkmak isterse sadece 'q' yazması yeterli.


<img width="931" height="479" alt="image" src="https://github.com/user-attachments/assets/9e4b5cb1-436c-4857-92bf-3fc9b6f3a0bb" />



**Ödev1 || Soru 3-**
İki sözcüğün anagram olup olmadığını (yani tamamen aynı sayıda aynı karakterlerden oluşup oluşmadığını) belirleyen programı aşağıda açıklandığı gibi yazınız. 
Cevap 3 – Açıklaması


Bu programda iki kelimenin anagram olup olmadığını kontrol ediyoruz. Bunun için Dictionary kullandım, bana karakterleri ve sayısını saklayacak bir yapı veriyor. Dictionary’de anahtar karakter (char), değer ise sayısı (int) olacak.
İlk olarak birinci kelimenin her karakterini dolaşıyoruz (foreach). Eğer karakter daha önce dictionary’de varsa sayacı 1 artırıyoruz, yoksa 1 olarak ekliyoruz. Bu sayede birinci kelimedeki her karakterin kaç kez geçtiğini biliyoruz.
Sonra ikinci kelimenin karakterlerini dolaşıyoruz ve her karakter için dictionary’deki sayacı 1 azaltıyoruz. Eğer karakter yoksa veya sayaç negatif oluyorsa, bu iki kelime anagram olamaz.
En sonunda, tüm karakterlerin sayacı sıfır mı diye kontrol ediyoruz. Eğer tüm değerler sıfırsa, kelimeler birbirinin anagramıdır. Eğer herhangi biri sıfır değilse anagram değildir.
Programı bir döngü içinde yaptım, böylece kullanıcı istediği kadar test yapabilir. Çıkmak isterse sadece 'q' yazması yeterli.”


 <img width="931" height="474" alt="image" src="https://github.com/user-attachments/assets/bd32d205-dc5e-4332-9ee1-410e1c57260e" />

 
**Ödev 2 || Soru 1-** 
 
 1. Bir dizinin içeriğini elde ederek bunu bir nesne tutan sınıf gibi sunan DirectoryList isimli sınıfı yazınız. 
Açıklamalar 
Sınıfın hangi dizin içeriğinin elde edileceğini belirten string parametreli bir başlangıç metodu olmalıdır. Sınıf IEnumerable arayüzünü desteklemelidir. IEnumerable arayüzünün desteklenmesi işlemi şöyle yapılabilir: 
- Dizin içerisindeki dosya isimleri Directory.GetFiles fonksiyonuyla alınarak string türünden bir dizide saklanabilir. 
- Sayımlama (enumeration) işlemi için iç (nested) bir sınıf bildirilebilir. Bu iç sınıfa dış sınıfın referansı geçirilebilir. Bu sınıf sayımlama indeksini tutabilecek int türden bir veri elemanına sahip olabilir: 
public class DirectoryList : IEnumerable 
{ 
private string[] m_files; 
//... 
public DirectoryList(string dir) 
{ 
// Dizindeki dosya isimleri alınarak m_files dizisinin içerisine yerleştirilecek 
} 
private class DirectoryListEnumerator : IEnumerator 
{ 
private DirectoryList m_dl; 
private int m_index; 
//... 
public DirectoryListEnumerator(DirectoryList dl) 
{ 
m_dl = dl; 
m_index = -1; 
} 
// ... 
} 
} 
DirectoryList sınıfının GetEnumerator fonksiyonu DirectoryListEnumerator türünden bir nesne verir. İç sınıf fonksiyonlarının kapsayan sınıfın her bölümüne erişebildiğini anımsayınız. 
public IEnumerator GetEnumerator() 
{ 
return new DirectoryListEnumerator(this); 
} 
Artık geri kalan işlemler DirectoryListEnumerator sınıfının IEnumerator arayüzünden gelen fonksiyonlarınınyazılmasıdır. Bu fonksiyonları yazarken m_dl elemanı ve m_indeks elemanı kullanılmalıdır. Kodunuzu aşağıdaki gibi bir kodla test edebilirsiniz: 
public static void Main() 
{ 
DirectoryList dl = new DirectoryList(“c:\\windows”); 
try 
{ 
foreach (string s in dl) 
Console.WriteLine(s); 
}  
catch (Exception e) 
{ 
Console.WriteLine(e.Messsage); 
} 
}

Cevap 1 – Açıklaması

“Bu ödevde DirectoryList adında bir sınıf yaptım. Amacımız, bir dizindeki dosya isimlerini enumerable yani foreach ile gezilebilir yapmak.
1.	m_files adında bir dizi oluşturduk ve dizindeki dosya isimlerini Directory.GetFiles(dir) ile aldık. Eğer dizin yoksa ya da hata olursa boş bir dizi oluşturuyoruz.
2.	IEnumerable arayüzünü desteklemek için GetEnumerator() fonksiyonunu yazdım. Bu fonksiyon iç sınıf olan DirectoryListEnumerator türünden bir nesne döndürüyor.
3.	İç sınıf DirectoryListEnumerator, IEnumerator arayüzünü implemente ediyor.
o	m_index ile hangi elemanda olduğumuzu takip ediyoruz.
o	MoveNext() ile bir sonraki elemana geçiyoruz.
o	Current ile o anki dosya ismini alıyoruz.
o	Reset() ile başa dönebiliyoruz.
4.	İç sınıf, dış sınıfın tüm üyelerine erişebiliyor (m_dl.m_files) bu sayede dosya isimlerini alabiliyoruz.
5.	Programı test etmek için foreach (string s in dl) kullandım ve dosya isimlerini ekrana yazdırdım. Hata olursa try-catch ile ekrana yazdırıyoruz.



<img width="931" height="463" alt="image" src="https://github.com/user-attachments/assets/5b175657-6ed5-409e-ac53-4d9e9986b002" />



 
**Ödev 3 || Soru 1-**
 
24 (5X5 - 1) tane düğme yaratarak bunları çalışma alanını kaplar hale getiriniz. Düğmeler kare biçiminde olmalı ve üzerlerinde 1, 2, 3, … biçiminde sayılar bulunmalıdır. (Dolayısıyla çalışma alanı da kare biçiminde olmalı ve boyutlandırılamamalıdır). Bu düğmelerin ortasında bir düğmelik boş bir alan vardır. Düğmenin üzerine tıklandığında eğer o düğme uygun bir pozisyondaysa (yani boş alanın dört komşusundan biriyse) tıklanan düğmenin o boş bölgeye taşınabilmesini sağlayınız. Başlangıçta düğmeler rastgele bir biçimde dizilmişlerdir. Oyunun amacı onları 1-24 arasında düzenli olarak dizip boşluğun en altta sağda kalmasını sağlamaktır.


Cevap 1 – Açıklaması

Bu ödevde, 5x5 boyutunda bir “taş kaydırma” oyunu tasarladım. Toplam 24 düğme oluşturuldu ve formun ortasında bir boş alan bırakıldı. Düğmeler kare şeklinde ve üzerlerinde 1’den 24’e kadar sayılar bulunuyor.
Kod yapısında, düğmelerin matris şeklinde bir diziye yerleştirildiğini görebiliriz. Boş alanın koordinatları emptyRow ve emptyCol değişkenleriyle takip ediliyor. Düğmeye tıklandığında, tıklanan düğmenin boş alanın dört komşusundan biri olup olmadığı kontrol ediliyor. Eğer uygunsa, düğme boş alanla yer değiştiriyor ve boş alan yeni konumuna taşınıyor.
Başlangıçta düğmeler rastgele diziliyor. Bu sayede kullanıcı oyunu çözmek için mantıksal hareketler yapmak zorunda kalıyor. Oyunun amacı, düğmeleri 1’den 24’e kadar sıralayıp boş alanı sağ alt köşede konumlandırmak.


<img width="625" height="672" alt="image" src="https://github.com/user-attachments/assets/629138f6-0875-4597-b990-6f0c228ab754" />


**Ödev 3 || Soru 2-**
 
Birinci sorudaki programı değiştirerek pencereyi boyutlandırılabilir hale getiriniz. Pencere boyutlandırıldığında düğmelerin de yeniden ayarlanması gerekmektedir. Artık çalışma alanı ve dolayısıyla düğmeler kare biçiminde olmak zorunda değildir.


Cevap 2 – Açıklaması

Bu ödevde birinci sorudaki 5×5 taş kaydırma oyununun penceresini boyutlandırılabilir hâle getirdim ve pencere her yeniden boyutlandırıldığında taşların (düğmelerin) konum ve boyutlarını dinamik olarak yeniden hesapladım. İlk versiyonda kare bir çalışma alanı ve kare butonlar şarttı; bu sürümde kare zorunluluğu yok. Ekranın en-boy oranı ne olursa olsun 5×5 ızgara formun ClientSize’ı üzerinden yeniden çiziliyor.
Teknik olarak, oyun durumunu bir int[,] board dizisinde tutuyorum; 0 değeri boşluğu temsil ediyor, 1–24 değerleri butonları. Buton nesnelerini bir kez oluşturup numaraya göre bir sözlükte (Dictionary<int, Button>) saklıyorum. Böylece oyunda taşlar hareket ettiğinde sadece board değişiyor, butonların ekran üzerindeki pozisyonu LayoutButtons() metodunda formun boyutlarına göre hesaplanıp güncelleniyor.
Formun Resize olayı ile her boyut değişiminde LayoutButtons() tetikleniyor. Hücre boyutlarını ClientSize.Width / 5 ve ClientSize.Height / 5 şeklinde ayırıyorum; bu sayede artık hücreler kare olmak zorunda değil. Her hücre içinde küçük bir padding bırakarak düğmeler arasında görsel bir boşluk sağlıyorum. Bu, hem estetiği artırıyor hem de “boyutlandırılabilir” davranışı netleştiriyor.
Karıştırma aşamasında, sırf metinleri değiş tokuş etmek yerine geçerli oyun hamleleriyle (boşluğun komşusunu boşluğa sürerek) belirli sayıda adım atıyorum. Bu yöntem her zaman çözülebilir bir başlangıç durumu garanti ediyor. Tıklama mantığında, tıklanan taşın boşluğun yan komşusu olup olmadığını kontrol edip, uygunsa taş–boşluk yer değiştiriyor; ardından LayoutButtons() ile ekran taze konumlandırılıyor. Çözüm kontrolü için IsSolved() fonksiyonu 1’den 24’e sıra dizilimini ve boşluğun sağ altta olmasını doğruluyor.


<img width="931" height="734" alt="image" src="https://github.com/user-attachments/assets/c15d5aef-54a6-4044-8c09-f6a2e1032117" />

 
**Ödev Uygulama || Soru 1-**
 
Öğrenci adı


Doğum tarihi (tarih formatı)


Boy





Kilo
-------------




ListBox kullanılacak


Adı ve Soyadı


Gün, ay, yıl ayrı listbox’larda olacak


Vücut kitle indeksi: kilo / boy*boy


Burç bilgisi


PictureBox üzerinde burç resmi



Cevap 1 – Açıklaması

Form Tasarımı
Formu 720x420 boyutunda yaptım ve ekrana ortaladım ki görünümü düzgün olsun. Kullanıcının bilgilerini girebilmesi için TextBox ve ListBox kullandım: Ad ve soyad için iki ayrı TextBox (txtAd, txtSoyad), boy ve kilo için birer TextBox (txtBoy, txtKilo) ve doğum tarihi için gün, ay, yıl seçimi yapabileceği üç ayrı ListBox (lbGun, lbAy, lbYil). Formun üst kısmına da hangi alanın ne için olduğunu gösteren Label’lar ekledim. Böylece kullanıcı kafası karışmadan bilgilerini girebiliyor.
Buton ve Hesaplama
Hesaplamayı yapmak için “Hesapla” butonu (btnHesapla) koydum. Butona tıklandığında program şu şekilde çalışıyor: Önce ad ve soyad girilip girilmediğine bakıyor, boşsa kullanıcıyı uyarıyor. Ardından gün, ay ve yılın seçilip seçilmediğini kontrol ediyor; eğer bir eksik varsa tekrar uyarı veriyor. Seçilen tarihin geçerli olup olmadığına da bakıyor, örneğin 31 Şubat gibi hatalı bir tarih engelleniyor. Boy ve kilo değerleri sıfır veya yanlış girilmişse kullanıcıya mesaj gösteriliyor. Her şey doğruysa BMI hesaplanıyor (kilo / (boy*boy)), doğum tarihine göre burç belirleniyor ve tüm bilgiler lblSonuc Label’ına yazdırılıyor. Son olarak seçilen burç resmini de PictureBox’a yükleyerek görsel olarak gösteriyorum.
Label ve PictureBox
lblSonuc kullanıcının tüm sonuçları görebileceği alan ve fontunu biraz büyüterek okunaklı hâle getirdim:
Font = new Font("Segoe UI", 12, FontStyle.Bold)
pbBurc ise burç resimlerini göstermek için kullanılıyor. Boyutu 400x200 ve resim Zoom modunda ekrana geliyor. Resimler bin\Debug\net8.0-windows\burclar klasöründe bulunuyor ve kod otomatik olarak burç adına uygun resmi bulup gösteriyor.
Burç Resimleri
Resimler hem .png hem .jpg formatında olabilir. Önemli olan isimlerin kodla birebir eşleşmesi; büyük/küçük harf ve Türkçe karakterler tam olmalı.



<img width="931" height="581" alt="image" src="https://github.com/user-attachments/assets/66204016-2c3c-4598-ad52-0f7fc7676945" />

 

 <img width="931" height="579" alt="image" src="https://github.com/user-attachments/assets/be62fe7d-2eed-49bb-b55c-1a7cdf2590a4" />



**Uygulama 1 || Soru 1-**
Bir ana pencere oluşturunuz. Sonra MouseClick mesajını işleyerek pencere içerisine tıklandığında tam tıklanan yer ortada kalacak biçimde 50x50'lik bir düğme yaratın. Düğmenlerin üzerinde sırasıyla 1, 2, 3 ... gibi sayıları yazdırınız.


Cevap 1 – Açıklaması

Önce bir tane Form1 sınıfı oluşturdum, bu bizim ana penceremiz. Form’un içine tıkladığımızda bir şeyler yapabilmek için Mouseclick kullandım.
Her tıklamada Form1MouseClick metodu çalışıyor. Bu metodun içinde yeni bir Button yarattım.
Düğmenin boyutunu 50x50 yaptım. Sonra düğmeyi tıkladığım yeri ortalayacak şekilde konum verdim.
Burada e.X ve e.Y tıklanan noktanın koordinatları. Ortalamak için yarısını çıkardım.
Düğmelerin üzerine sırasıyla 1, 2, 3 yazsın diye bir sayaç kullandım:
Ve en son da düğmeyi formun içine ekledim:
Çalıştırdığımda pencerenin üstündeki herhangi bir noktaya her tıkladığımda yeni bir düğme ve butonun üstündeki numaralar artıyor ve tıkladığın yerin ortasında çıkıyor.
Bir de random sınıf tanımladım ve backcolor random renkler almasını istedim. Her buton oluştuğunda farklı bir renkte oluşmasını sağladım. Her tıklayışımızda farklı renkte bir buton oluşuyor. Butonların üstündeki sayılar ise siyah olacak şekilde tasarladım.


<img width="931" height="556" alt="image" src="https://github.com/user-attachments/assets/feb23fb1-7163-4292-a767-36c9d2f761d3" />


 
**Uygulama 2 || Soru 1-**
Ana Pencere içerisinde 100x100'lük 10 tane düğmeyi aynı koordinatta ve büyüklükte üstü üste gelecek şekilde oluşturunuz. Düğmelerin üzerinde 1'den 10'a kadar sayılar bulunmalıdır. (Başlangıçta en üstte 10 numaralı düğme olacak) Hep en üstteki düğmeye tıklandığında, bu en üstte düğme en alta geçsin.

  
Cevap 1 – Açıklaması
Ana pencerede 10 tane düğme oluşturdum, hepsi aynı noktada ve aynı boyutta yani üst üste duruyor. Düğmelerin üzerinde 1’den 10’a kadar sayılar var. Başlangıçta en üstte 10 numaralı düğme oluyor.
Her düğmeye tıkladığımda o en üstteki düğme en alta geçiyor, yani yığın mantığıyla çalışıyor. Böylece her tıklamada üstteki düğme en alta gidiyor ve diğer düğmeler yukarı çıkıyor.
Ayrıca her düğme farklı renkte, böylece üst üste olsalar bile hangi düğmenin hangi sayı olduğunu rahatça görebiliyorum. Kodda Button sınıfını kullanıp hepsine aynı konum ve boyutu verdim, Random sınıfıyla da düğmelerin renklerini rastgele seçtim. Tıklama olayında SendToBack() metodunu kullanarak en üstteki düğmeyi en alta gönderiyorum. Yazıları beyaz yaptım ki kolay okunabilsin.
 

 <img width="634" height="369" alt="image" src="https://github.com/user-attachments/assets/7b4be887-c8da-4c0c-9d18-9e84707ac5a9" />

 <img width="636" height="377" alt="image" src="https://github.com/user-attachments/assets/0c54b3b9-f517-4999-b88e-9b2bd8382de9" />


**Uygulama 3 || Soru 1-**
Uygulama Ödevi 3: Bir ana pencere oluşturunuz. Sonra MouseClick mesajını işleyerek pencere içerisine tıklandığında tam tıklanan yer ortada kalacak biçimde 50x50'lik bir düğme yaratın.
Düğmenlerin üzerinde sırasıyla 1, 2, 3 ... gibi sayıları yazdırınız. Düğmelerin üzerine tıklandığında (Düğmenin Click eventini işleyeceksiniz) tıklanan düğme yok olsun.
Kontrolü yok etmek için Control sınıfının Dispose metodu kullanılmalıdır.


Cevap 1 – Açıklaması
Bir Windows Forms uygulaması yaptım. Programda amaç, fare ile tıklayınca o noktada 50x50 boyutunda bir düğme yaratmak ve üzerine sırasıyla 1, 2, 3… numara yazmak.
1.	buttonCounter adında bir değişken oluşturdum, her düğme için bir numara veriyor.
2.	Formun MouseClick olayını yakalayıp tıklanan noktanın koordinatlarını aldım.
3.	Yeni bir Button oluşturup tıklanan nokta ortada kalacak şekilde Left ve Top değerlerini ayarladım.
4.	Her düğmeye rastgele renk veriliyor, böylece her tıklama farklı bir görünüm sağlıyor.
5.	Düğmeye Click olayını ekledim. Bu sayede kullanıcı düğmeye tıklarsa Btn _Click  fonksiyonu çalışıyor ve düğmeyi kaldırıyor.
6.	btn.Dispose() metodunu kullanarak hem düğmeyi formdan kaldırıyoruz hem de belleği temizliyoruz.
7.	Her tıklamada yeni bir düğme oluşturuluyor ve numara artırılıyor, böylece sıralı bir sistem oluşuyor.


<img width="449" height="335" alt="image" src="https://github.com/user-attachments/assets/503d93d0-92d2-4518-b599-e8dd5b1f4eec" />

<img width="456" height="341" alt="image" src="https://github.com/user-attachments/assets/dc44c0ad-44c4-4883-a31d-99a73e609e41" />

**Uygulama 4 || Soru 1-** 
Uygulama Ödevi 3'ü öyle bir hale getiriniz ki yeni bir düğme yaratılacağı zaman bu yeni yaratılacak düğme silinen en düşük numaralı düğmenin numarasını alsın.

Cevap 1 – Açıklaması
Bu uygulamada form üzerine MouseClick olayı ile yeni düğmeler ekleniyor. Her düğmeye bir numara veriliyor fakat numaralandırma klasik olarak sırayla artmıyor. Bunun yerine, silinen düğmenin numarası tekrar kullanılabiliyor. Yani her yeni düğme için en küçük boş numara atanıyor.
Bunu gerçekleştirmek için bir List<int> kullanilanNumaralar yapısı tanımladım. Form üzerine tıklandığında:
•	Önce 1’den başlayarak listede olmayan en küçük numarayı buluyorum.
•	Bu numarayı düğmeye yazıyorum ve listeye ekliyorum.
•	Düğme rastgele bir arka plan rengi alıyor ve forma ekleniyor.
Düğmeye tıklanırsa:
•	Önce düğmenin üzerindeki numara okunuyor.
•	Bu numara listeden çıkarılıyor (yani yeniden kullanılabilir hale geliyor).
•	Ardından düğme formdan kaldırılıyor.
Bu uygulamada düğme ekleme/silme işlemleri yapılmış oluyor hem de numaralandırma sistemi en küçük boş numarayı yeniden kullanacak şekilde kontrol ediliyor.


<img width="597" height="438" alt="image" src="https://github.com/user-attachments/assets/2592ae07-90a0-4ba3-8271-b55181377dc7" />

<img width="600" height="427" alt="image" src="https://github.com/user-attachments/assets/75062f69-9a77-44cc-950c-8e5737fcd54a" />

 <img width="622" height="464" alt="image" src="https://github.com/user-attachments/assets/9801839f-2bef-43d4-a766-ea1fc4b0f545" />

**Uygulama 5 || Soru 1-**
Fare ile tıkladığımız zaman MouseDown mesajında farenin konumunu kaydediniz. Sonra fareyi hareket ettirip elinizi fareden çekince MouseUp mesajında yeni yeri elde ediniz. Sol üst köşesi eski yerde, sağ alt köşesi yeni yerde olacak şekilde düğme yaratınız.


Cevap 1 – Açıklaması


Bu uygulamada MouseDown anında farenin konumunu start olarak kaydediyorum. Sonra fareyi hareket ettirip tuşu bıraktığımda MouseUp ile end konumunu alıyorum. 

Ödevin istediği gibi butonun sol üst köşesini eski (start), sağ alt köşesini yeni (end) nokta olacak şekilde ayarlıyorum; yani Width = end.X - start.X, Height = end.Y - start.Y. 

Kullanıcı sola ya da yukarı doğru sürüklerse bu tanıma uymadığı için (genişlik veya yükseklik ≤ 0) buton oluşturmuyorum ve uyarı gösteriyorum. Butonu oluşturduktan sonra Controls.Add ile forma ekliyorum; tıklanınca kaldırmak için Click olayında Dispose() çağırıyorum. Böylece bas→bırak aralığında çizdiğim dikdörtgen ölçülerinde bir buton yaratmış oluyorum.


<img width="931" height="611" alt="image" src="https://github.com/user-attachments/assets/5ab5929c-f2f9-409b-9a23-127ddbfe966f" />

 
**Uygulama 6 || Soru 1-** 
Ana pencereye farenin sol tuşuyla tıkladığımızda bir düğme yaratın. Sonra fareyi sürüklediğimizde büyüyüp küçülsün. El fareden çekildiğinde düğme o boyutta kalsın.Düğmenin üzerinde de yine o düğmenin yaratılma numarası basılsın.

MouseMove, MouseDown ve Mouse mesajları işlenmelidir. Fare hareket ettirildikçe düğmenin konumu değişmeyecektir. Yalnızca boyutu değişecektir.


Cevap 1 – Açıklaması


Bu uygulamada fare ile sol tuşa tıkladığımda yeni bir düğme yaratıyorum. Oluşan düğmenin sol üst köşesi fareye tıklanan noktaya yerleştiriliyor ve üzerinde o düğmenin numarası görünüyor.
Fareyi sürüklediğimde MouseMove olayında düğmenin boyutunu değiştiriyorum; burada sol üst köşe sabit kalıyor, sağ alt köşe ise farenin konumuna göre ayarlanıyor. Yani fareyi yukarı veya sola çekerse düğmenin pozisyonunu da buna göre kaydırıyorum. 
Fareyi bıraktığımda (MouseUp) düğmenin boyutu artık sabitleniyor ve daha fazla değişmiyor. Böylece tıklama, sürükleme ve bırakma olaylarını kullanarak düğmenin konumunu ve boyutunu kontrol edebiliyorum.

<img width="931" height="697" alt="image" src="https://github.com/user-attachments/assets/591a9488-fe67-4a15-991a-3fbc5db80ac5" />




 
**Ödev Son || Soru 1-**
-    Form oluşturulacak ve aşağıdaki nesnelerin kullanılması gerekmektedir.
o    comvoBox
o    listBox
o    TextBox
o    Button
o    Label
o    RadioButton
o    CheckBox
ComboBox’tan bir item seçilmesine bağlı olarak ikinci bir Combox’ta farklı item’laron gelmesi gerekiyor.(Ör: ComboBox’tan herhangi bir il seçildiğinde, o ilin ilçelerinin gelmesi gibi).
Herbir comboBox için en az 10 tane item girilmelidir.
Bu uygulamada string metotların kullanılması gerekmektedir.
+puan >>> veritabanı bağlantısı


Cevap 1 – Açıklaması
Bu ödevimde Windows Forms kullanarak basit bir form uygulaması hazırladım. Amacım, kullanıcıdan bazı temel bilgileri almak ve bu bilgileri listeleyip kaydedebilmekti.
Formda kullandığım öğeler şunlar:
•	TextBox: Kullanıcının ad ve soyadını girmesi için.
•	ComboBox: İl ve ilçe seçimi için. İl seçimine bağlı olarak ikinci ComboBox’ta ilgili ilçeler listeleniyor. Bu sayede kullanıcı gerçek veriler üzerinden seçim yapabiliyor.
•	RadioButton: Cinsiyet seçimi için. Erkek veya Kadın seçenekleri mevcut.
•	CheckBox: Kullanıcının bilgilerini onaylaması için. Bu işaretlenmeden form listeye ekleme yapılmıyor.
•	ListBox: Girilen tüm bilgileri liste halinde gösteriyor.
•	Buttonlar: “Listeye Ekle” ile formdaki verileri ListBox’a ekleyebiliyoruz, “Dosyaya Kaydet” ile de tüm listeyi kisiler.txt dosyasına kaydedebiliyoruz.
•	Label: Kullanıcıya durum bilgisini göstermek için.
Bu projede dikkat ettiğim noktalar:
•	String metotları kullanarak ad-soyad bilgisini temizleyip listeye ekledim.
•	İl ve ilçe ComboBox’larını gerçek verilerle doldurdum.
•	Formun boyutunu ve kontrollerin yerleşimini kullanıcı dostu olacak şekilde ayarladım.
•	Buton ve ComboBox yazılarının görünmemesi gibi sorunları FlatStyle ve DropDownStyle ayarlarıyla çözdüm.
•	Kodun çalışması için sadece bir tane Main metodu kullandım ve gereksiz dosyaları silerek hatasız çalışmasını sağladım.



<img width="461" height="472" alt="image" src="https://github.com/user-attachments/assets/e11fefd6-072a-4e3b-957c-b9f33cd7a772" />

<img width="454" height="466" alt="image" src="https://github.com/user-attachments/assets/a9662eeb-4117-4c70-b58f-900a5781c006" />

