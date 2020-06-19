using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EKomplet.Models
{
    public class District
    {
        [Key]
        public int DistrictID { get; set; }
        
        public string DistrictName { get; set; }


    }
}
