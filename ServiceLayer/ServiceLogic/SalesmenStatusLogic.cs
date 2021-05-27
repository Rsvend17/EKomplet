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
            Context = context;
        }


        public async Task<List<SalesmenStatusDTO>> GetSalesmenStatusesAsync(int? districtID)
        {
            if (districtID == null) throw new Exception("ID not found");

            var salesmenStatuses = new List<SalesmenStatusDTO>();

            foreach (var s in await Context.SalesmenStatuses.Where(s => s.DistrictID == districtID).ToListAsync())
                salesmenStatuses.Add(new SalesmenStatusDTO(s));


            return salesmenStatuses;
        }

        public async Task<List<SalesmenStatusDTO>> GetSalesmenStatusesInDistrictAsync(int? districtID)
        {
            if (districtID == null) throw new Exception("ID not found");

            var _salesmenStatuses = new List<SalesmenStatusDTO>();

            foreach (var s in await Context.SalesmenStatuses.Where(s => s.DistrictID == districtID).ToListAsync())
                _salesmenStatuses.Add(new SalesmenStatusDTO(s));

            return _salesmenStatuses;
        }


        public async Task<bool> CreateSalesmanStatusPrimaryAsync(SalesmenStatusDTO salesmenStatus, string districtName)
        {
            var _District = await Context.Districts.Where(m => m.DistrictName == districtName).FirstOrDefaultAsync();
            try
            {
                await Context.SalesmenStatuses.AddAsync(
                    ConvertSalesmenStatusDTOPrimaryToModel(salesmenStatus, _District.DistrictID));
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
                await Context.SalesmenStatuses.AddAsync(
                    ConvertSalesmenStatusDTOPrimaryToModel(salesmenStatus, districtID));
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
                await Context.SalesmenStatuses.AddAsync(
                    ConvertSalesmenStatusDTOSecondaryToModel(salesmenStatus, districtID));
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

            var salesman =
                Context.SalesmenStatuses.FirstOrDefault(status => status.SalesmanID == salesmanID && status.DistrictID == districtID);

            if (salesman == null)
            {
                return false;
            }
            var numberOfPrimarySalesmenInDistrict = await Context.SalesmenStatuses.Where(m => m.Status == Status.Primary)
                .Where(m => m.DistrictID == districtID).ToListAsync();
            
            if (numberOfPrimarySalesmenInDistrict.Count > 1 || salesman.Status != Status.Primary)
            {
                var SalesmanStatus = await Context.SalesmenStatuses.Where(m => m.DistrictID == districtID)
                    .Where(m => m.SalesmanID == salesmanID).FirstAsync();
                Context.SalesmenStatuses.Remove(SalesmanStatus);
                await Context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        private SalesmenStatus ConvertSalesmenStatusDTOPrimaryToModel(SalesmenStatusDTO salesmenStatus, int districtID)
        {
            return new SalesmenStatus(salesmenStatus.SalesmanID, districtID, Status.Primary);
        }

        private SalesmenStatus ConvertSalesmenStatusDTOSecondaryToModel(SalesmenStatusDTO salesmenStatus,
            int districtID)
        {
            return new SalesmenStatus(salesmenStatus.SalesmanID, districtID, Status.Secondary);
        }
    }
}