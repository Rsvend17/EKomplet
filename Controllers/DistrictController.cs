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
        private readonly DistrictDBContext _context;
        private readonly DistrictLogic _districtLogic;
        private readonly SalesmenStatusLogic _salesmenStatusLogic;
        private readonly SalesmanLogic _salesmanLogic;
        private readonly BusinessLogic _businessLogic;

        public DistrictController(DistrictDBContext context)
        {
            _context = context;
            _districtLogic = new DistrictLogic(context);
            _salesmenStatusLogic = new SalesmenStatusLogic(context);
            _salesmanLogic = new SalesmanLogic(context);
            _businessLogic = new BusinessLogic(context);
        }

        // GET: District
        public async Task<IActionResult> Index()
        {
            return View(await _districtLogic.GetDistrictsAsync());
        }

        // GET: District/Details/5
        public async Task<IActionResult> Details(int? id)

        {
            var salesmenInDistrictId = await _salesmenStatusLogic.GetSalesmenStatusesAsync(id);


            var modelView = new DistrictDetailsModelView(await _districtLogic.GetDistrictAsync(id),
                await _salesmanLogic.GetSalesmenFromSalesmenInBusinessTableAsync(salesmenInDistrictId),
                await _businessLogic.GetBusinessesInDistrictAsync(id));
            return View(modelView);
        }

        // GET: District/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["SalesmanName"] = new SelectList(await _salesmanLogic.GetSalesmenAsync(), "SalesmanID", "FullName",
                "SalesmanID");
            return View();
        }

        // POST: District/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DistrictID,DistrictName")] DistrictDTO district,
            [Bind("DistrictID, SalesmanID")] SalesmenStatusDTO salesmenStatus)
        {
            if (ModelState.IsValid)
            {
                await _districtLogic.CreateDistrictAsync(district);
                await _salesmenStatusLogic.CreateSalesmanStatusPrimaryAsync(salesmenStatus, district.DistrictName);
                return RedirectToAction(nameof(Index));
            }

            return View(district);
        }

        // GET: District/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return View(await _districtLogic.GetDistrictAsync(id));
        }

        // POST: District/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DistrictID,DistrictName")] DistrictDTO district)
        {
            if (id != district.DistrictID) return NotFound();

            if (!ModelState.IsValid) return View(district);
            await _districtLogic.EditDistrictAsync(district);
            return RedirectToAction(nameof(Index));

        }

        // GET: District/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View(await _districtLogic.GetDistrictAsync(id));
        }

        // POST: District/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _districtLogic.DeleteDistrictAsync(id))
                return RedirectToAction(nameof(Index));
            else
                throw new Exception("Something went wrong when deleting the district");
        }


        public async Task<IActionResult> AddSalesmanToDistrict(int? id)
        {
            var salesmenNotInDistrict =
                await _salesmanLogic.GetSalesmenNotInDistrictAsync(
                    await _salesmenStatusLogic.GetSalesmenStatusesInDistrictAsync(id), id);
            ViewData["SalesmanName"] = new SelectList(salesmenNotInDistrict, "SalesmanID", "FullName", "SalesmanID");

            var statusState = new SelectList(Enum.GetValues(typeof(Status)).Cast<Status>().Select(v =>
                new SelectListItem
                {
                    Text = TranslateStatusEnumDanish(v.ToString()),
                    Value = ((int) v).ToString()
                }).ToList(), "Value", "Text", "Value");

            ViewData["Statuses"] = statusState;

            return View(new AddSalesmanToDistrictViewModel {district = await _districtLogic.GetDistrictAsync(id)});
        }

        public async Task<IActionResult> AddSalesmanToDistrictConfirmed(int ID,
            [Bind("SalesmanID, Status")] SalesmenStatusDTO salesmenStatus)
        {
            if (salesmenStatus.Status == Status.Primary)
                await _salesmenStatusLogic.CreateSalesmanStatusPrimaryAsync(salesmenStatus, ID);
            else if (salesmenStatus.Status == Status.Secondary)
                await _salesmenStatusLogic.CreateSalesmanStatusSecondaryAsync(salesmenStatus, ID);
            else
                throw Exception("Something went terrible wrong in AddSalesmenToDistrictConfirmed");

            return RedirectToAction("Details", new {id = ID});
        }

        public async Task<IActionResult> DeleteSalesmanDistrict(int id, int myVar)
        {
            var deleteSalesmanDetails = new DeleteSalesmanFromDistrictModelView(
                await _salesmanLogic.GetSalesmanFromIDAsync(myVar),
                await _districtLogic.GetDistrictAsync(id));

            return View(deleteSalesmanDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSalesmanDistrictConfirmed(int id, int myVar)
        {
            if (await _salesmenStatusLogic.DeleteSalesmanFromDistrictAsync(myVar, id))
                return RedirectToAction("Details", new {id = myVar});
            else
                return RedirectToAction("DeleteSalesmanFailed", new {id = myVar});
        }

#pragma warning disable 1998
        public async Task<IActionResult> DeleteSalesmanFailed(int id)
#pragma warning restore 1998
        {
            var districtDTO = new DistrictDTO(id);

            return View(districtDTO);
        }

        private static Exception Exception(string v)
        {
            throw new NotImplementedException();
        }

        private static string TranslateStatusEnumDanish(string status)
        {
            return status == "Primary" ? "Primær" : "Sekundær";
        }
    }
}