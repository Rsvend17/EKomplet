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
    public class SalesmanLogic
    {
        public DistrictDBContext Context { get; set; }

        public SalesmanLogic(DistrictDBContext context)
        {
            Context = context;
        }


        public async Task<List<SalesmanDTO>> GetSalesmenFromSalesmenInBusinessTableAsync(
            List<SalesmenStatusDTO> salesmenIBD)
        {
            var salesmen = new List<SalesmanDTO>();

            foreach (var s in salesmenIBD)
            {
                var _salesman = new SalesmanDTO(await Context.Salesmen
                    .FirstOrDefaultAsync(m => m.SalesmanID == s.SalesmanID), s);
                salesmen.Add(_salesman);
            }

            return salesmen;
        }

        public async Task<List<SalesmanDTO>> GetSalesmenNotInDistrictAsync(List<SalesmenStatusDTO> _salesmenStatuses,
            int? districtID)
        {
            var salesmen = await GetSalesmenAsync();
            salesmen.RemoveAll(x => _salesmenStatuses.Exists(y => y.SalesmanID == x.SalesmanID));

            return salesmen;
        }

        public async Task<List<SalesmanDTO>> GetSalesmenAsync()
        {
            var salesmen = new List<SalesmanDTO>();

            foreach (var s in await Context.Salesmen.ToListAsync()) salesmen.Add(new SalesmanDTO(s));

            return salesmen;
        }

        public async Task<List<SalesmanDTO>> GetSalesmenAsync(List<SalesmenStatusDTO> salesmenIDs)
        {
            var salesmen = new List<SalesmanDTO>();

            foreach (var s in salesmenIDs)
                salesmen.Add(new SalesmanDTO(await Context.Salesmen.Where(m => m.SalesmanID != s.SalesmanID)
                    .FirstOrDefaultAsync()));

            return salesmen;
        }

        public async Task<SalesmanDTO> GetSalesmanFromIDAsync(int? salesmanID)
        {
            if (salesmanID == null) throw NotFound();

            return new SalesmanDTO(await Context.Salesmen.FindAsync(salesmanID));
        }

        private Exception NotFound()
        {
            throw new NotImplementedException();
        }
    }
}