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
            Context = context;
        }


        public async Task<List<DistrictDTO>> GetDistrictsAsync()
        {
#pragma warning disable IDE0059 // Unnecessary assignment of a value


            return (from d in await Context.Districts.ToListAsync() select new DistrictDTO(d)).ToList();
        }

        public async Task<DistrictDTO> GetDistrictAsync(int? id)
        {
            if (id == null) return NotFound();
            var district = new DistrictDTO(await Context.Districts
                .FirstOrDefaultAsync(m => m.DistrictID == id));

            return district ?? NotFound();
        }

        public async Task<bool> DeleteDistrictAsync(int districtID)
        {
            var district = await Context.Districts.FindAsync(districtID);
            Context.Districts.Remove(district);
            await Context.SaveChangesAsync();

            if (Context.Districts.Any(m => m.DistrictID != districtID))
                return true;
            else
                return false;
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

        private static DistrictDTO NotFound()
        {
            throw new NotImplementedException();
        }

        
        private static District DistrictDTOToDistrictModel(DistrictDTO districtDTO)
        {
            return new District(districtDTO.DistrictName);
        }

        private static District DistrictDTOToDistrictModelWithID(DistrictDTO districtDTO)
        {
            return new District(districtDTO.DistrictName, districtDTO.DistrictID);
        }
    }
}