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
    builder.EntitySet<Zach>("Gradebooks");
    builder.EntitySet<Student>("Student"); 
    builder.EntitySet<StudGrup>("StudGrup"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class GradebooksController : ODataController
    {
        private readonly UGTUEntities _db = new UGTUEntities();

        // GET: odata/Gradebooks
        [EnableQuery]
        public IQueryable<Zach> GetGradebooks()
        {
            return _db.Zach;
        }

        [HttpPost]
        public IHttpActionResult DocumentOrders([FromODataUri] int key)
        {
            return Ok(_db.GetMagazineDocWeb(key));
        }

        // GET: odata/Gradebooks(5)
        [EnableQuery]
        public SingleResult<Zach> GetZach([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Zach.Where(zach => zach.Ik_zach == key));
        }

        // PUT: odata/Gradebooks(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Zach> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Zach zach = _db.Zach.Find(key);
            if (zach == null)
            {
                return NotFound();
            }

            patch.Put(zach);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZachExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(zach);
        }

        // POST: odata/Gradebooks
        public IHttpActionResult Post(Zach zach)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Zach.Add(zach);
            _db.SaveChanges();

            return Created(zach);
        }

        // PATCH: odata/Gradebooks(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Zach> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Zach zach = _db.Zach.Find(key);
            if (zach == null)
            {
                return NotFound();
            }

            patch.Patch(zach);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZachExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(zach);
        }

        // DELETE: odata/Gradebooks(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Zach zach = _db.Zach.Find(key);
            if (zach == null)
            {
                return NotFound();
            }

            _db.Zach.Remove(zach);
            _db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Gradebooks(5)/Student
        [EnableQuery]
        public SingleResult<Student> GetStudent([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Zach.Where(m => m.Ik_zach == key).Select(m => m.Student));
        }

        // GET: odata/Gradebooks(5)/StudentGroup
        [EnableQuery]
        public IQueryable<StudGrup> GetStudentGroup([FromODataUri] int key)
        {
            return _db.Zach.Where(m => m.Ik_zach == key).SelectMany(m => m.StudentGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZachExists(int key)
        {
            return _db.Zach.Count(e => e.Ik_zach == key) > 0;
        }
    }
}
