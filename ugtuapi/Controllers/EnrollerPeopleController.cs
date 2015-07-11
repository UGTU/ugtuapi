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
    builder.EntitySet<EnrollerPerson>("EnrollerPeople");
    builder.EntitySet<EnrollerPersonDocument>("Doc_stud"); 
    builder.EntitySet<Enroller>("Student"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EnrollerPeopleController : ODataController
    {
        private readonly UGTUEnrolleeies _db = new UGTUEnrolleeies();

        // GET: odata/EnrollerPeople
        [EnableQuery(MaxExpansionDepth = 8)]
        public IQueryable<EnrollerPerson> GetEnrollerPeople()
        {
            return _db.Person;
        }

        // GET: odata/EnrollerPeople(5)
        [EnableQuery(MaxExpansionDepth = 8)]
        public SingleResult<EnrollerPerson> GetEnrollerPerson([FromODataUri] decimal key)
        {
            return SingleResult.Create(_db.Person.Where(enrollerPerson => enrollerPerson.nCode == key));
        }

        // PUT: odata/EnrollerPeople(5)
        //public IHttpActionResult Put([FromODataUri] decimal key, Delta<EnrollerPerson> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    EnrollerPerson enrollerPerson = _db.Person.Find(key);
        //    if (enrollerPerson == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(enrollerPerson);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EnrollerPersonExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(enrollerPerson);
        //}

        //// POST: odata/EnrollerPeople
        //public IHttpActionResult Post(EnrollerPerson enrollerPerson)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.Person.Add(enrollerPerson);
        //    _db.SaveChanges();

        //    return Created(enrollerPerson);
        //}

        //// PATCH: odata/EnrollerPeople(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] decimal key, Delta<EnrollerPerson> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    EnrollerPerson enrollerPerson = _db.Person.Find(key);
        //    if (enrollerPerson == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(enrollerPerson);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EnrollerPersonExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(enrollerPerson);
        //}

        //// DELETE: odata/EnrollerPeople(5)
        //public IHttpActionResult Delete([FromODataUri] decimal key)
        //{
        //    EnrollerPerson enrollerPerson = _db.Person.Find(key);
        //    if (enrollerPerson == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Person.Remove(enrollerPerson);
        //    _db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // GET: odata/EnrollerPeople(5)/EnrollerPersonDocuments
        [EnableQuery]
        public IQueryable<EnrollerPersonDocument> GetEnrollerPersonDocuments([FromODataUri] decimal key)
        {
            return _db.Person.Where(m => m.nCode == key).SelectMany(m => m.EnrollerPersonDocuments);
        }

        // GET: odata/EnrollerPeople(5)/Enroller
        [EnableQuery]
        public SingleResult<Enroller> GetEnroller([FromODataUri] decimal key)
        {
            return SingleResult.Create(_db.Person.Where(m => m.nCode == key).Select(m => m.Enroller));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnrollerPersonExists(decimal key)
        {
            return _db.Person.Count(e => e.nCode == key) > 0;
        }
    }
}
