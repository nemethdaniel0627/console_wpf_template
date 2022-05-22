using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace RealEstate
{
    public class Ad
    {
        //id;rooms;latlong;floors;area;description;freeOfCharge;imageUrl;createAt;sellerId;sellerName;sellerPhone;categoryId;categoryName
        public int Id { get; set; }
        public int Rooms { get; set; }
        public string LatLong { get; set; }
        public int Floors { get; set; }
        public int Area { get; set; }
        public string Description { get; set; }
        public bool FreeOfCharge { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateAt { get; set; }
        public Seller Seller { get; set; }
        public Category Category { get; set; }

        public Ad(string sor)
        {
            string[] adatok = sor.Split(";");
            Id = int.Parse(adatok[0]);
            Rooms = int.Parse(adatok[1]);
            LatLong = adatok[2];
            Floors = int.Parse(adatok[3]);
            Area = int.Parse(adatok[4]);
            Description = adatok[5];
            FreeOfCharge = adatok[6] == "0" ? false : true;
            ImageUrl = adatok[7];
            CreateAt = Convert.ToDateTime(adatok[8]);
            Seller = new Seller();
            Seller.Id = int.Parse(adatok[9]);
            Seller.Name = adatok[10];
            Seller.Phone = adatok[11];
            Category = new Category();
            Category.Id = int.Parse(adatok[12]);
            Category.Name = adatok[13];

        }

        public static List<Ad> LoadFromCsv(string faljnev)
        {
            List<Ad> adatok = new List<Ad>();
            File.ReadAllLines(faljnev).Skip(1).ToList().ForEach(sor => adatok.Add(new Ad(sor)));
            return adatok;
        }

        public double DistanceTo(double x, double y)
        {
            double latitude = Convert.ToDouble(LatLong.Split(",")[0].Replace(".", ","));
            double longitude = Convert.ToDouble(LatLong.Split(",")[1].Replace(".", ","));
            return Math.Sqrt(((x - latitude) * (x - latitude)) + ((y - longitude) * (y - longitude)));
        }
    }
}
