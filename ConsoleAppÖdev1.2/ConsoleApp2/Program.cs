using System;
using System.Collections; // Hashtable ve ArrayList için gerekli

namespace KarakterKontrol
{
    class Program
    {
        static void Main(string[] args)
        {
            // Program açılınca kullanıcıya bilgi veriyoruz
            Console.WriteLine("Karakter kontrol programına hoş geldiniz!");
            Console.WriteLine("Çıkmak için 'q' yazabilirsiniz.\n");

            // Programı sürekli çalıştırmak için while döngüsü
            while (true)
            {
                // Kullanıcıdan string alıyoruz
                Console.Write("Bir kelime ya da cümle girin: ");
                string input = Console.ReadLine();

                // Eğer kullanıcı 'q' yazarsa programı kapatıyoruz
                if (input.ToLower() == "q")
                {
                    Console.WriteLine("Program sonlandırılıyor...");
                    break; // döngüyü kırıyoruz
                }

                // Hashtable oluşturuyoruz, karakterleri ve sayılarını saklayacak
                Hashtable karakterler = new Hashtable();

                // string içindeki her karakteri tek tek kontrol ediyoruz
                foreach (char c in input)
                {
                    // Eğer karakter daha önce eklenmişse sayısını 1 artır
                    if (karakterler.ContainsKey(c))
                    {
                        int mevcutDeger = (int)karakterler[c]; // mevcut sayıyı alıyoruz
                        karakterler[c] = mevcutDeger + 1; // 1 artırıp geri koyuyoruz
                    }
                    else
                    {
                        // Eğer karakter daha önce yoksa, 1 olarak ekliyoruz
                        karakterler.Add(c, 1);
                    }
                }

                // Tekrar eden karakterlerin olup olmadığını kontrol edeceğiz
                bool tekrarVar = false;

                // Hashtable içindeki her karakteri dolaşıyoruz
                foreach (DictionaryEntry entry in karakterler)
                {
                    char karakter = (char)entry.Key; // karakteri alıyoruz
                    int sayi = (int)entry.Value;    // kaç kez geçtiğini alıyoruz

                    // Eğer bir karakter 1'den fazla geçiyorsa, tekrar ediyor demektir
                    if (sayi > 1)
                    {
                        Console.WriteLine($"Karakter '{karakter}' {sayi} kez tekrar ediyor.");
                        tekrarVar = true; // tekrar eden karakter bulundu
                    }
                }

                // Eğer tekrar eden karakter yoksa ekrana yazıyoruz
                if (!tekrarVar)
                {
                    Console.WriteLine("Tüm karakterler birbirinden farklı.");
                }

                // Daha güzel görünmesi için boş satır bırakıyoruz
                Console.WriteLine();
            }
        }
    }
}
