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
    builder.EntitySet<ViewProgress>("ViewProgresses");
    builder.EntitySet<Zach>("Zach"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ViewProgressesController : ODataController
    {
        private readonly UGTUEntities _db = new UGTUEntities();

        // GET: odata/ViewProgresses
        [EnableQuery]
        public IQueryable<ViewProgress> GetViewProgresses()
        {
            return _db.UspevView;
        }

        // GET: odata/ViewProgresses(5)
        [EnableQuery]
        public SingleResult<ViewProgress> GetViewProgress([FromODataUri] string key)
        {
            return SingleResult.Create(_db.UspevView.Where(viewProgress => viewProgress.Nn_zach == key));
        }

        // PUT: odata/ViewProgresses(5)
        //public IHttpActionResult Put([FromODataUri] string key, Delta<ViewProgress> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    ViewProgress viewProgress = _db.UspevView.Find(key);
        //    if (viewProgress == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(viewProgress);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ViewProgressExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(viewProgress);
        //}

        //// POST: odata/ViewProgresses
        //public IHttpActionResult Post(ViewProgress viewProgress)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.UspevView.Add(viewProgress);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ViewProgressExists(viewProgress.Nn_zach))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Created(viewProgress);
        //}

        // PATCH: odata/ViewProgresses(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] string key, Delta<ViewProgress> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    ViewProgress viewProgress = _db.UspevView.Find(key);
        //    if (viewProgress == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(viewProgress);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ViewProgressExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(viewProgress);
        //}

        // DELETE: odata/ViewProgresses(5)
        //public IHttpActionResult Delete([FromODataUri] string key)
        //{
        //    ViewProgress viewProgress = _db.UspevView.Find(key);
        //    if (viewProgress == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.UspevView.Remove(viewProgress);
        //    _db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // GET: odata/ViewProgresses(5)/Zach
        [EnableQuery]
        public SingleResult<Zach> GetZach([FromODataUri] string key)
        {
            return SingleResult.Create(_db.UspevView.Where(m => m.Nn_zach == key).Select(m => m.Zach));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool ViewProgressExists(string key)
        //{
        //    return _db.UspevView.Count(e => e.Nn_zach == key) > 0;
        //}
    }
}
