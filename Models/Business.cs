using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKomplet.Models
{
    public class Business
    {
        public string BusinessName { get; set; }
        public string DistrictName { get; set; }
        public string Adress { get; set; }
        public int ZipCode { get; set; }

        public District District { get; set; }


    }
}
