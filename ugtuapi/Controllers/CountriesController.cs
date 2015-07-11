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
    builder.EntitySet<Country>("Countries");
    builder.EntitySet<Area>("Region"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CountriesController : ODataController
    {
        private readonly AddressEntities _db = new AddressEntities();

        // GET: odata/Countries
        [EnableQuery(MaxExpansionDepth = 6)]
        public IQueryable<Country> GetCountries()
        {
            return _db.Strana;
        }

        // GET: odata/Countries(5)
        [EnableQuery(MaxExpansionDepth = 6)]
        public SingleResult<Country> GetCountry([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Strana.Where(country => country.Id == key));
        }

        // PUT: odata/Countries(5)
        //public IHttpActionResult Put([FromODataUri] int key, Delta<Country> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Country country = _db.Strana.Find(key);
        //    if (country == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(country);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CountryExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(country);
        //}

        // POST: odata/Countries
        //public IHttpActionResult Post(Country country)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.Strana.Add(country);
        //    _db.SaveChanges();

        //    return Created(country);
        //}

        // PATCH: odata/Countries(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] int key, Delta<Country> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Country country = _db.Strana.Find(key);
        //    if (country == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(country);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CountryExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(country);
        //}

        // DELETE: odata/Countries(5)
        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    Country country = _db.Strana.Find(key);
        //    if (country == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Strana.Remove(country);
        //    _db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // GET: odata/Countries(5)/Areas
        [EnableQuery(MaxExpansionDepth = 6)]
        public IQueryable<Area> GetAreas([FromODataUri] int key)
        {
            return _db.Strana.Where(m => m.Id == key).SelectMany(m => m.Areas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool CountryExists(int key)
        //{
        //    return _db.Strana.Count(e => e.Id == key) > 0;
        //}
    }
}
