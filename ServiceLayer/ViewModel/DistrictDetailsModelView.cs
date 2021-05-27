using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKomplet.ServiceLayer.DTOs;

namespace EKomplet.ServiceLayer.ViewModel
{
    public class DistrictDetailsModelView
    {
        public DistrictDTO District { get; set; }
        public List<SalesmanDTO> Salesmen { get; set; }
        public List<BusinessDTO> Businesses { get; set; }


        public DistrictDetailsModelView(DistrictDTO district, List<SalesmanDTO> salesmen, List<BusinessDTO> businesses)
        {
            District = district;
            Salesmen = salesmen;
            Businesses = businesses;
        }
    }
}