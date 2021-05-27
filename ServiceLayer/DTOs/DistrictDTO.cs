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

        public DistrictDTO()
        {
        }

        public DistrictDTO(int districtID)
        {
            DistrictID = districtID;
        }


        public DistrictDTO(District district)
        {
            DistrictID = district.DistrictID;
            DistrictName = district.DistrictName;
        }

        public static District DistrictDTOToModel(DistrictDTO district)
        {
            var toDistrict = new District(district.DistrictName, district.DistrictID);
            return toDistrict;
        }
    }
}