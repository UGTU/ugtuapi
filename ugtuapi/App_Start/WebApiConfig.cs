using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.ServiceModel.Syndication;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Formatter;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using ugtuapi.Models;

namespace ugtuapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.Add(new XmlMediaTypeFormatter());            

            var builder = new ODataConventionModelBuilder();            
            builder.EntitySet<Person>("Persons");
            builder.EntitySet<Student>("Students");
            builder.EntitySet<Zach>("Zach");
            builder.EntitySet<StudGrup>("StudentGroups");
            builder.EntitySet<Group>("Groups");
            builder.EntitySet<Curricula>("Plans");
            builder.EntitySet<StudentInfo>("StudentInfoes");
            builder.EntitySet<Department>("Departments");
            builder.EntitySet<Employee>("Employees");
            builder.EntitySet<FacultyRel>("SpecialityRel");            
            builder.EntitySet<EducationBranch>("Brunches");
            builder.EntitySet<Faculty>("Faculties");
            builder.EntitySet<Document>("Documents");
            builder.EntitySet<DocumentType>("DocumentTypes");
            builder.EntitySet<Reason>("Reasons");
            builder.EntitySet<ReasonType>("ReasonTypes");
            SetupPrimaryKeys(builder);
            config.Routes.MapODataServiceRoute("odata", null, builder.GetEdmModel());            
        }

        private static void SetupPrimaryKeys(ODataConventionModelBuilder builder)
        {
            builder.Entity<Person>().HasKey(x => x.nCode);
            builder.Entity<Student>().HasKey(x => x.nCode);
            builder.Entity<Zach>().HasKey(x => x.Ik_zach);
            builder.Entity<StudGrup>().HasKey(x => x.Ik_studGrup);
            builder.Entity<Group>().HasKey(x => x.Id);
            builder.Entity<Curricula>().HasKey(x => x.ik_uch_plan);
            builder.Entity<Department>().HasKey(x => x.UID);
            builder.Entity<StudentInfo>().HasKey(x => x.nCode);
            builder.Entity<Employee>().HasKey(x => x.Id);
            builder.Entity<FacultyRel>().HasKey(x => x.ID);
            builder.Entity<EducationBranch>().HasKey(x => x.ik_spec);
            builder.Entity<Faculty>().HasKey(x => x.Id);
            builder.Entity<Document>().HasKey(x => x.Id);
            builder.Entity<DocumentType>().HasKey(x => x.Id);
            builder.Entity<Reason>().HasKey(x => x.Id);
            builder.Entity<ReasonType>().HasKey(x => x.Id);
            
            
            
        }
    }
}
