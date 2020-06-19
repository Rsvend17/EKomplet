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
    public class DistrictLogic
    {
        public DistrictDBContext Context { get; set; }

        public DistrictLogic(DistrictDBContext context)
        {
            this.Context = context;
        }


        public async Task<List<DistrictDTO>> GetDistrictsAsync()
        {
            List<DistrictDTO> _Districts = new List<DistrictDTO>();

#pragma warning disable IDE0059 // Unnecessary assignment of a value
            foreach (District d in await Context.Districts.ToListAsync())
#pragma warning restore IDE0059 // Unnecessary assignment of a value
            {
                _Districts.Add(new DistrictDTO(d));
            }


            return _Districts;
        }

    }
}
