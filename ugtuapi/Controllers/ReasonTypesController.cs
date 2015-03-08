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
    builder.EntitySet<ReasonType>("ReasonTypes");
    builder.EntitySet<Reason>("Pricina"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ReasonTypesController : ODataController
    {
        private readonly UGTUEntities _db = new UGTUEntities();

        // GET: odata/ReasonTypes
        [EnableQuery]
        public IQueryable<ReasonType> GetReasonTypes()
        {
            return _db.TypePricina;
        }

        // GET: odata/ReasonTypes(5)
        [EnableQuery]
        public SingleResult<ReasonType> GetReasonType([FromODataUri] int key)
        {
            return SingleResult.Create(_db.TypePricina.Where(reasonType => reasonType.Id == key));
        }

        //// PUT: odata/ReasonTypes(5)
        //public IHttpActionResult Put([FromODataUri] int key, Delta<ReasonType> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    ReasonType reasonType = _db.TypePricina.Find(key);
        //    if (reasonType == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(reasonType);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ReasonTypeExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(reasonType);
        //}

        //// POST: odata/ReasonTypes
        //public IHttpActionResult Post(ReasonType reasonType)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.TypePricina.Add(reasonType);
        //    _db.SaveChanges();

        //    return Created(reasonType);
        //}

        //// PATCH: odata/ReasonTypes(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] int key, Delta<ReasonType> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    ReasonType reasonType = _db.TypePricina.Find(key);
        //    if (reasonType == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(reasonType);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ReasonTypeExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(reasonType);
        //}

        //// DELETE: odata/ReasonTypes(5)
        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    ReasonType reasonType = _db.TypePricina.Find(key);
        //    if (reasonType == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.TypePricina.Remove(reasonType);
        //    _db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // GET: odata/ReasonTypes(5)/Reasons
        [EnableQuery]
        public IQueryable<Reason> GetReasons([FromODataUri] int key)
        {
            return _db.TypePricina.Where(m => m.Id == key).SelectMany(m => m.Reasons);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool ReasonTypeExists(int key)
        //{
        //    return _db.TypePricina.Count(e => e.Id == key) > 0;
        //}
    }
}
