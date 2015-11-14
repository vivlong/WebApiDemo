﻿using System;
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
    public class Rcbp1Controller : ApiController
    {
        private WebApiDemoContext db = new WebApiDemoContext();

        // GET: api/Rcbp1
        public IQueryable<Rcbp1> GetRcbp1s()
        {
            return db.Rcbp1s;
        }

        // GET: api/Rcbp1/5
        [ResponseType(typeof(Rcbp1))]
        public async Task<IHttpActionResult> GetRcbp1(int id)
        {
            Rcbp1 rcbp1 = await db.Rcbp1s.FindAsync(id);
            if (rcbp1 == null)
            {
                return NotFound();
            }

            return Ok(rcbp1);
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

            db.Rcbp1s.Add(rcbp1);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rcbp1.TrxNo }, rcbp1);
        }

        // DELETE: api/Rcbp1/5
        [ResponseType(typeof(Rcbp1))]
        public async Task<IHttpActionResult> DeleteRcbp1(int id)
        {
            Rcbp1 rcbp1 = await db.Rcbp1s.FindAsync(id);
            if (rcbp1 == null)
            {
                return NotFound();
            }

            db.Rcbp1s.Remove(rcbp1);
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
            return db.Rcbp1s.Count(e => e.TrxNo == id) > 0;
        }
    }
}