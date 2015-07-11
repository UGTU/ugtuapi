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
using ugtuapi.Models.Enrolleeies;

namespace ugtuapi.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ugtuapi.Models.Enrolleeies;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Enroller>("Enrollers");
    builder.EntitySet<Enrollment>("ABIT_postup"); 
    builder.EntitySet<EnrollerPerson>("Person"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EnrollersController : ODataController
    {
        private readonly UGTUEnrolleeies _db = new UGTUEnrolleeies();

        // GET: odata/Enrollers
        [EnableQuery(MaxExpansionDepth = 8)]
        public IQueryable<Enroller> GetEnrollers()
        {
            return _db.Student;
        }

        // GET: odata/Enrollers(5)
        [EnableQuery(MaxExpansionDepth = 8)]
        public SingleResult<Enroller> GetEnroller([FromODataUri] decimal key)
        {
            return SingleResult.Create(_db.Student.Where(enroller => enroller.nCode == key));
        }

        // PUT: odata/Enrollers(5)
        //public IHttpActionResult Put([FromODataUri] decimal key, Delta<Enroller> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Enroller enroller = _db.Student.Find(key);
        //    if (enroller == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(enroller);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EnrollerExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(enroller);
        //}

        //// POST: odata/Enrollers
        //public IHttpActionResult Post(Enroller enroller)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.Student.Add(enroller);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (EnrollerExists(enroller.nCode))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Created(enroller);
        //}

        //// PATCH: odata/Enrollers(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] decimal key, Delta<Enroller> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Enroller enroller = _db.Student.Find(key);
        //    if (enroller == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(enroller);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EnrollerExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(enroller);
        //}

        //// DELETE: odata/Enrollers(5)
        //public IHttpActionResult Delete([FromODataUri] decimal key)
        //{
        //    Enroller enroller = _db.Student.Find(key);
        //    if (enroller == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Student.Remove(enroller);
        //    _db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // GET: odata/Enrollers(5)/Enrollments
        [EnableQuery(MaxExpansionDepth = 8)]
        public IQueryable<Enrollment> GetEnrollments([FromODataUri] decimal key)
        {
            return _db.Student.Where(m => m.nCode == key).SelectMany(m => m.Enrollments);
        }

        // GET: odata/Enrollers(5)/EnrollerPerson
        [EnableQuery]
        public SingleResult<EnrollerPerson> GetEnrollerPerson([FromODataUri] decimal key)
        {
            return SingleResult.Create(_db.Student.Where(m => m.nCode == key).Select(m => m.EnrollerPerson));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool EnrollerExists(decimal key)
        //{
        //    return _db.Student.Count(e => e.nCode == key) > 0;
        //}
    }
}
