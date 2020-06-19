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

            if (context.Districts.Any())
            {
                return;
            }

            var salesmen = new Salesman[]
            {
                new Salesman{PhoneNumber = 29223018, Email =" Hej23@hotmail.com", FirstName="Birke", LastName=" Didricksen"}
            };
            foreach(Salesman s in salesmen)
            {
                context.Add(s);
            }
            context.SaveChanges();

            var districts = new District[]
            {
                new District{DistrictName = "Hellerup", SalesmanID = 1},
                new District{DistrictName = "Skanderborg", SalesmanID = 1}
            };

            foreach(District d in districts)
            {
                context.Districts.Add(d);
            }
            context.SaveChanges();
        }
    }
}
