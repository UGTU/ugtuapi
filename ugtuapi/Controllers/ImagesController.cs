using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using ugtuapi.Models;

namespace ugtuapi.Controllers
{
    [Authorize]
    public class ImagesController : ApiController
    {
        private readonly UGTUEntities _db = new UGTUEntities();
        
        [HttpGet]      
        public HttpResponseMessage Photo(int id)
        {
            var person = _db.Person.FirstOrDefault(x => x.nCode == id);
            var response = new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };
            if (person == null || person.Photo == null) return response;
            using (var stream = new MemoryStream(person.Photo))
            {
                var img = Image.FromStream(stream);
                var imageStream = new MemoryStream();
                img.Save(imageStream, ImageFormat.Jpeg);
                imageStream.Position = 0;
                var sc = new StreamContent(imageStream);
                response.Content = sc;
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");                                
                return response;
            }
        }
    }
}
