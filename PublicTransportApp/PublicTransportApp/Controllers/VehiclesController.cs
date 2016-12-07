using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using PublicTransportApp.DAL;
using PublicTransportApp.Models;

namespace PublicTransportApp.Controllers
{
    public class VehiclesController : ApiController
    {
        private PublicTransportContext db = new PublicTransportContext();

        // GET: api/Vehicles
        public IEnumerable<Vehicle> GetVehicles()
        {
            return db.Vehicles.ToList();
        }

        // GET: api/Vehicles/5
        //[ResponseType(typeof(Vehicle))]
        [System.Web.Http.Route("api/vehicles/GetVehiclesByLine/{line}")]
        public IEnumerable<Vehicle> GetVehiclesByLine(string line)
        {
            return db.Vehicles.Where(vehicle => vehicle.Line == line).ToList();
        }

        // PUT: api/Vehicles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicle(int id, Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicle.VehicleID)
            {
                return BadRequest();
            }

            db.Entry(vehicle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(id))
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

        // POST: api/Vehicles
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult PostVehicle(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vehicles.Add(vehicle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = vehicle.VehicleID}, vehicle);
        }

        [System.Web.Http.Route("api/vehicles/AddORUpdateExternal")]
        public void AddOrUpdateExternal(Vehicle vehicle)
        {
            try
            {
                if (db.Vehicles.Any(V => V.ExternalID == vehicle.ExternalID))
                {
                    var car = db.Vehicles.First(V => V.ExternalID == vehicle.ExternalID);

                    car.Latitude = vehicle.Latitude;
                    car.Longitude = vehicle.Longitude;
                    car.Line = vehicle.Line;

                    db.Vehicles.AddOrUpdate(car);
                    db.SaveChanges();
                }
                else
                {
                    db.Vehicles.Add(vehicle);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
               
            }

        }

        // DELETE: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult DeleteVehicle(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            db.Vehicles.Remove(vehicle);
            db.SaveChanges();

            return Ok(vehicle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleExists(int id)
        {
            return db.Vehicles.Count(e => e.VehicleID == id) > 0;
        }
    }
}