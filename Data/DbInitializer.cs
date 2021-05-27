using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKomplet.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace EKomplet.Data
{
    public class DbInitializer
    {
        public static void Initialize(DistrictDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Districts.Any()) return;


            var districts = new District[]
            {
                new District("Nordjylland"),
                new District("Midtjylland"),
                new District("Sønderjylland"),
                new District("Østjylland"),
                new District("Fyn"),
                new District("Sjælland"),
                new District("København")
            };

            foreach (var d in districts) context.Districts.Add(d);
            context.SaveChanges();

            var salesmen = new Salesman[]
            {
                new Salesman
                {
                    PhoneNumber = 29223018, Email = "3ilyes.hamliliy@boarebec.gq", FirstName = "Maria",
                    LastName = " Hansen"
                },
                new Salesman
                {
                    PhoneNumber = 59537894, Email = "yihsan.niazi@perresu.gq", FirstName = "Marie",
                    LastName = " Didricksen"
                },
                new Salesman
                {
                    PhoneNumber = 44861150, Email = "cabdoelrah@toughblarbarw.ml", FirstName = "Esther ",
                    LastName = "Pedersen"
                },
                new Salesman
                {
                    PhoneNumber = 11047129, Email = "7osman.gebr@walmarte-shop.com", FirstName = "Sara",
                    LastName = " Hansen"
                },
                new Salesman
                {
                    PhoneNumber = 93962566, Email = "you-m97p@mylittleali.ml", FirstName = "Elise",
                    LastName = "Gregersen"
                },
                new Salesman
                {
                    PhoneNumber = 11224489, Email = "tbabich.messiz@elmenormi.tk", FirstName = "Mark",
                    LastName = "Pedersen"
                },
                new Salesman
                {
                    PhoneNumber = 68979197, Email = "mchriscoobbers@presaper.cf", FirstName = "Leo",
                    LastName = " Hansen"
                },
                new Salesman
                {
                    PhoneNumber = 36486664, Email = "ealkass@doctxyle.ml", FirstName = "Peter", LastName = "Teglsgaard"
                },
                new Salesman
                {
                    PhoneNumber = 73140749, Email = "ichouki-starf@lokingmi.cf", FirstName = "Tobias",
                    LastName = " Hansen"
                },
                new Salesman
                {
                    PhoneNumber = 37887231, Email = "hayoub.fa@citywinetour.com", FirstName = "Jonathan",
                    LastName = "Gregersen"
                }
            };
            foreach (var s in salesmen) context.Salesmen.Add(s);
            context.SaveChanges();


            var businesses = new Business[]
            {
                new Business {Adress = "Hundslevgyden 55", BusinessName = "Tiger", DistrictID = 6, ZipCode = 1725},
                new Business {Adress = "Højbovej 71", BusinessName = "H&M", DistrictID = 7, ZipCode = 1115},
                new Business {Adress = "Ribelandevej 81", BusinessName = "Baby Tøj", DistrictID = 3, ZipCode = 1242},
                new Business {Adress = "Mosegårdsvej 89", BusinessName = "Tiger", DistrictID = 5, ZipCode = 2131},
                new Business {Adress = "Ribelandevej 84", BusinessName = "Donuts", DistrictID = 4, ZipCode = 4323},
                new Business {Adress = "Eskelundsvej 16", BusinessName = "E-Komplet", DistrictID = 2, ZipCode = 2212},
                new Business {Adress = "Lodskovvej 37", BusinessName = "Tiger", DistrictID = 6, ZipCode = 3187},
                new Business {Adress = "Ørbækvej 97", BusinessName = "Macdonald's", DistrictID = 7, ZipCode = 1232}
            };
            foreach (var b in businesses) context.Add(b);
            context.SaveChanges();

            var salesmenInBusiness = new SalesmenInBusiness[]
            {
                new SalesmenInBusiness {SalesmanID = 1, BusinessID = 1},
                new SalesmenInBusiness {SalesmanID = 2, BusinessID = 2},
                new SalesmenInBusiness {SalesmanID = 3, BusinessID = 3},
                new SalesmenInBusiness {SalesmanID = 4, BusinessID = 4},
                new SalesmenInBusiness {SalesmanID = 5, BusinessID = 5},
                new SalesmenInBusiness {SalesmanID = 6, BusinessID = 6},
                new SalesmenInBusiness {SalesmanID = 7, BusinessID = 7},
                new SalesmenInBusiness {SalesmanID = 8, BusinessID = 8},
                new SalesmenInBusiness {SalesmanID = 9, BusinessID = 1},
                new SalesmenInBusiness {SalesmanID = 10, BusinessID = 2},
                new SalesmenInBusiness {SalesmanID = 1, BusinessID = 3},
                new SalesmenInBusiness {SalesmanID = 2, BusinessID = 4},
                new SalesmenInBusiness {SalesmanID = 3, BusinessID = 5}
            };
            foreach (var b in salesmenInBusiness) context.SalesmenInBusinesses.Add(b);
            context.SaveChanges();

            var salesmenStatus = new SalesmenStatus[]
            {
                new SalesmenStatus {SalesmanID = 1, DistrictID = 1, Status = Status.Primary},
                new SalesmenStatus {SalesmanID = 2, DistrictID = 2, Status = Status.Primary},
                new SalesmenStatus {SalesmanID = 3, DistrictID = 3, Status = Status.Primary},
                new SalesmenStatus {SalesmanID = 4, DistrictID = 4, Status = Status.Primary},
                new SalesmenStatus {SalesmanID = 5, DistrictID = 5, Status = Status.Primary},
                new SalesmenStatus {SalesmanID = 6, DistrictID = 6, Status = Status.Primary},
                new SalesmenStatus {SalesmanID = 7, DistrictID = 7, Status = Status.Primary},
                new SalesmenStatus {SalesmanID = 8, DistrictID = 1, Status = Status.Secondary},
                new SalesmenStatus {SalesmanID = 9, DistrictID = 2, Status = Status.Secondary},
                new SalesmenStatus {SalesmanID = 10, DistrictID = 3, Status = Status.Secondary}
            };

            foreach (var s in salesmenStatus) context.SalesmenStatuses.Add(s);
            context.SaveChanges();
        }
    }
}