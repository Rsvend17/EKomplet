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
        public string DistrictName { get; set; }
        [Required]
        public int SalesmanID { get; set; }
        public Salesman Salesman { get; set; }

    }
}
