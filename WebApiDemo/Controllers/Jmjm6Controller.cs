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
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [RoutePrefix("api/jmjm6")]
    public class Jmjm6Controller : ApiController
    {
        private WebApiDemoContext db = new WebApiDemoContext();

        // GET: api/Jmjm6
        [Route("")]
        public IQueryable<Jmjm6> GetJmjm6()
        {
            return db.DtJmjm6;
        }

        // GET: api/Jmjm6/5
        [Route("{JobNo}")]
        [ResponseType(typeof(Jmjm6))]
        public async Task<IHttpActionResult> GetJmjm6(string JobNo)
        {
            Jmjm6[] jmjm6 = await db.DtJmjm6.Where(
                    j6 => j6.JobNo == JobNo
                ).ToArrayAsync<Jmjm6>();
            if (jmjm6 == null)
            {
                return NotFound();
            }

            return Ok(jmjm6);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Jmjm6Exists(string JobNo)
        {
            return db.DtJmjm6.Count(e => e.JobNo == JobNo) > 0;
        }
    }
}