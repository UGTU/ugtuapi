using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using ugtuapi.Models;

namespace ugtuapi.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ugtuapi.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Destination>("Destinations");
    builder.EntitySet<PersonDocument>("PersonDocumentSet"); 
    builder.EntitySet<Roles>("Roles"); 
    builder.EntitySet<TypeSupply>("TypeSupply"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DestinationsController : ODataController
    {
        private readonly UGTUEntities _db = new UGTUEntities();

        // GET: odata/Destinations
        [EnableQuery]
        public IQueryable<Destination> GetDestinations()
        {
            return _db.Destination;
        }

        // GET: odata/Destinations(5)
        [EnableQuery]
        public SingleResult<Destination> GetDestination([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Destination.Where(destination => destination.Ik_destination == key));
        }

        //// PUT: odata/Destinations(5)
        //public IHttpActionResult Put([FromODataUri] int key, Delta<Destination> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Destination destination = _db.Destination.Find(key);
        //    if (destination == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(destination);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DestinationExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(destination);
        //}

        //// POST: odata/Destinations
        //public IHttpActionResult Post(Destination destination)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.Destination.Add(destination);
        //    _db.SaveChanges();

        //    return Created(destination);
        //}

        //// PATCH: odata/Destinations(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] int key, Delta<Destination> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Destination destination = _db.Destination.Find(key);
        //    if (destination == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(destination);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DestinationExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(destination);
        //}

        //// DELETE: odata/Destinations(5)
        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    Destination destination = _db.Destination.Find(key);
        //    if (destination == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Destination.Remove(destination);
        //    _db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // GET: odata/Destinations(5)/Document
        [EnableQuery]
        public IQueryable<PersonDocument> GetDocument([FromODataUri] int key)
        {
            return _db.Destination.Where(m => m.Ik_destination == key).SelectMany(m => m.Document);
        }

        // GET: odata/Destinations(5)/Roles
        [EnableQuery]
        public IQueryable<Roles> GetRoles([FromODataUri] int key)
        {
            return _db.Destination.Where(m => m.Ik_destination == key).SelectMany(m => m.Roles);
        }

        // GET: odata/Destinations(5)/TypeSupply
        [EnableQuery]
        public SingleResult<TypeSupply> GetTypeSupply([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Destination.Where(m => m.Ik_destination == key).Select(m => m.TypeSupply));
        }

        // GET: odata/Destinations(5)/Grounds
        [EnableQuery]
        public IQueryable<Destination> GetGrounds([FromODataUri] int key)
        {
            return _db.Destination.Where(m => m.Ik_destination == key).SelectMany(m => m.Grounds);
        }

        // GET: odata/Destinations(5)/Derived
        [EnableQuery]
        public IQueryable<Destination> GetDerived([FromODataUri] int key)
        {
            return _db.Destination.Where(m => m.Ik_destination == key).SelectMany(m => m.Derived);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool DestinationExists(int key)
        //{
        //    return _db.Destination.Count(e => e.Ik_destination == key) > 0;
        //}
    }
}
