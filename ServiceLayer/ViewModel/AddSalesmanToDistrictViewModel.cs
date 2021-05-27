using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKomplet.ServiceLayer.DTOs;

namespace EKomplet.ServiceLayer.ViewModel
{
    public class AddSalesmanToDistrictViewModel
    {
        public DistrictDTO district { get; set; }
        public SalesmenStatusDTO salesmenStatus { get; set; }

        public AddSalesmanToDistrictViewModel()
        {
        }
    }
}