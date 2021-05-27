using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKomplet.Models;
using EKomplet.ServiceLayer.DTOs;

namespace EKomplet.ServiceLayer.ViewModel
{
    public class DistrictCreateViewModel
    {
        public District district { get; set; }
        public SalesmenStatus salesmenStatus { get; set; }
        public IEnumerable<SalesmanDTO> Salesmen { get; set; }


        public DistrictCreateViewModel(IEnumerable<SalesmanDTO> salesmen)
        {
            Salesmen = salesmen;
        }
    }
}