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
    builder.EntitySet<EdBranch>("EdBranches");
    builder.EntitySet<EdDirection>("Direction"); 
    builder.EntitySet<InstituteDirection>("Relation_spec_fac"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EdBranchesController : ODataController
    {
        private readonly UGTUEnrolleeies _db = new UGTUEnrolleeies();

        // GET: odata/EdBranches
        [EnableQuery(MaxExpansionDepth = 8)]
        public IQueryable<EdBranch> GetEdBranches()
        {
            return _db.EducationBranch;
        }

        // GET: odata/EdBranches(5)
        [EnableQuery(MaxExpansionDepth = 8)]
        public SingleResult<EdBranch> GetEdBranch([FromODataUri] int key)
        {
            return SingleResult.Create(_db.EducationBranch.Where(edBranch => edBranch.Id == key));
        }

        // PUT: odata/EdBranches(5)
        //public IHttpActionResult Put([FromODataUri] int key, Delta<EdBranch> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    EdBranch edBranch = _db.EducationBranch.Find(key);
        //    if (edBranch == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(edBranch);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EdBranchExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(edBranch);
        //}

        //// POST: odata/EdBranches
        //public IHttpActionResult Post(EdBranch edBranch)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.EducationBranch.Add(edBranch);
        //    _db.SaveChanges();

        //    return Created(edBranch);
        //}

        //// PATCH: odata/EdBranches(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] int key, Delta<EdBranch> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    EdBranch edBranch = _db.EducationBranch.Find(key);
        //    if (edBranch == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(edBranch);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EdBranchExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(edBranch);
        //}

        //// DELETE: odata/EdBranches(5)
        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    EdBranch edBranch = _db.EducationBranch.Find(key);
        //    if (edBranch == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.EducationBranch.Remove(edBranch);
        //    _db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // GET: odata/EdBranches(5)/Direction
        [EnableQuery]
        public SingleResult<EdDirection> GetDirection([FromODataUri] int key)
        {
            return SingleResult.Create(_db.EducationBranch.Where(m => m.Id == key).Select(m => m.Direction));
        }

        // GET: odata/EdBranches(5)/EducationBranch1
        [EnableQuery]
        public IQueryable<EdBranch> GetEducationBranch1([FromODataUri] int key)
        {
            return _db.EducationBranch.Where(m => m.Id == key).SelectMany(m => m.EducationBranch1);
        }

        // GET: odata/EdBranches(5)/EducationBranch2
        [EnableQuery]
        public SingleResult<EdBranch> GetEducationBranch2([FromODataUri] int key)
        {
            return SingleResult.Create(_db.EducationBranch.Where(m => m.Id == key).Select(m => m.EducationBranch2));
        }

        // GET: odata/EdBranches(5)/InstituteDirections
        [EnableQuery]
        public IQueryable<InstituteDirection> GetInstituteDirections([FromODataUri] int key)
        {
            return _db.EducationBranch.Where(m => m.Id == key).SelectMany(m => m.InstituteDirections);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool EdBranchExists(int key)
        //{
        //    return _db.EducationBranch.Count(e => e.Id == key) > 0;
        //}
    }
}
