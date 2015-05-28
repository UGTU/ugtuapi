using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
    builder.EntitySet<Person>("People");
    builder.EntitySet<Student>("Student"); 
    builder.EntitySet<Document>("Doc_stud"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PeopleController : ODataController
    {
        private readonly UGTUEntities _db = new UGTUEntities();

        // GET: odata/People
        [EnableQuery]
        public IQueryable<Person> GetPeople()
        {
            return _db.Person;
        }

        /*[HttpPost]
        [Route("People({key})/Picture")]
        public HttpResponseMessage Picture([FromODataUri] int key)
        {
            var person = _db.Person.FirstOrDefault(x => x.nCode == key);
            var response = new HttpResponseMessage() {StatusCode = HttpStatusCode.OK};
            if (person == null || person.Photo ==null) return response;
            using (var stream = new MemoryStream(person.Photo))
            {
                var sc = new StreamContent(stream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                response.Content = sc;
                response.Content.Headers.ContentLength = stream.Length;
                return response;
            }            
        }
        */

        // GET: odata/People(5)
        [EnableQuery]
        public SingleResult<Person> GetPerson([FromODataUri] decimal key)
        {
            return SingleResult.Create(_db.Person.Where(person => person.nCode == key));
        }
        /*
        // PUT: odata/People(5)
        public IHttpActionResult Put([FromODataUri] decimal key, Delta<Person> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = _db.Person.Find(key);
            if (person == null)
            {
                return NotFound();
            }

            patch.Put(person);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(person);
        }

        // POST: odata/People
        public IHttpActionResult Post(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Person.Add(person);
            _db.SaveChanges();

            return Created(person);
        }

        // PATCH: odata/People(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] decimal key, Delta<Person> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Person person = _db.Person.Find(key);
            if (person == null)
            {
                return NotFound();
            }

            patch.Patch(person);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(person);
        }

        // DELETE: odata/People(5)
        public IHttpActionResult Delete([FromODataUri] decimal key)
        {
            Person person = _db.Person.Find(key);
            if (person == null)
            {
                return NotFound();
            }

            _db.Person.Remove(person);
            _db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
        */

        // GET: odata/People(5)/Student
        [EnableQuery]
        public SingleResult<Student> GetStudent([FromODataUri] decimal key)
        {
            return SingleResult.Create(_db.Person.Where(m => m.nCode == key).Select(m => m.Student));
        }

        // GET: odata/People(5)/Documents
        [EnableQuery]
        public IQueryable<Document> GetDocuments([FromODataUri] decimal key)
        {
            return _db.Person.Where(m => m.nCode == key).SelectMany(m => m.Documents);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
        /*
        private bool PersonExists(decimal key)
        {
            return _db.Person.Count(e => e.nCode == key) > 0;
        }
        */
    }
}
