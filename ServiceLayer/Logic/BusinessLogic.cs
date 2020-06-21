using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EKomplet.Data;
using EKomplet.Models;
using EKomplet.ServiceLayer.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EKomplet.ServiceLayer.Logic
{
    public class BusinessLogic
    {

        public DistrictDBContext Context { get; set; }

        public BusinessLogic (DistrictDBContext context)
        {
            this.Context = context;
        }



        public async Task<List<BusinessDTO>> GetBusinessesInDistrictAsync(int? districtID)
        {
            if(districtID == null)
            {
                throw new Exception("District ID was not found");
            }

            List<BusinessDTO> businesses = new List<BusinessDTO>();

            foreach (Business b in await Context.Businesses.Where(m => m.DistrictID == districtID).ToListAsync())
            {
                businesses.Add(new BusinessDTO(b));
            }


            return businesses;
        }
    }
}
