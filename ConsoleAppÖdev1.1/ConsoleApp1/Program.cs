using System;
using System.Collections;

namespace SehirIlceOdevi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hashtable oluşturduk, şehirleri ve onların ilçelerini ekliyoruz
            Hashtable sehirler = new Hashtable();

            sehirler.Add("Bodrum", "Gümbet, Yalıkavak, Turgutreis, Bitez");
            sehirler.Add("Antalya", "Konyaaltı, Lara, Kepez, Alanya");
            sehirler.Add("Eskişehir", "Odunpazarı, Tepebaşı, Sivrihisar, Mahmudiye");

            Console.WriteLine("İlçe sorgulama programına hoş geldiniz!");

            while (true)
            {
                Console.Write("Bir şehir adı girin (çıkmak için 'q'): ");
                string sehir = Console.ReadLine();

                if (sehir.ToLower() == "q")
                {
                    Console.WriteLine("Programdan çıkılıyor...");
                    break;
                }

                if (sehirler.ContainsKey(sehir))
                {
                    Console.WriteLine(sehir + " şehir merkezine bağlı ilçeler: " + sehirler[sehir]);
                }
                else
                {
                    Console.WriteLine("Bu şehir listede yok. Lütfen başka bir şehir deneyin.");
                }

                Console.WriteLine();
            }
        }
    }
}
