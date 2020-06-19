using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKomplet.Models;

namespace EKomplet.ServiceLayer.DTOs
{
    public class DistrictDTO
    {

        public int DistrictID { get; set; }
        public string DistrictName { get; set; }

        public DistrictDTO (District district)
        {
            this.DistrictID = district.DistrictID;
            this.DistrictName = district.DistrictName;
        }
    }
}
