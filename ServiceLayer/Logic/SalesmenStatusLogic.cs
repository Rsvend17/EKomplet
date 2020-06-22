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
    public class SalesmenStatusLogic
    {

        public DistrictDBContext Context { get; set; }

        public SalesmenStatusLogic(DistrictDBContext context)
        {
            this.Context = context;
        }


        public async Task<List<SalesmenStatusDTO>> GetSalesmenStatusesAsync(int? districtID)
        {
            if (districtID == null)
            {
                throw new Exception("ID not found");
            }

            List<SalesmenStatusDTO> salesmenStatuses = new List<SalesmenStatusDTO>();

            foreach (SalesmenStatus s in await Context.SalesmenStatuses.Where(s => s.DistrictID == districtID).ToListAsync())
            {
                salesmenStatuses.Add(new SalesmenStatusDTO(s));
            }


            return salesmenStatuses;
        }

        public async Task<List<SalesmenStatusDTO>> GetSalesmenStatusesInDistrictAsync(int? districtID)
        {
            if (districtID == null)
            {
                throw new Exception("ID not found");
            }

            List<SalesmenStatusDTO> _salesmenStatuses = new List<SalesmenStatusDTO>();

            foreach (SalesmenStatus s in await Context.SalesmenStatuses.Where(s => s.DistrictID == districtID).ToListAsync())
            {
                _salesmenStatuses.Add(new SalesmenStatusDTO(s));
            }

            return _salesmenStatuses;
        }

        public async Task<List<SalesmanDTO>> GetSalesmenInDistrictAsync(List<SalesmanDTO> salesmen, int? districtID)
        {

            List<SalesmenStatusDTO> _salesmenStatuses = await GetSalesmenStatusesInDistrictAsync(districtID);

            salesmen.RemoveAll(x => _salesmenStatuses.Exists(y => y.SalesmanID == x.SalesmanID));

            return salesmen;
        }

        public async Task<bool> CreateSalesmanStatusPrimaryAsync(SalesmenStatusDTO salesmenStatus, string districtName)
        {
            var _District = await Context.Districts.Where(m => m.DistrictName == districtName).FirstOrDefaultAsync();
            try
            {
                await Context.SalesmenStatuses.AddAsync(ConvertSalesmenStatusDTOPrimaryToModel(salesmenStatus, _District.DistrictID));
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> CreateSalesmanStatusPrimaryAsync(SalesmenStatusDTO salesmenStatus, int districtID)
        {

            try
            {
                await Context.SalesmenStatuses.AddAsync(ConvertSalesmenStatusDTOPrimaryToModel(salesmenStatus, districtID));
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> CreateSalesmanStatusSecondaryAsync(SalesmenStatusDTO salesmenStatus, int districtID)
        {

            try
            {
                await Context.SalesmenStatuses.AddAsync(ConvertSalesmenStatusDTOSecondaryToModel(salesmenStatus, districtID));
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteSalesmanFromDistrictAsync(int districtID, int salesmanID)
        {
            var SalesmanStatus = await Context.SalesmenStatuses.Where(m => m.DistrictID == districtID).Where(m => m.SalesmanID == salesmanID).FirstAsync();
            Context.SalesmenStatuses.Remove(SalesmanStatus);
            await Context.SaveChangesAsync();
            return true;

        }

        private SalesmenStatus ConvertSalesmenStatusDTOPrimaryToModel(SalesmenStatusDTO salesmenStatus, int districtID)
        {
            return new SalesmenStatus(salesmenStatus.SalesmanID, districtID, Status.Primary);
        }

        private SalesmenStatus ConvertSalesmenStatusDTOSecondaryToModel(SalesmenStatusDTO salesmenStatus, int districtID)
        {
            return new SalesmenStatus(salesmenStatus.SalesmanID, districtID, Status.Secondary);
        }
    }
}
