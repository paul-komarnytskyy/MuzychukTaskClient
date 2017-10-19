using Core.DAL.Repositories;
using Core.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.API.Controllers
{
    public class NavigationController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetNavigationItems()
        {
            using (var uow = new UnitOfWork())
            {
                return Ok(uow
                    .CategoryRepository
                    .GetCategories()
                    .Where(it => !it.ParentCategoryID.HasValue)
                    .Select(it => it.ConvertToDTO()));
            }
        }

        [HttpPost]
        public IHttpActionResult AddNavigationItem(string name, int? parentId)
        {
            using (var uow = new UnitOfWork())
            {
                uow.CategoryRepository.AddCategory(new Core.Model.ItemCategory() { Name = name, ParentCategoryID = parentId });
                uow.Save();

                return Ok(uow
                    .CategoryRepository
                    .GetCategories()
                    .Where(it => !it.ParentCategoryID.HasValue)
                    .Select(it => it.ConvertToDTO()));
            }
        }

        [HttpPost]
        public IHttpActionResult RemoveNavigationItem(int categoryId)
        {
            using (var uow = new UnitOfWork())
            {
                uow.CategoryRepository.DeleteCategory(categoryId);
                uow.Save();

                return Ok(uow
                    .CategoryRepository
                    .GetCategories()
                    .Where(it => !it.ParentCategoryID.HasValue)
                    .Select(it => it.ConvertToDTO()));
            }
        }

        [HttpPost]
        public IHttpActionResult EditCategory(int categoryId, string name, int? parentId)
        {
            using (var uow = new UnitOfWork())
            {
                var category = uow.CategoryRepository.GetCategories().FirstOrDefault(it => it.ID == categoryId);
                if (category != null)
                {
                    if (name.Length > 0)
                    {
                        category.Name = name;
                    }

                    category.ParentCategoryID = parentId;
                    uow.CategoryRepository.UpdateCategory(category);
                    uow.Save();
                }

                return Ok(uow
                    .CategoryRepository
                    .GetCategories()
                    .Where(it => !it.ParentCategoryID.HasValue)
                    .Select(it => it.ConvertToDTO()));
            }
        }
    }
}
