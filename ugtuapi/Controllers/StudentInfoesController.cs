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
    builder.EntitySet<StudentInfo>("StudentInfoes");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class StudentInfoesController : ODataController
    {
        private readonly UGTUEntities _db = new UGTUEntities();

        // GET: odata/StudentInfoes
        [EnableQuery(MaxExpansionDepth = 5)]
        public IQueryable<StudentInfo> GetStudentInfoes()
        {
            return _db.StudInfo;
        }

        // GET: odata/StudentInfoes(5)
        [EnableQuery(MaxExpansionDepth = 5)]
        public SingleResult<StudentInfo> GetStudentInfo([FromODataUri] decimal key)
        {
            return SingleResult.Create(_db.StudInfo.Where(studentInfo => studentInfo.nCode == key));
        }

        // PUT: odata/StudentInfoes(5)
        //public IHttpActionResult Put([FromODataUri] decimal key, Delta<StudentInfo> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    StudentInfo studentInfo = _db.StudInfo.Find(key);
        //    if (studentInfo == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(studentInfo);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentInfoExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(studentInfo);
        //}

        //// POST: odata/StudentInfoes
        //public IHttpActionResult Post(StudentInfo studentInfo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.StudInfo.Add(studentInfo);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (StudentInfoExists(studentInfo.nCode))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Created(studentInfo);
        //}

        //// PATCH: odata/StudentInfoes(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] decimal key, Delta<StudentInfo> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    StudentInfo studentInfo = _db.StudInfo.Find(key);
        //    if (studentInfo == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(studentInfo);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentInfoExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(studentInfo);
        //}

        //// DELETE: odata/StudentInfoes(5)
        //public IHttpActionResult Delete([FromODataUri] decimal key)
        //{
        //    StudentInfo studentInfo = _db.StudInfo.Find(key);
        //    if (studentInfo == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.StudInfo.Remove(studentInfo);
        //    _db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentInfoExists(decimal key)
        {
            return _db.StudInfo.Count(e => e.nCode == key) > 0;
        }
    }
}
