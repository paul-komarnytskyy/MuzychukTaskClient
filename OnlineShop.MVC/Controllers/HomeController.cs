using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var items = new List<Core.Model.DTO.Item>();
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo", Price = 1235.00 });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo1", Price = 1235.00 });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo2", Price = 1235.00 });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo3", Price = 1235.00 });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo4", Price = 1235.00 });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo5", Price = 1235.00 });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo6", Price = 1235.00 });
            return View(items);
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