using System;
using System.Collections.Generic; // Dictionary için gerekli

namespace AnagramKontrol
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Anagram kontrol programına hoş geldiniz!");
            Console.WriteLine("Çıkmak için 'q' yazabilirsiniz.\n");

            while (true)
            {
                // Kullanıcıdan iki sözcük alıyoruz
                Console.Write("Birinci sözcüğü girin: ");
                string kelime1 = Console.ReadLine();

                if (kelime1.ToLower() == "q")
                    break;

                Console.Write("İkinci sözcüğü girin: ");
                string kelime2 = Console.ReadLine();

                if (kelime2.ToLower() == "q")
                    break;

                // Dictionary oluşturuyoruz: anahtar char, değer int
                Dictionary<char, int> sayac = new Dictionary<char, int>();

                // Birinci kelimenin karakterlerini sayıyoruz
                foreach (char c in kelime1)
                {
                    if (sayac.ContainsKey(c))
                    {
                        sayac[c]++; // karakter zaten varsa sayacı artır
                    }
                    else
                    {
                        sayac.Add(c, 1); // yoksa 1 olarak ekle
                    }
                }

                bool anagram = true;

                // İkinci kelimenin karakterlerini sayacı azaltarak kontrol ediyoruz
                foreach (char c in kelime2)
                {
                    if (sayac.ContainsKey(c))
                    {
                        sayac[c]--; // karakter var, sayacı azalt
                        if (sayac[c] < 0) // negatif olursa anagram olamaz
                        {
                            anagram = false;
                            break;
                        }
                    }
                    else
                    {
                        anagram = false; // karakter hiç yoksa anagram değil
                        break;
                    }
                }

                // Son olarak tüm karakterler dengeli mi kontrol ediyoruz
                if (anagram)
                {
                    foreach (var kvp in sayac)
                    {
                        if (kvp.Value != 0)
                        {
                            anagram = false;
                            break;
                        }
                    }
                }

                // Sonucu ekrana yazdırıyoruz
                if (anagram)
                {
                    Console.WriteLine($"'{kelime1}' ve '{kelime2}' birbirinin anagramıdır.\n");
                }
                else
                {
                    Console.WriteLine($"'{kelime1}' ve '{kelime2}' anagram değildir.\n");
                }
            }

            Console.WriteLine("Program sonlandırıldı.");
        }
    }
}
