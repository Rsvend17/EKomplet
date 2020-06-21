using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EKomplet.Data;
using EKomplet.Models;
using EKomplet.ServiceLayer.Logic;
using EKomplet.ServiceLayer.DTOs;
using EKomplet.ServiceLayer.ViewModel;

namespace EKomplet.Controllers
{
    public class DistrictController : Controller
    {
        readonly private DistrictDBContext _context;
        readonly private DistrictLogic districtLogic;
        readonly private SalesmenStatusLogic salesmenStatusLogic;
        readonly private SalesmanLogic salesmanLogic;
        readonly private BusinessLogic businessLogic;

        public DistrictController(DistrictDBContext context)
        {
            _context = context;
            districtLogic = new DistrictLogic(context);
            salesmenStatusLogic = new SalesmenStatusLogic(context);
            salesmanLogic = new SalesmanLogic(context);
            businessLogic = new BusinessLogic(context);

        }

        // GET: District
        public async Task<IActionResult> Index()
        {
            return View(await districtLogic.GetDistrictsAsync());
        }

        // GET: District/Details/5
        public async Task<IActionResult> Details(int? id)

        {
            var salesmenInDistrictID = await salesmenStatusLogic.GetSalesmenStatusesAsync(id);


            DistrictDetailsModelView modelView = new DistrictDetailsModelView(await districtLogic.GetDistrictAsync(id), await salesmanLogic.GetSalesmenFromSalesmenInBusinessTableAsync(salesmenInDistrictID), await businessLogic.GetBusinessesInDistrictAsync(id));
            return View(modelView);
        }

        // GET: District/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["SalesmanName"] = new SelectList(await salesmanLogic.GetSalesmenAsync(), "SalesmanID", "FullName", "SalesmanID");
            return View();
        }

        // POST: District/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DistrictID,DistrictName")] DistrictDTO district, [Bind("DistrictID, SalesmanID")] SalesmenStatusDTO salesmenStatus)
        {
            if (ModelState.IsValid)
            {
                await districtLogic.CreateDistrictAsync(district);
                await salesmenStatusLogic.CreateSalesmanStatusPrimaryAsync(salesmenStatus, district.DistrictName);
                return RedirectToAction(nameof(Index));
            }
            return View(district);
        }

        // GET: District/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return View(await districtLogic.GetDistrictAsync(id));
        }

        // POST: District/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DistrictID,DistrictName")] DistrictDTO district)
        {
            if (id != district.DistrictID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await districtLogic.EditDistrictAsync(district);
                return RedirectToAction(nameof(Index));
            }
            return View(district);
        }

        // GET: District/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            return View(await districtLogic.GetDistrictAsync(id));
        }

        // POST: District/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await districtLogic.DeleteDistrictAsync(id))
            {
                return RedirectToAction(nameof(Index));
            }
            else { throw new Exception("Something went wrong when deleting the district"); }
        }

   
        public async Task<IActionResult> AddSalesmanToDistrict(int? id)
        {
            var _SalesmenNotInDistrict = await salesmenStatusLogic.GetSalesmenStatusesNotInDistrictAsync(id);

            ViewData["SalesmanName"] = new SelectList(await salesmanLogic.GetSalesmenAsync(_SalesmenNotInDistrict), "SalesmanID", "FullName", "SalesmanID");

            var StatusState = new SelectList(Enum.GetValues(typeof(Status)).Cast<Status>().Select(v => new SelectListItem
            { Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList(), "Value", "Text", "Value");

            ViewData["Statuses"] = StatusState;

            return View(new AddSalesmanToDistrictViewModel { district = await districtLogic.GetDistrictAsync(id) });

        }

        public async Task<IActionResult> AddSalesmanToDistrictConfirmed(int ID, [Bind("SalesmanID, Status")] SalesmenStatusDTO salesmenStatus)
        {

            if (salesmenStatus.Status == Status.Primary)
            {
                await salesmenStatusLogic.CreateSalesmanStatusPrimaryAsync(salesmenStatus, ID);
            }
            else if (salesmenStatus.Status == Status.Secondary)
            {
                await salesmenStatusLogic.CreateSalesmanStatusSecondaryAsync(salesmenStatus, ID);
            }
            else { throw Exception("Something went terrible wrong in AddSalesmenToDistrictConfirmed"); }

                return RedirectToAction("Details" , new {id = ID });
        }

        public async Task<IActionResult> DeleteSalesmanDistrict(int id, int myVar)
        {
            List<DistrictDTO> districts = new List<DistrictDTO>();

            districts.Add(await districtLogic.GetDistrictAsync(id));
            ViewData["DistrictID"] = new SelectList(districts, "DistrictID", "DistrictID", "DistrictID");
            return View(await salesmanLogic.GetSalesmanFromIDAsync(myVar));
        }

        [HttpPost, ActionName("DeleteSalesmanDistrict")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSalesmanDistrictConfirmed(int id)
        {
            if (await districtLogic.DeleteDistrictAsync(id))
            {
                return RedirectToAction(nameof(Index));
            }
            else { throw new Exception("Something went wrong when deleting the district"); }
        }

        private Exception Exception(string v)
        {
            throw new NotImplementedException();
        }
    }
}
