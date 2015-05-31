using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData.Formatter;
using ugtuapi.Models;

namespace ugtuapi.Controllers
{
    public class WebOrdersController : ApiController
    {
        private readonly UGTUEntities _db = new UGTUEntities();

        [HttpGet]
        public HttpResponseMessage Order(int id)
        {
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content =
                    new ObjectContent(typeof (List<GetMagazineDocWeb_Result>), _db.GetMagazineDocWeb(id).ToList(),
                        new JsonMediaTypeFormatter())
            };
            return response;            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
