using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PublicTransportApp.DAL;
using PublicTransportApp.Models;

namespace PublicTransportApp.Controllers
{
    public class StopsController : ApiController
    {
        private PublicTransportContext db = new PublicTransportContext();

        // GET: api/Stops
        public IEnumerable<Stop> GetStops()
        {
            return db.Stops.ToList();
        }

        // GET: api/Stops/5
        [ResponseType(typeof(Stop))]
        public IHttpActionResult GetStop(int id)
        {
            Stop stop = db.Stops.Find(id);
            if (stop == null)
            {
                return NotFound();
            }

            return Ok(stop);
        }

        // PUT: api/Stops/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStop(int id, Stop stop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stop.StopID)
            {
                return BadRequest();
            }

            db.Entry(stop).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StopExists(id))
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

        // POST: api/Stops
        [ResponseType(typeof(Stop))]
        public IHttpActionResult PostStop(Stop stop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stops.Add(stop);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stop.StopID }, stop);
        }

        // DELETE: api/Stops/5
        [ResponseType(typeof(Stop))]
        public IHttpActionResult DeleteStop(int id)
        {
            Stop stop = db.Stops.Find(id);
            if (stop == null)
            {
                return NotFound();
            }

            db.Stops.Remove(stop);
            db.SaveChanges();

            return Ok(stop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StopExists(int id)
        {
            return db.Stops.Count(e => e.StopID == id) > 0;
        }
    }
}