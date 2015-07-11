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
    builder.EntitySet<Enrollment>("Enrollments");
    builder.EntitySet<EnrollmentProperty>("ABIT_Diapazon_spec_fac"); 
    builder.EntitySet<EnrollmentState>("ABIT_sost_zach"); 
    builder.EntitySet<EnrollmentCategory>("Kat_zach"); 
    builder.EntitySet<Student>("Student"); 
    builder.EntitySet<TestResult>("ABIT_Vstup_exam"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EnrollmentsController : ODataController
    {
        private readonly UGTUEnrolleeies _db = new UGTUEnrolleeies();

        // GET: odata/Enrollments
        [EnableQuery(MaxExpansionDepth = 8)]
        public IQueryable<Enrollment> GetEnrollments()
        {
            return _db.ABIT_postup;
        }

        // GET: odata/Enrollments(5)
        [EnableQuery(MaxExpansionDepth = 8)]
        public SingleResult<Enrollment> GetEnrollment([FromODataUri] int key)
        {
            return SingleResult.Create(_db.ABIT_postup.Where(enrollment => enrollment.Id == key));
        }

        // PUT: odata/Enrollments(5)
        //public IHttpActionResult Put([FromODataUri] int key, Delta<Enrollment> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Enrollment enrollment = _db.ABIT_postup.Find(key);
        //    if (enrollment == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(enrollment);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EnrollmentExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(enrollment);
        //}

        // POST: odata/Enrollments
        //public IHttpActionResult Post(Enrollment enrollment)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.ABIT_postup.Add(enrollment);
        //    _db.SaveChanges();

        //    return Created(enrollment);
        //}

        // PATCH: odata/Enrollments(5)
        [AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] int key, Delta<Enrollment> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Enrollment enrollment = _db.ABIT_postup.Find(key);
        //    if (enrollment == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(enrollment);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EnrollmentExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(enrollment);
        //}

        // DELETE: odata/Enrollments(5)
        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    Enrollment enrollment = _db.ABIT_postup.Find(key);
        //    if (enrollment == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.ABIT_postup.Remove(enrollment);
        //    _db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // GET: odata/Enrollments(5)/EnrollmentProperty
        [EnableQuery(MaxExpansionDepth = 8)]
        public SingleResult<EnrollmentProperty> GetEnrollmentProperty([FromODataUri] int key)
        {
            return SingleResult.Create(_db.ABIT_postup.Where(m => m.Id == key).Select(m => m.EnrollmentProperty));
        }

        // GET: odata/Enrollments(5)/EnrollmentState
        [EnableQuery]
        public SingleResult<EnrollmentState> GetEnrollmentState([FromODataUri] int key)
        {
            return SingleResult.Create(_db.ABIT_postup.Where(m => m.Id == key).Select(m => m.EnrollmentState));
        }

        // GET: odata/Enrollments(5)/EnrollmentCategory
        [EnableQuery]
        public SingleResult<EnrollmentCategory> GetEnrollmentCategory([FromODataUri] int key)
        {
            return SingleResult.Create(_db.ABIT_postup.Where(m => m.Id == key).Select(m => m.EnrollmentCategory));
        }

        // GET: odata/Enrollments(5)/Enroller
        [EnableQuery]
        public SingleResult<Enroller> GetEnroller([FromODataUri] int key)
        {
            return SingleResult.Create(_db.ABIT_postup.Where(m => m.Id == key).Select(m => m.Enroller));
        }

        // GET: odata/Enrollments(5)/TestResults
        [EnableQuery]
        public IQueryable<TestResult> GetTestResults([FromODataUri] int key)
        {
            return _db.ABIT_postup.Where(m => m.Id == key).SelectMany(m => m.TestResults);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool EnrollmentExists(int key)
        //{
        //    return _db.ABIT_postup.Count(e => e.Id == key) > 0;
        //}
    }
}
