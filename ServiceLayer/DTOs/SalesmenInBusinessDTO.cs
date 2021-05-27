using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKomplet.Models;

namespace EKomplet.ServiceLayer.DTOs
{
    public class SalesmenInBusinessDTO
    {
        public int BusinessID { get; set; }
        public int SalesmanID { get; set; }

        public SalesmenInBusinessDTO(SalesmenInBusiness s)
        {
            BusinessID = s.BusinessID;
            SalesmanID = s.SalesmanID;
        }
    }
}