using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EKomplet.Models
{
    public class Business
    {
        [Key] public int BusinessID { get; set; }
        public string BusinessName { get; set; }
        public int DistrictID { get; set; }
        public string Adress { get; set; }
        public int ZipCode { get; set; }

        public District District { get; set; }
    }
}