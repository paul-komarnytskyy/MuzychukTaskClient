using Core.Model;
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
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo", Price = 1235.00, ID = 0, ImageURL = "~/Content/img/123.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo1", Price = 1235.00, ID = 1, ImageURL = "~/Content/img/123.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo2", Price = 1235.00, ID = 2, ImageURL = "~/Content/img/345.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo3", Price = 1235.00, ID = 3, ImageURL = "~/Content/img/123.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo4", Price = 1235.00, ID = 4, ImageURL = "~/Content/img/345.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo5", Price = 1235.00, ID = 5, ImageURL = "~/Content/img/345.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo6", Price = 1235.00, ID = 6, ImageURL = "~/Content/img/123.png" });
            return View(items);
        }

        public JsonResult GetItems()
        {
            int pageSize = 5;
            int? page = 1;

            var items = new List<Core.Model.DTO.Item>();
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo", Price = 1235.00, ID = 0, ImageURL = "~/Content/img/123.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo1", Price = 1235.00, ID = 1, ImageURL = "~/Content/img/123.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo2", Price = 1235.00, ID = 2, ImageURL = "~/Content/img/345.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo3", Price = 1235.00, ID = 3, ImageURL = "~/Content/img/123.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo4", Price = 1235.00, ID = 4, ImageURL = "~/Content/img/345.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo5", Price = 1235.00, ID = 5, ImageURL = "~/Content/img/345.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo6", Price = 1235.00, ID = 6, ImageURL = "~/Content/img/123.png" });

            var skip = pageSize * (page - 1);
            //var result = items.Skip(skip.GetValueOrDefault()).Take(pageSize).ToList();
            var result = items;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadHistory()
        {
            int pageSize = 5;
            int? page = 1;

            var items = new List<Core.Model.DTO.Item>();
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo", Price = 123524343.00, ID = 0, ImageURL = "~/Content/img/123.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo1", Price = 1235.00, ID = 1, ImageURL = "~/Content/img/123.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo2", Price = 1235.00, ID = 2, ImageURL = "~/Content/img/345.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo3", Price = 1235.00, ID = 3, ImageURL = "~/Content/img/123.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo4", Price = 1235434343.00, ID = 4, ImageURL = "~/Content/img/345.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo5", Price = 1235.00, ID = 5, ImageURL = "~/Content/img/345.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo6", Price = 12354343.00, ID = 6, ImageURL = "~/Content/img/123.png" });

            var skip = pageSize * (page - 1);
            //var result = items.Skip(skip.GetValueOrDefault()).Take(pageSize).ToList();
            var result = items;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult History()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}