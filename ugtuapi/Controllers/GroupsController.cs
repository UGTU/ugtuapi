using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;
using ugtuapi.Models;

namespace ugtuapi.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ugtuapi.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Group>("Groups");
    builder.EntitySet<StudGrup>("StudGrup"); 
    builder.EntitySet<FacultyRel>("Relation_spec_fac"); 
    builder.EntitySet<Curricula>("Uch_pl"); 
    builder.EntitySet<EducationBranch>("EducationBranch"); 
    builder.EntitySet<Employee>("KafTeachers"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class GroupsController : ODataController
    {
        private readonly UGTUEntities _db = new UGTUEntities();

        // GET: odata/Groups
        [EnableQuery]
        public IQueryable<Group> GetGroups()
        {
            return _db.Grup;
        }

        // GET: odata/Groups(5)
        [EnableQuery(MaxExpansionDepth = 5)]
        public SingleResult<Group> GetGroup([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Grup.Where(group => group.Id == key));
        }

        // PUT: odata/Groups(5)
        //public IHttpActionResult Put([FromODataUri] int key, Delta<Group> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Group group = db.Grup.Find(key);
        //    if (group == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(group);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GroupExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(group);
        //}

        // POST: odata/Groups
        //public IHttpActionResult Post(Group group)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Grup.Add(group);
        //    db.SaveChanges();

        //    return Created(group);
        //}

        // PATCH: odata/Groups(5)
        [AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] int key, Delta<Group> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Group group = db.Grup.Find(key);
        //    if (group == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(group);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GroupExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(group);
        //}

        // DELETE: odata/Groups(5)
        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    Group group = db.Grup.Find(key);
        //    if (group == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Grup.Remove(group);
        //    db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // GET: odata/Groups(5)/StudentGroup
        [EnableQuery(MaxExpansionDepth = 5)]
        public IQueryable<StudGrup> GetStudentGroup([FromODataUri] int key)
        {
            return _db.Grup.Where(m => m.Id == key).SelectMany(m => m.StudentGroup);
        }

        // GET: odata/Groups(5)/FacultyRel
        [EnableQuery(MaxExpansionDepth = 5)]
        public SingleResult<FacultyRel> GetFacultyRel([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Grup.Where(m => m.Id == key).Select(m => m.FacultyRel));
        }

        // GET: odata/Groups(5)/Curricula
        [EnableQuery(MaxExpansionDepth = 5)]
        public SingleResult<Curricula> GetCurricula([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Grup.Where(m => m.Id == key).Select(m => m.Curricula));
        }

        // GET: odata/Groups(5)/EducationBranch
        [EnableQuery(MaxExpansionDepth = 5)]
        public SingleResult<EducationBranch> GetEducationBranch([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Grup.Where(m => m.Id == key).Select(m => m.EducationBranch));
        }

        // GET: odata/Groups(5)/Supervisor
        [EnableQuery(MaxExpansionDepth = 5)]
        public SingleResult<Employee> GetSupervisor([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Grup.Where(m => m.Id == key).Select(m => m.Supervisor));
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool GroupExists(int key)
        //{
        //    return db.Grup.Count(e => e.Id == key) > 0;
        //}
    }
}
