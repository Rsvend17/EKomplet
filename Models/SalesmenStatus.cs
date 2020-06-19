using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EKomplet.Models
{
    public enum Status
    {
        Primary,
        Secondary
    }

    public class SalesmenStatus
    { 
        public int SalesmanID { get; set; }
        public int DistrictID { get; set; }

        public Status? Status { get; set; }

        public Salesman Salesman { get; set; }
        public District District { get; set; }
    }
}
