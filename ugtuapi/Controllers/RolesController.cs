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
    builder.EntitySet<Roles>("Roles");
    builder.EntitySet<Destination>("Destination"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class RolesController : ODataController
    {
        private readonly UGTUEntities _db = new UGTUEntities();

        // GET: odata/Roles
        [EnableQuery]
        public IQueryable<Roles> GetRoles()
        {
            return _db.Roles;
        }

        // GET: odata/Roles(5)
        [EnableQuery]
        public SingleResult<Roles> GetRoles([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Roles.Where(roles => roles.ik_Roles == key));
        }

        // PUT: odata/Roles(5)
        //public IHttpActionResult Put([FromODataUri] int key, Delta<Roles> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var roles = _db.Roles.Find(key);
        //    if (roles == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(roles);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RolesExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(roles);
        //}

        // POST: odata/Roles
        //public IHttpActionResult Post(Roles roles)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.Roles.Add(roles);
        //    _db.SaveChanges();

        //    return Created(roles);
        //}

        // PATCH: odata/Roles(5)
        [AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] int key, Delta<Roles> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Roles roles = _db.Roles.Find(key);
        //    if (roles == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(roles);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RolesExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(roles);
        //}

        // DELETE: odata/Roles(5)
        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    Roles roles = _db.Roles.Find(key);
        //    if (roles == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Roles.Remove(roles);
        //    _db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // GET: odata/Roles(5)/Destination
        [EnableQuery]
        public IQueryable<Destination> GetDestination([FromODataUri] int key)
        {
            return _db.Roles.Where(m => m.ik_Roles == key).SelectMany(m => m.Destination);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool RolesExists(int key)
        //{
        //    return _db.Roles.Count(e => e.ik_Roles == key) > 0;
        //}
    }
}
