using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDemo.Interface;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class Jmjm6Controller : ApiController
    {
        static readonly IJmjm6Repository repository = new Jmjm6Repository();

        public IEnumerable<Jmjm6> GetAllJmjm6()
        {
            return repository.GetAll();
        }

        public Jmjm6 GetJmjm6(int id)
        {
            Jmjm6 item = repository.Get(id); if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Jmjm6> GetJmjm6ByCategory(string category)
        {
            return repository.GetAll().Where(
                  p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        public Jmjm6 PostJmjm6(Jmjm6 item)
        {
            item = repository.Add(item); return item;
        }

        //public HttpResponseMessage PostProduct(Product item)
        //{
        //    item = repository.Add(item); var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item); string uri = Url.Link("DefaultApi", new { id = item.Id });
        //    response.Headers.Location = new Uri(uri); return response;
        //}
        //public void PutProduct(int id, Product product)
        //{
        //    product.Id = id; if (!repository.Update(product))
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //}
        //public void DeleteProduct(int id)
        //{
        //    Product item = repository.Get(id); if (item == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    repository.Remove(id);
        //}


        //public string Get(int id)
        //{
        //    return id.ToString();
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
