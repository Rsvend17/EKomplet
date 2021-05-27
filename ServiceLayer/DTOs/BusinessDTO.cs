using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKomplet.Models;

namespace EKomplet.ServiceLayer.DTOs
{
    public class BusinessDTO
    {
        public int BusinessID { get; set; }
        public string BusinessName { get; set; }
        public int DistrictID { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }


        public BusinessDTO(Business business)
        {
            BusinessID = business.BusinessID;
            BusinessName = business.BusinessName;
            DistrictID = business.BusinessID;
            Address = business.Adress;
            ZipCode = business.ZipCode;
        }
    }
}