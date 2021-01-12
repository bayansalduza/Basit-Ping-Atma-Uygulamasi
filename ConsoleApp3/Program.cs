using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation; //İlk yapacağımız iş bu sınıfı using kısmına eklemek.

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Ip adresi veya Host adresi giriniz: ");
                string host = Console.ReadLine();
                Console.Write("Atmak istediğiniz ping sayısını yazınız: ");
                int pingsayısı = Convert.ToInt32(Console.ReadLine());
                Ping ping = new Ping();
                try
                {
                    for (int i = 0; i < pingsayısı; i++)
                    {
                        var cevap = ping.Send(host);
                        if (cevap.Status == IPStatus.Success) //Attığımız pingin doğruluğunu kontrol ediyor.
                        {
                            Console.WriteLine("Ping atma başarılı"); //Bilgilendirme.
                            Console.WriteLine("İp adresi: " + cevap.Address); //Attığımız pingin IP adresi.
                            Console.WriteLine("TimeToLive: " + cevap.Options.Ttl); //Yaşama zamanı.
                            Console.WriteLine("Durum: " + cevap.Status); //Attığımız pingin durumu.
                            Console.WriteLine("Ping zamanı: " + DateTime.Now); //Pingi attığımız zaman.
                            Console.WriteLine("Time: " + cevap.RoundtripTime); //Pingin kaç ms de gittiği.
                        }
                        else
                        {
                            Console.WriteLine("Ping atma başarısız");
                            break;
                        }
                    }
                }
                catch
                {

                    Console.WriteLine("Yanlış IP veya Host");
                }

            }
        }
    }
}
