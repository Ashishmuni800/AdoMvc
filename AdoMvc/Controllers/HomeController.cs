using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdoMvc.Models;
using AdoMvc.ViewModel;

namespace AdoMvc.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDb db = new EmployeeDb();
        public ActionResult Index()
        {
            var data = db.GetEmployees();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            db.CreateList(e);
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            db.DeleteList(id);
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            var row = db.GetEmployees().Find(model => model.Id == id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            db.UpdateList(emp);
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}