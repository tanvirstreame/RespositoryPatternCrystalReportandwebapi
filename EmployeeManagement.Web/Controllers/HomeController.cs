using EmployeeManagement.Entities;
using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Repository.interfaces;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Data;

namespace EmployeeManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employee;
        
        public HomeController()
        {
            this._employee = new EmployeeRepository(new EmployeeContex());
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(string email ,string password)
        {
            var data=_employee.CheckLogIn(email, password);
            if (data > 0)
            {
                return Redirect("/Home/ViewData");
            }
            return Redirect("/");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Employee employee)
        {
            _employee.Add(employee);
            _employee.save();
            return View();
        }
        [HttpGet]
        public new ActionResult ViewData()
        {
            ViewBag.Data = _employee.GetEmpolyee();
            return View();
        }
        public ActionResult Export()
        {
            ReportDocument re = new ReportDocument();
            re.Load(Path.Combine(Server.MapPath("~/Report/CrystalReport.rpt")));
            re.SetDataSource(_employee.GetEmpolyee());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream steame = re.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            steame.Seek(0, SeekOrigin.Begin);
            return File(steame, "application/pdf", "data.pdf");
           
        }
    }
}