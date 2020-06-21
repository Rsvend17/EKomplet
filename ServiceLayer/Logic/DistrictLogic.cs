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

        public async Task<DistrictDTO> GetDistrictAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DistrictDTO _district = new DistrictDTO(await Context.Districts
                .FirstOrDefaultAsync(m => m.DistrictID == id));

            if (_district == null)
            {
                return NotFound();
            }
            return _district;
        }

        public async Task<bool> DeleteDistrictAsync(int districtID)
        {
            var district = await Context.Districts.FindAsync(districtID);
            Context.Districts.Remove(district);
            await Context.SaveChangesAsync();

            if(Context.Districts.Any(m => m.DistrictID != districtID))
            { return true; }
            else { return false; }
        }

        public async Task<bool> CreateDistrictAsync(DistrictDTO district)
        {
            try
            {
                await Context.Districts.AddAsync(DistrictDTOToDistrictModel(district));
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public async Task<bool> EditDistrictAsync(DistrictDTO district)
        {
            try
            {
                Context.Update(DistrictDTOToDistrictModelWithID(district));
                await Context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        private DistrictDTO NotFound()
        {
            throw new NotImplementedException();
        }
        private District DistrictDTOToDistrictModel(DistrictDTO districtDTO)
        {
            return new District(districtDTO.DistrictName);
        }

        private District DistrictDTOToDistrictModelWithID(DistrictDTO districtDTO)
        {
            return new District(districtDTO.DistrictName, districtDTO.DistrictID);
        }

        private bool DistrictExists(int id)
        {
            return Context.Districts.Any(e => e.DistrictID == id);
        }
    }
}
