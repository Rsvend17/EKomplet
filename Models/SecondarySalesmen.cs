using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKomplet.Models
{
    public class SecondarySalesmen
    {
        public int SalesmanID { get; set; }
        public string DistrictName{ get; set; }
        public Salesman Salesman { get; set; }
        public District District { get; set; }
    }
}
