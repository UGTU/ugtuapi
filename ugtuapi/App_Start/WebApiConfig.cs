using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Converters;
using ugtuapi.Models;
using WebApiContrib.Formatting.Jsonp;

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
                name: "API Default",
                routeTemplate: "services/{controller}/{action}/{id}"                
            );          

            config.AddJsonpFormatter();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            //var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            //config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            var builder = new ODataConventionModelBuilder();
            
            builder.EntitySet<Student>("Students");
            builder.EntitySet<Zach>("Gradebooks");
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
            builder.EntitySet<Roles>("Roles");
            
            builder.EntitySet<Room>("Rooms");
            builder.EntitySet<RoomType>("RoomTypes");
            builder.EntitySet<Campus>("Campuses");
            builder.EntitySet<PersonDocument>("PersonDocuments");
            builder.EntitySet<Destination>("Destinations");
            builder.EntitySet<Address>("Addresses");
            builder.EntitySet<BrunchType>("BrunchTypes");
            builder.EntitySet<EducationForm>("EducationForms");
            
            builder.EntitySet<CurriculaYear>("CurriculaYears");
            builder.EntitySet<CurriculaDisciplines>("CurriculaDisciplines");
            builder.EntitySet<Content>("Content");
            builder.EntitySet<Discipline>("Disciplines");
            builder.EntitySet<DisciplineCycle>("Cycles");
            builder.EntitySet<DisciplineType>("DisciplineTypes");
            builder.EntitySet<TutorialClass>("TutorialClasses");
            builder.EntitySet<TutorialTypeClass>("TutorialTypeClasses");
            builder.EntitySet<TutorialType>("TutorialType");
            builder.EntitySet<DisciplineGroup>("DisciplineGroups");
            builder.EntitySet<TypeSupply>("TypeSupplies");
            builder.EntitySet<GetMagazineDocWeb_Result>("MagazineDocWeb");

            //builder.Entity<Zach>().Action("DocumentOrders")
            //    .ReturnsCollectionFromEntitySet<GetMagazineDocWeb_Result>("MagazineResult")
            //    .Parameter<int>("key");

            var persons = builder.EntitySet<Person>("People");
            persons.EntityType.Ignore(x => x.Photo);
            
            
            //var model = builder.GetEdmModel() as EdmModel;
            //var container = model.EntityContainers().First();
            //var people = container.FindEntitySet("People");
            //var photoUrl = people.ElementType.FindProperty("PhotoUrl");
            //var annotation =
            //    new EdmValueAnnotation(
            //        photoUrl, new EdmValueTerm("Org.OData.Core.V1", "Computed", EdmPrimitiveTypeKind.String),
            //    new EdmStringConstant(string.Empty));

            //model.AddVocabularyAnnotation(annotation);
                
            SetupPrimaryKeys(builder);
            config.Routes.MapODataServiceRoute("odata", null, builder.GetEdmModel());            
        }

        private static void SetupPrimaryKeys(ODataModelBuilder builder)
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
            builder.Entity<TypeSupply>().HasKey(x => x.ik_typesup);
            
            builder.Entity<DocumentType>().HasKey(x => x.Id);
            builder.Entity<Reason>().HasKey(x => x.Id);
            builder.Entity<ReasonType>().HasKey(x => x.Id);
            
            builder.Entity<Roles>().HasKey(x => x.ik_Roles);
            builder.Entity<Room>().HasKey(x => x.ik_room);
            builder.Entity<RoomType>().HasKey(x => x.ik_room_type);
            builder.Entity<Campus>().HasKey(x => x.ik_campus);
            builder.Entity<PersonDocument>().HasKey(x => x.Ik_Document);
            builder.Entity<Destination>().HasKey(x => x.Ik_destination);
            builder.Entity<Address>().HasKey(x => x.ik_address);
        }
    }
}
