using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKomplet.ServiceLayer.DTOs;

namespace EKomplet.ServiceLayer.ViewModel
{
    public class DeleteSalesmanFromDistrictModelView
    {

        public SalesmanDTO salesmanDTO { get; set; }
        public DistrictDTO district { get; set; }

        public DeleteSalesmanFromDistrictModelView(SalesmanDTO salesman, DistrictDTO district)
        {
            this.salesmanDTO = salesman;
            this.district = district;
        }
    }
}
