using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
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
    builder.EntitySet<Student>("Students");
    builder.EntitySet<Person>("Person"); 
    builder.EntitySet<Zach>("Zach"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class StudentsController : ODataController
    {
        private readonly UGTUEntities _db = new UGTUEntities();

        // GET: odata/Students
        [EnableQuery(MaxExpansionDepth = 5)]
        public IQueryable<Student> GetStudents()
        {
            return _db.Student;
        }


        // GET: odata/Students(5)
        [EnableQuery(MaxExpansionDepth = 5)]
        
        public SingleResult<Student> GetStudent([FromODataUri] decimal key)
        {            
            return SingleResult.Create(_db.Student.Where(student => student.nCode == key));            
        }

        // PUT: odata/Students(5)
        //public IHttpActionResult Put([FromODataUri] decimal key, Delta<Student> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Student student = _db.Student.Find(key);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(student);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(student);
        //}

        // POST: odata/Students
        //public IHttpActionResult Post(Student student)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.Student.Add(student);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (StudentExists(student.nCode))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Created(student);
        //}

        // PATCH: odata/Students(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] decimal key, Delta<Student> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Student student = _db.Student.Find(key);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(student);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(student);
        //}

        // DELETE: odata/Students(5)
        //public IHttpActionResult Delete([FromODataUri] decimal key)
        //{
        //    Student student = _db.Student.Find(key);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Student.Remove(student);
        //    _db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // GET: odata/Students(5)/Person
        [EnableQuery(MaxExpansionDepth = 5)]
        public SingleResult<Person> GetPerson([FromODataUri] decimal key)
        {
            return SingleResult.Create(_db.Student.Where(m => m.nCode == key).Select(m => m.Person));
        }

        // GET: odata/Students(5)/Zach
        [EnableQuery(MaxExpansionDepth = 5)]
        public IQueryable<Zach> GetZach([FromODataUri] decimal key)
        {
            return _db.Student.Where(m => m.nCode == key).SelectMany(m => m.Zach);
        }
        
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(decimal key)
        {
            return _db.Student.Count(e => e.nCode == key) > 0;
        }
    }
}
