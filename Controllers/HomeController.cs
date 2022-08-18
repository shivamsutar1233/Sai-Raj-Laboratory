using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using X.PagedList;
using X.PagedList.Mvc.Core;
using Sai_Raj_Laboratory.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sai_Raj_Laboratory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext databaseContext;

        public HomeController(ILogger<HomeController> logger,DatabaseContext _context)
        {
            _logger = logger;
            databaseContext = _context;
        }
        /// <summary>
        /// Invokes Home Page of Application
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Invokes Privacy Page of Application
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// Invokes Create Report Page of Application
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateReport()
        {
            var GenderList = new List<string>() { "Male", "Female" };
            var WBCStatuses = new List<string>() { "Normal", "Leucocytosis", "Leucocytopenia" };
            var RBSStatuses = new List<string>(){ "Normocytic-Normochromic", "Hypochromic", "Microcytic-Hypochromic" };
            var Platelets = new List<string>() {
                "Adequate",
                "Inadequate",
                "Thrambocytosis",
                "Cytopenia"
            };
            ViewBag.GenderList = GenderList;
            ViewBag.WBCStatuses = WBCStatuses;
            ViewBag.RBCStatuses = RBSStatuses;
            ViewBag.Plateletes = Platelets;

            return View();
        }
        /// <summary>
        /// This method actually stores the data in database and redirects to the list page
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        public IActionResult GenerateReport(Report report)
        {
            databaseContext.Reports.Add(report);
            databaseContext.SaveChanges();
            return RedirectToAction("ViewAllReports");
        }
        /// <summary>
        /// Displays the report by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            var Report = databaseContext.Reports.Find(id);
            if(Report == null)
            {
                return NoContent();
            }
            return View(Report);
        }
        /// <summary>
        /// Prints the report by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("PrintReport/{id}")]
        public IActionResult PrintReport(int id)
        {
            var report = databaseContext.Reports.Find(id);
            return View(report);
        }
        /// <summary>
        /// Displays all reports in the database 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public IActionResult ViewAllReports(int? page)
        {
            var AllReports = databaseContext.Reports.ToList().OrderByDescending(s=>s.PatientId).ToList().ToPagedList(page ?? 1,10);
            return View(AllReports);
        }
        /// <summary>
        /// Edit the report by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var Report = databaseContext.Reports.Find(id);
            if (Report == null)
                return NotFound();
            return View(Report);
        }
        public IActionResult EditReport(Report report)
        {
            var IsUpdated = databaseContext.Reports.Update(report);
            databaseContext.SaveChanges();
            if (IsUpdated!=null)
            {
                return RedirectToAction("ViewAllReports");
            }
            return RedirectToAction("Edit/"+report.PatientId);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
