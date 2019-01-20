using EmployeeManagement.Entities;
using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Repository.interfaces;

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
        public ActionResult ViewData()
        {
            ViewBag.Data=_employee.GetEmpolyee();
            return View();
        }
    }
}