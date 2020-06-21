using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EKomplet.Data;
using EKomplet.Models;
using EKomplet.ServiceLayer.DTOs;

namespace EKomplet.ServiceLayer.Logic
{
    public class SalesmanInBusinessLogic
    {
        public DistrictDBContext Context { get; set; }

        public SalesmanInBusinessLogic(DistrictDBContext context)
        {
            this.Context = context;
        }

        public async Task<List<SalesmenInBusinessDTO>> GetSalesmenInDistrictID(int? businessID)
        {
            if(businessID == null)
            {
                return NotFound();
            }

            List<SalesmenInBusinessDTO> _SalesmenInDistrict = new List<SalesmenInBusinessDTO>();

            foreach (SalesmenInBusiness s in await Context.SalesmenInBusinesses.Where(s => s.BusinessID == businessID).ToListAsync())
            {
                _SalesmenInDistrict.Add(new SalesmenInBusinessDTO(s));
            }

            return _SalesmenInDistrict;


        }

        private List<SalesmenInBusinessDTO> NotFound()
        {
            throw new NotImplementedException();
        }
    }
}
