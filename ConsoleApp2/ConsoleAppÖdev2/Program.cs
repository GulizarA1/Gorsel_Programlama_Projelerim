using System;
using System.Collections;
using System.IO; // Directory ve dosya işlemleri için

namespace DirectoryListExample
{
    // DirectoryList sınıfı IEnumerable arayüzünü destekliyor
    public class DirectoryList : IEnumerable
    {
        private string[] m_files; // Dizindeki dosya isimlerini saklayacak dizi

        // Constructor: dizin yolunu alır ve dosyaları diziye atar
        public DirectoryList(string dir)
        {
            try
            {
                // Directory.GetFiles ile dizindeki dosyaları alıyoruz
                m_files = Directory.GetFiles(dir);
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
                m_files = new string[0]; // hata olursa boş dizi
            }
        }

        // GetEnumerator, IEnumerable arayüzünden geliyor
        public IEnumerator GetEnumerator()
        {
            return new DirectoryListEnumerator(this);
        }

        // İç sınıf: DirectoryListEnumerator
        private class DirectoryListEnumerator : IEnumerator
        {
            private DirectoryList m_dl; // ana sınıf referansı
            private int m_index;        // sayım için indeks

            // Constructor
            public DirectoryListEnumerator(DirectoryList dl)
            {
                m_dl = dl;
                m_index = -1; // ilk elemandan önce başlatıyoruz
            }

            // IEnumerator.Current
            public object Current
            {
                get
                {
                    if (m_index < 0 || m_index >= m_dl.m_files.Length)
                        throw new InvalidOperationException();
                    return m_dl.m_files[m_index];
                }
            }

            // IEnumerator.MoveNext
            public bool MoveNext()
            {
                if (m_index < m_dl.m_files.Length - 1)
                {
                    m_index++;
                    return true;
                }
                else
                    return false;
            }

            // IEnumerator.Reset
            public void Reset()
            {
                m_index = -1;
            }
        }
    }

    // Test için Main metodu
    class Program
    {
        static void Main()
        {
            DirectoryList dl = new DirectoryList(@"c:\windows");

            try
            {
                // foreach ile DirectoryList üzerinde geziniyoruz
                foreach (string s in dl)
                {
                    Console.WriteLine(s);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
