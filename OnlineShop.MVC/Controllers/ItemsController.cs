﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineShop.MVC.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Item(int ID)
        {
            var items = new List<Core.Model.DTO.Item>();
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo", Price = 1235.00, ID = 0, ImageURL = "~/Content/img/123.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo1", Price = 1235.00, ID = 1, ImageURL = "~/Content/img/123.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo2", Price = 1235.00, ID = 2, ImageURL = "~/Content/img/345.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo3", Price = 1235.00, ID = 3, ImageURL = "~/Content/img/123.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo4", Price = 1235.00, ID = 4, ImageURL = "~/Content/img/345.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo5", Price = 1235.00, ID = 5, ImageURL = "~/Content/img/345.png" });
            items.Add(new Core.Model.DTO.Item() { Name = "Lenovo6", Price = 1235.00, ID = 6, ImageURL = "~/Content/img/123.png" });
            return View(items[ID]);
        }
    }
}