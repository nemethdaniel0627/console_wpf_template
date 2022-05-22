using System;
using System.Collections.Generic;
using System.Linq;

namespace RealEstate
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ad> ads = Ad.LoadFromCsv("realestates.csv");

            Console.WriteLine("6. feladat: Földszinti ingatlanok átlagos területe: {0:f2}", ads.Where(ad => ad.Floors == 0).Average(ad => ad.Area));

            var legkozelebbi = ads.Where(ad => ad.FreeOfCharge == true).OrderBy(ad => ad.DistanceTo(47.4164220114023, 19.066342425796986)).First();

            Console.WriteLine("8. feladat: Mesevár Óvodához légvonalban legközelebbi tehermentes ingatlan adatai:");
            Console.WriteLine("\tEladó neve: {0}", legkozelebbi.Seller.Name);
            Console.WriteLine("\tEladó telefonja: {0}", legkozelebbi.Seller.Phone);
            Console.WriteLine("\tAlapterület: {0}", legkozelebbi.Area);
            Console.WriteLine("\tSzobák száma: {0}", legkozelebbi.Rooms);

            Console.ReadLine();
        }
    }
}
