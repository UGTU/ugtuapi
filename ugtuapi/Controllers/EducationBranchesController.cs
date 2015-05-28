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
    builder.EntitySet<EducationBranch>("EducationBranches");
    builder.EntitySet<Group>("Grup"); 
    builder.EntitySet<FacultyRel>("Relation_spec_fac"); 
    builder.EntitySet<Curricula>("Uch_pl"); 
    builder.EntitySet<BrunchType>("Type_branch"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EducationBranchesController : ODataController
    {
        private UGTUEntities db = new UGTUEntities();

        // GET: odata/EducationBranches
        [EnableQuery]
        public IQueryable<EducationBranch> GetEducationBranches()
        {
            return db.EducationBranch;
        }

        // GET: odata/EducationBranches(5)
        [EnableQuery]
        public SingleResult<EducationBranch> GetEducationBranch([FromODataUri] int key)
        {
            return SingleResult.Create(db.EducationBranch.Where(educationBranch => educationBranch.ik_spec == key));
        }

        // PUT: odata/EducationBranches(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<EducationBranch> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EducationBranch educationBranch = db.EducationBranch.Find(key);
            if (educationBranch == null)
            {
                return NotFound();
            }

            patch.Put(educationBranch);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationBranchExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(educationBranch);
        }

        // POST: odata/EducationBranches
        public IHttpActionResult Post(EducationBranch educationBranch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EducationBranch.Add(educationBranch);
            db.SaveChanges();

            return Created(educationBranch);
        }

        // PATCH: odata/EducationBranches(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<EducationBranch> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EducationBranch educationBranch = db.EducationBranch.Find(key);
            if (educationBranch == null)
            {
                return NotFound();
            }

            patch.Patch(educationBranch);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationBranchExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(educationBranch);
        }

        // DELETE: odata/EducationBranches(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            EducationBranch educationBranch = db.EducationBranch.Find(key);
            if (educationBranch == null)
            {
                return NotFound();
            }

            db.EducationBranch.Remove(educationBranch);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/EducationBranches(5)/Children
        [EnableQuery]
        public IQueryable<EducationBranch> GetChildren([FromODataUri] int key)
        {
            return db.EducationBranch.Where(m => m.ik_spec == key).SelectMany(m => m.Children);
        }

        // GET: odata/EducationBranches(5)/Parent
        [EnableQuery]
        public SingleResult<EducationBranch> GetParent([FromODataUri] int key)
        {
            return SingleResult.Create(db.EducationBranch.Where(m => m.ik_spec == key).Select(m => m.Parent));
        }

        // GET: odata/EducationBranches(5)/Groups
        [EnableQuery]
        public IQueryable<Group> GetGroups([FromODataUri] int key)
        {
            return db.EducationBranch.Where(m => m.ik_spec == key).SelectMany(m => m.Groups);
        }

        // GET: odata/EducationBranches(5)/Faculties
        [EnableQuery]
        public IQueryable<FacultyRel> GetFaculties([FromODataUri] int key)
        {
            return db.EducationBranch.Where(m => m.ik_spec == key).SelectMany(m => m.Faculties);
        }

        // GET: odata/EducationBranches(5)/CurriculaProfiles
        [EnableQuery]
        public IQueryable<Curricula> GetCurriculaProfiles([FromODataUri] int key)
        {
            return db.EducationBranch.Where(m => m.ik_spec == key).SelectMany(m => m.CurriculaProfiles);
        }

        // GET: odata/EducationBranches(5)/CurriculaDirections
        [EnableQuery]
        public IQueryable<Curricula> GetCurriculaDirections([FromODataUri] int key)
        {
            return db.EducationBranch.Where(m => m.ik_spec == key).SelectMany(m => m.CurriculaDirections);
        }

        // GET: odata/EducationBranches(5)/Type_branch
        [EnableQuery]
        public SingleResult<BrunchType> GetType_branch([FromODataUri] int key)
        {
            return SingleResult.Create(db.EducationBranch.Where(m => m.ik_spec == key).Select(m => m.Type_branch));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EducationBranchExists(int key)
        {
            return db.EducationBranch.Count(e => e.ik_spec == key) > 0;
        }
    }
}
