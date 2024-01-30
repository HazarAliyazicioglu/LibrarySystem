using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> kitapIsimleri = new List<string> {
                "Yüzüklerin Efendisi: Yüzük Kardeşliği",
                "Yüzüklerin Efendisi: İki Kule",
                "Yüzüklerin Efendisi: Kralın Dönüşü",
                "Hobbit",
                "Harry Potter ve Felsefe Taşı",
                "Harry Potter ve Sırlar Odası",
                "Harry Potter ve Azkaban Tutsağı",
                "Harry Potter ve Ateş Kadehi",
                "Harry Potter ve Zümrüdüanka Yoldaşlığı",
                "Harry Potter ve Melez Prens",
                "Harry Potter ve Ölüm Yadigârları"};

            List<string> kitapYazarlari = new List<string> { "J.R.R.TOLKIEN", "J.R.R.Tolkien", "J.R.R.Tolkien", "J.R.R.Tolkien", "J.K.Rowling", "J.K.Rowling", "J.K.Rowling", "J.K.Rowling", "J.K.Rowling", "J.K.Rowling", "J.K.Rowling" };
            List<string> kitapISBN = new List<string> {
                "975342163",
                "927542169",
                "975357533",
                "941376163",
                "978975080",
                "971936080",
                "97892931",
                "9789754",
                "978802972",
                "97508021",
                "978975092"};
            List<int> kitapKopya = new List<int> { 12, 11, 15, 9, 16, 13, 13, 18, 21, 10, 32 };
            List<int> kitapOdunc = new List<int> { 3, 1, 0, 2, 1, 4, 3, 5, 2, 0, 6 };

            while (true)
            {
                Console.WriteLine("İŞLEM MENÜSÜ");
                Console.WriteLine();
                Console.WriteLine("1- Tüm Kitaplar");
                Console.WriteLine("2- Kitap Ödünç Alımı");
                Console.WriteLine("3- Kitap İadesi");
                Console.WriteLine("4- Kitap Ekleme");
                Console.WriteLine("5- Kitap Arama");
                Console.WriteLine("6- Süresi Geçmiş Kitaplar");
                Console.WriteLine("7- Çıkış");
                Console.WriteLine();
                Console.Write("Yapmak İstediğiniz İşlemin Numarası: ");
                string islem;
                islem = Convert.ToString(Console.ReadLine());
                Console.Clear();

                if (islem == "1")
                {
                    for (int i = 0; i < kitapIsimleri.Count(); i++)
                    {
                        Console.WriteLine("KİTAP " + (i + 1));
                        Console.WriteLine();
                        Console.WriteLine("Kitap İsmi: " + kitapIsimleri[i]);
                        Console.WriteLine("Yazar: " + kitapYazarlari[i]);
                        Console.WriteLine("ISBN: " + kitapISBN[i]);
                        Console.WriteLine("Kalan Kopya Sayısı: " + kitapKopya[i]);
                        Console.WriteLine("Ödünç Alınan Kitap Sayısı: " + kitapOdunc[i]);
                        Console.WriteLine("*************************");
                        Console.WriteLine();
                    }

                    Console.Write("Ana Menüye Geri Dönmek İçin Enter Tuşuna Basınız.");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        continue;
                    }
                }
                else if (islem == "2")
                {
                    int kitapSecimi;
                    string dogrula;
                    DateTime bugun = DateTime.Today;
                    while (true)
                    {
                        try
                        {
                            Console.Write("Almak İstediğiniz Kitabın Numarasını Giriniz:");
                            kitapSecimi = Convert.ToInt32(Console.ReadLine());

                            bool inputValid;
                            if (kitapSecimi <= kitapIsimleri.Count() && kitapSecimi > 0)
                            {
                                inputValid = true;
                            }
                            else
                            {
                                inputValid = false;
                                Console.WriteLine("Lütfen geçerli bir kitap numarası giriniz.");
                            }

                            if (inputValid)
                            {
                                for (int i = kitapSecimi - 1; i <= kitapSecimi - 1; i++)
                                {
                                    while (true)
                                    {
                                        Console.WriteLine();
                                        Console.Write("Bu Kitabı Almak İstediğinize Emin Misiniz? (Y/N) ");
                                        dogrula = Console.ReadLine();
                                        if (dogrula.ToUpper() == "Y")
                                        {
                                            Console.Clear();
                                            Console.WriteLine(kitapIsimleri[i] + " Kitabını Ödünç Aldınız.");
                                            Console.WriteLine("Son Teslim Tarihi: " + bugun.AddDays(15).ToString("dd/MM/yyyy ") + "23:59");
                                            Console.WriteLine("*************************");
                                            Console.WriteLine();
                                            kitapKopya[0] -= 1;
                                            kitapOdunc[0] += 1;

                                            Console.Write("Ana Menüye Geri Dönmek İçin Enter Tuşuna Basınız.");
                                            ConsoleKeyInfo keyInfo = Console.ReadKey();
                                            if (keyInfo.Key == ConsoleKey.Enter)
                                            {
                                                Console.Clear();
                                                inputValid = false;
                                                break;
                                            }
                                        }
                                        else if (dogrula.ToUpper() == "N")
                                        {
                                            Console.Clear();
                                            inputValid = false;
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Lütfen Tekrar Deneyiniz.");
                                            inputValid = false;
                                            continue;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Lütfen Tekrar Deneyiniz.");
                                continue;
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.Clear();
                            Console.WriteLine("Lütfen Sayı Giriniz.");
                            continue;
                        }
                    }
                }
                else if (islem == "3")
                {
                    while (true)
                    {
                        Console.Write("İade Etmek İstediğiniz Kitabın Tam İsmini Giriniz: ");
                        string kitapIade = Convert.ToString(Console.ReadLine());
                        bool eslesmeVar = false;

                        foreach (string isim in kitapIsimleri)
                        {
                            if (kitapIade.ToUpper() == isim.ToUpper())
                            {
                                Console.Clear();
                                Console.WriteLine(isim + " Kitabı İade Edildi");
                                eslesmeVar = true;
                                break;
                            }
                        }

                        if (!eslesmeVar)
                        {
                            Console.Clear();
                            Console.WriteLine("Lütfen Kitabın Tam Adını Giriniz");
                        }
                        else
                        {
                            break;
                        }
                    }

                    Console.Write("Ana Menüye Geri Dönmek İçin Enter Tuşuna Basınız.");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        continue;
                    }
                }
                else if (islem == "4")
                {
                    string yeniKitapİsim;
                    string yeniKitapYazar;
                    string yeniKitapISBN;
                    while (true)
                    {
                        while (true)
                        {
                            Console.Write("Eklemek İstediğiniz Kitabın İsmini Yazınız: ");
                            yeniKitapİsim = Convert.ToString(Console.ReadLine());

                            if (yeniKitapİsim.Any(a => !Char.IsDigit(a)))
                            {
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Lütfen Kitap İsmi Yazınız.");
                                continue;
                            }
                        }
                        while (true)
                        {
                            Console.Write("Eklemek İstediğiniz Kitabın Yazarını Yazınız: ");
                            yeniKitapYazar = Convert.ToString(Console.ReadLine());

                            if (yeniKitapYazar.Any(b => !Char.IsDigit(b)))
                            {
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Lütfen Kitap Yazarının İsmini Yazınız.");
                                continue;
                            }
                        }
                        while (true)
                        {
                            Console.Write("Eklemek İstediğiniz Kitabın ISBN Numarasını Yazınız: ");
                            yeniKitapISBN = Convert.ToString(Console.ReadLine());

                            if (yeniKitapISBN.Any(c => !Char.IsDigit(c)))
                            {
                                Console.Clear();
                                Console.WriteLine("Lütfen Kitap ISBN Numarasını Yazınız.");
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }

                        Console.Clear();
                        Console.WriteLine("*************************");
                        Console.WriteLine("Kitap İsmi: " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(yeniKitapİsim));
                        Console.WriteLine("Kitap Yazarı: " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(yeniKitapYazar));
                        Console.WriteLine("Kitap ISBN: " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(yeniKitapISBN));
                        Console.WriteLine();
                        Console.Write("Yukarıdaki Bilgiler Doğru Mu? (Y/N)");
                        string dogrula = Console.ReadLine();

                        if (dogrula.ToUpper() == "Y")
                        {
                            kitapIsimleri.Add(yeniKitapİsim);
                            kitapYazarlari.Add(yeniKitapYazar);
                            kitapISBN.Add(yeniKitapISBN);
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            continue;
                        }
                        
                    }
                    Console.Write("Ana Menüye Geri Dönmek İçin Enter Tuşuna Basınız.");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        continue;
                    }
                }
                else if (islem == "5")
                {
                    while (true)
                    {
                        Console.Write("Aramak İstediğiniz Kitabın Tam İsmini Giriniz: ");
                        string kitapAranan = Convert.ToString(Console.ReadLine());
                        bool kitapBulundu = false;
                        bool vazgeçildi = false;

                        for (int i = 0; i < kitapIsimleri.Count(); i++)
                        {
                            if (kitapAranan.ToUpper() == kitapIsimleri[i].ToUpper())
                            {
                                Console.Clear();
                                Console.WriteLine("Kitap İsmi: " + kitapIsimleri[i]);
                                Console.WriteLine("Yazar: " + kitapYazarlari[i]);
                                Console.WriteLine("ISBN: " + kitapISBN[i]);
                                Console.WriteLine("Kalan Kopya Sayısı: " + kitapKopya[i]);
                                Console.WriteLine("Ödünç Alınan Kitap Sayısı: " + kitapOdunc[i]);
                                Console.WriteLine("*************************");
                                Console.WriteLine();
                                Console.Write("Kitabı Almak İster Misiniz? (Y/N)");
                                string dogrula = Console.ReadLine();
                                if (dogrula.ToUpper() == "Y")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine(kitapIsimleri[i] + " Kitabı Alınmıştır");
                                    kitapKopya[i] -= 1;
                                    kitapOdunc[i] += 1;
                                    kitapBulundu = true;
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    vazgeçildi = true;
                                    break;
                                }
                            }
                        }

                        if (vazgeçildi)
                        {
                            continue;
                        }

                        if (!kitapBulundu)
                        {
                            Console.Clear() ;
                            Console.WriteLine("Kitap Bulunamadı. Lütfen Doğru Bir Kitap İsmi Giriniz.");
                            continue;
                        }
                        else if (kitapBulundu)
                        {
                            break;
                        }
                    }
                    Console.Write("Ana Menüye Geri Dönmek İçin Enter Tuşuna Basınız.");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        continue;
                    }
                }
                else if (islem == "6")
                {
                    Console.WriteLine("Süresi Geçmiş kitap Bulunmamaktadır.");

                    Console.Write("Ana Menüye Geri Dönmek İçin Enter Tuşuna Basınız.");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        continue;
                    }
                }
                else if (islem == "7")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Lütfen Geçerli Bir Sayı Giriniz.");
                    Console.WriteLine();
                }

            }
        }
    }
}
