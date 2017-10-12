using Core.DAL.Repositories;
using Core.Model.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Web.API.Controllers
{
    public class ItemsController : ApiController
    {
        [HttpGet]
        public List<Item> GetItems()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.ItemRepository.GetItems().Select(i => i.ConvertToDTO()).ToList();
            }
        }

        [HttpGet]
        public IHttpActionResult GetItem(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var item = uow.ItemRepository.GetItem(id);
                if (item == null)
                    return NotFound();

                return Ok(item.ConvertToDTO());
            }
        }

        [HttpPost]
        public IHttpActionResult AddItem(Item item)
        {
            using (var uow = new UnitOfWork())
            {
                var added = uow.ItemRepository.AddItem(item.ConverToModel());
                if (added == null)
                    return InternalServerError();

                return Ok(added.ConvertToDTO());
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateItem(Item item)
        {
            using (var uow = new UnitOfWork())
            {
                var result = uow.ItemRepository.UpdateItem(item.ConverToModel());
                if (!result)
                    return NotFound();

                return Ok(result);
            }
        }
    }
}
