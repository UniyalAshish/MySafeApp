using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ItemCollection.Models;
namespace ItemCollection.Controllers
{
    public class ItemsController : ApiController
    {
        static readonly ItemRepository repository = new IItemRepostory();

        public IEnumerable<Item> GetAllProducts()
        {
            return repository.GetAll();
        }

        public Item GetProduct(int id)
        {
            Item item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Item> GetProductsByCategory(string category)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostProduct(Item item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Item>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutProduct(int id, Item product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteProduct(int id)
        {
            repository.Remove(id);
        }
    }
}