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
    builder.EntitySet<Faculty>("Faculties");
    builder.EntitySet<FacultyRel>("Relation_spec_fac"); 
    builder.EntitySet<Department>("DepartmentMainData"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class FacultiesController : ODataController
    {
        private readonly UGTUEntities _db = new UGTUEntities();

        // GET: odata/Faculties
        [EnableQuery]
        public IQueryable<Faculty> GetFaculties()
        {
            return _db.Fac;
        }

        // GET: odata/Faculties(5)
        [EnableQuery]
        public SingleResult<Faculty> GetFaculty([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Fac.Where(faculty => faculty.Id == key));
        }

        //// PUT: odata/Faculties(5)
        //public IHttpActionResult Put([FromODataUri] int key, Delta<Faculty> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Faculty faculty = _db.Fac.Find(key);
        //    if (faculty == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(faculty);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FacultyExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(faculty);
        //}

        //// POST: odata/Faculties
        //public IHttpActionResult Post(Faculty faculty)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.Fac.Add(faculty);
        //    _db.SaveChanges();

        //    return Created(faculty);
        //}

        //// PATCH: odata/Faculties(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] int key, Delta<Faculty> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Faculty faculty = _db.Fac.Find(key);
        //    if (faculty == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(faculty);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FacultyExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(faculty);
        //}

        //// DELETE: odata/Faculties(5)
        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    Faculty faculty = _db.Fac.Find(key);
        //    if (faculty == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Fac.Remove(faculty);
        //    _db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // GET: odata/Faculties(5)/FacultyRel
        [EnableQuery]
        public IQueryable<FacultyRel> GetFacultyRel([FromODataUri] int key)
        {
            return _db.Fac.Where(m => m.Id == key).SelectMany(m => m.FacultyRel);
        }

        // GET: odata/Faculties(5)/Department
        [EnableQuery]
        public SingleResult<Department> GetDepartment([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Fac.Where(m => m.Id == key).Select(m => m.Department));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacultyExists(int key)
        {
            return _db.Fac.Count(e => e.Id == key) > 0;
        }
    }
}
