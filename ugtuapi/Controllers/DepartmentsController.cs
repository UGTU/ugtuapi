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
    builder.EntitySet<Department>("Departments");
    builder.EntitySet<Employee>("KafTeachers"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class DepartmentsController : ODataController
    {
        private readonly UGTUEntities _db = new UGTUEntities();

        // GET: odata/Departments
        [EnableQuery(MaxExpansionDepth = 5)]
        public IQueryable<Department> GetDepartments()
        {
            return _db.DepartmentMainData;
        }

        // GET: odata/Departments(5)
        [EnableQuery(MaxExpansionDepth = 5)]
        public SingleResult<Department> GetDepartment([FromODataUri] Guid key)
        {
            return SingleResult.Create(_db.DepartmentMainData.Where(department => department.UID == key));
        }

        // PUT: odata/Departments(5)
        //public IHttpActionResult Put([FromODataUri] Guid key, Delta<Department> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Department department = _db.DepartmentMainData.Find(key);
        //    if (department == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(department);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DepartmentExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(department);
        //}

        //// POST: odata/Departments
        //public IHttpActionResult Post(Department department)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.DepartmentMainData.Add(department);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (DepartmentExists(department.UID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Created(department);
        //}

        //// PATCH: odata/Departments(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] Guid key, Delta<Department> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Department department = _db.DepartmentMainData.Find(key);
        //    if (department == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(department);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DepartmentExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(department);
        //}

        //// DELETE: odata/Departments(5)
        //public IHttpActionResult Delete([FromODataUri] Guid key)
        //{
        //    Department department = _db.DepartmentMainData.Find(key);
        //    if (department == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.DepartmentMainData.Remove(department);
        //    _db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // GET: odata/Departments(5)/ManagerDepartment
        [EnableQuery(MaxExpansionDepth = 5)]
        public IQueryable<Department> GetManagerDepartment([FromODataUri] Guid key)
        {
            return _db.DepartmentMainData.Where(m => m.UID == key).SelectMany(m => m.ChildDepartment);
        }

        // GET: odata/Departments(5)/ChildDepartment
        [EnableQuery(MaxExpansionDepth = 5)]
        public SingleResult<Department> GetChildDepartments([FromODataUri] Guid key)
        {
            return SingleResult.Create(_db.DepartmentMainData.Where(m => m.UID == key).Select(m => m.ManagerDepartment));
        }

        // GET: odata/Departments(5)/Employees
        [EnableQuery(MaxExpansionDepth = 5)]
        public IQueryable<Employee> GetEmployees([FromODataUri] Guid key)
        {
            return _db.DepartmentMainData.Where(m => m.UID == key).SelectMany(m => m.Employees);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentExists(Guid key)
        {
            return _db.DepartmentMainData.Count(e => e.UID == key) > 0;
        }
    }
}
