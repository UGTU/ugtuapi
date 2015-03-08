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
    builder.EntitySet<Employee>("Employees");
    builder.EntitySet<Department>("DepartmentMainData"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[Authorize]
    public class EmployeesController : ODataController
    {
        private readonly UGTUEntities _db = new UGTUEntities();

        // GET: odata/Employees
        [EnableQuery(MaxExpansionDepth = 5)]
        public IQueryable<Employee> GetEmployees()
        {
            return _db.KafTeachers;
        }

        // GET: odata/Employees(5)
        [EnableQuery(MaxExpansionDepth = 5)]
        public SingleResult<Employee> GetEmployee([FromODataUri] int key)
        {
            return SingleResult.Create(_db.KafTeachers.Where(employee => employee.Id == key));
        }

        // PUT: odata/Employees(5)
        //public IHttpActionResult Put([FromODataUri] int key, Delta<Employee> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Employee employee = _db.KafTeachers.Find(key);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(employee);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(employee);
        //}

        //// POST: odata/Employees
        //public IHttpActionResult Post(Employee employee)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _db.KafTeachers.Add(employee);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (EmployeeExists(employee.HistoryId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Created(employee);
        //}

        //// PATCH: odata/Employees(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public IHttpActionResult Patch([FromODataUri] int key, Delta<Employee> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Employee employee = _db.KafTeachers.Find(key);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(employee);

        //    try
        //    {
        //        _db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(employee);
        //}

        //// DELETE: odata/Employees(5)
        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    Employee employee = _db.KafTeachers.Find(key);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.KafTeachers.Remove(employee);
        //    _db.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // GET: odata/Employees(5)/Department
        [EnableQuery(MaxExpansionDepth = 5)]
        public SingleResult<Department> GetDepartment([FromODataUri] int key)
        {
            return SingleResult.Create(_db.KafTeachers.Where(m => m.Id == key).Select(m => m.Department));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int key)
        {
            return _db.KafTeachers.Count(e => e.Id == key) > 0;
        }
    }
}
