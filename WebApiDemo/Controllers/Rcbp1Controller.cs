using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiDemo.Interface;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [RoutePrefix("api/rcbp1s")]
    public class Rcbp1Controller : ApiController
    {
        static readonly IRcbp1Repository repository = new Rcbp1Repository();
        private WebApiDemoContext db = new WebApiDemoContext();

        // GET: api/
        [Route("")]
        public IQueryable<Rcbp1> GetRcbp1s()
        {            
            return repository.GetAll();
        }

        // GET: api/Rcbp1/5
        [Route("{id:int}")]
        [ResponseType(typeof(Rcbp1))]
        public async Task<IHttpActionResult> GetRcbp1(int id)
        {
            Rcbp1 rcbp1 = await db.DtRcbp1.FindAsync(id);
            if (rcbp1 == null)
            {
                return NotFound();
            }
            return Ok(rcbp1);
        }
        
        // GET: api/Rcbp1/5
        [Route("{id:int}/details")]
        [ResponseType(typeof(Rcbp1))]
        public async Task<IHttpActionResult> GetRcbp1Details(int id)
        {
            Rcbp1 rcbp1 = await db.DtRcbp1.FindAsync(id);
            if (rcbp1 == null)
            {
                return NotFound();
            }
            return Ok(rcbp1.BusinessPartyCode);
        }

        // PUT: api/Rcbp1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRcbp1(int id, Rcbp1 rcbp1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rcbp1.TrxNo)
            {
                return BadRequest();
            }

            db.Entry(rcbp1).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Rcbp1Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Rcbp1
        [ResponseType(typeof(Rcbp1))]
        public async Task<IHttpActionResult> PostRcbp1(Rcbp1 rcbp1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DtRcbp1.Add(rcbp1);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rcbp1.TrxNo }, rcbp1);
        }

        // DELETE: api/Rcbp1/5
        [ResponseType(typeof(Rcbp1))]
        public async Task<IHttpActionResult> DeleteRcbp1(int id)
        {
            Rcbp1 rcbp1 = await db.DtRcbp1.FindAsync(id);
            if (rcbp1 == null)
            {
                return NotFound();
            }

            db.DtRcbp1.Remove(rcbp1);
            await db.SaveChangesAsync();

            return Ok(rcbp1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Rcbp1Exists(int id)
        {
            return db.DtRcbp1.Count(e => e.TrxNo == id) > 0;
        }
    }
}