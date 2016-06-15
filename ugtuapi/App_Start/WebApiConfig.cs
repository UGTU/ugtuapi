using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using Microsoft.Owin.Security.OAuth;
using ugtuapi.Models;
using ugtuapi.Models.Enrolleeies;
using WebApiContrib.Formatting.Jsonp;
using System.Web.Mvc;

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
               name: "EnrollerServices",
               routeTemplate: "Services/Enrollment/{action}/{year}/{directionId}",
               defaults: new
               {
                   controller = "EnrollerServices",                   
                   year = 2016                   
               }
           );

            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "Services/{controller}/{action}/{id}"
            );


            ConfigFormatters(config);

            var builder = new ODataConventionModelBuilder();

            ConfigStudentModel(builder);
            ConfigEnrollmentModel(builder);
            config.Routes.MapODataServiceRoute("odata", null, builder.GetEdmModel());
        }

        private static void ConfigFormatters(HttpConfiguration config)
        {
            config.Formatters.Clear();
            var jsn = new JsonMediaTypeFormatter
            {
                SerializerSettings = { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Error }
            };
            config.AddJsonpFormatter(jsn);
        }

        private static void ConfigStudentModel(ODataModelBuilder builder)
        {
            builder.EntitySet<ugtuapi.Models.Student>("Students");
            builder.EntitySet<Zach>("Gradebooks");
            builder.EntitySet<StudGrup>("StudentGroups");
            builder.EntitySet<Group>("Groups");
            builder.EntitySet<Curricula>("Plans");
            builder.EntitySet<StudentInfo>("StudentInfoes");
            builder.EntitySet<Department>("Departments");
            builder.EntitySet<Employee>("Employees");
            builder.EntitySet<FacultyRel>("SpecialityRel");
            builder.EntitySet<ugtuapi.Models.EducationBranch>("Brunches");
            builder.EntitySet<Faculty>("Faculties");
            builder.EntitySet<Document>("Documents");
            builder.EntitySet<ugtuapi.Models.DocumentType>("DocumentTypes");
            builder.EntitySet<Reason>("Reasons");
            builder.EntitySet<ReasonType>("ReasonTypes");
            builder.EntitySet<Roles>("Roles");

            builder.EntitySet<Room>("Rooms");
            builder.EntitySet<RoomType>("RoomTypes");
            builder.EntitySet<Campus>("Campuses");
            builder.EntitySet<ugtuapi.Models.PersonDocument>("PersonDocuments");
            builder.EntitySet<Destination>("Destinations");
            builder.EntitySet<Base_Destination>("Base_Destinations");
            builder.EntitySet<Address>("Addresses");
            builder.EntitySet<BrunchType>("BrunchTypes");
            builder.EntitySet<ugtuapi.Models.EducationForm>("EducationForms");

            builder.EntitySet<CurriculaYear>("CurriculaYears");
            builder.EntitySet<CurriculaDisciplines>("CurriculaDisciplines");
            builder.EntitySet<Content>("Content");
            builder.EntitySet<ugtuapi.Models.Discipline>("Disciplines");
            builder.EntitySet<DisciplineCycle>("Cycles");
            builder.EntitySet<DisciplineType>("DisciplineTypes");
            builder.EntitySet<TutorialClass>("TutorialClasses");
            builder.EntitySet<TutorialTypeClass>("TutorialTypeClasses");
            builder.EntitySet<TutorialType>("TutorialType");
            builder.EntitySet<DisciplineGroup>("DisciplineGroups");
            builder.EntitySet<TypeSupply>("TypeSupplies");
            builder.EntitySet<GetMagazineDocWeb_Result>("MagazineDocWeb");

            builder.EntitySet<Area>("Areas");
            builder.EntitySet<Country>("Countries");
            builder.EntitySet<SubArea>("SubAreas");
            builder.EntitySet<Locality>("Localities");
            builder.EntitySet<LocalityType>("LocalityTypes");
            builder.EntitySet<Street>("Streets");

            builder.EntitySet<ViewProgress>("ViewProgress");

            var persons = builder.EntitySet<ugtuapi.Models.Person>("People");
            persons.EntityType.Ignore(x => x.Photo);
            SetupPrimaryKeys(builder);
        }

        private static void ConfigEnrollmentModel(ODataModelBuilder builder)
        {
            builder.EntitySet<Enrollment>("Enrollments");
            builder.EntitySet<Models.Enrolleeies.EnrollmentCategory>("EnrollmentCategory");
            builder.EntitySet<Models.Enrolleeies.Bonus>("Bonus");
            builder.EntitySet<Models.Enrolleeies.CategoryType>("CategoryType");
            builder.EntitySet<Models.Enrolleeies.EdDirection>("EdDirections");
            builder.EntitySet<Models.Enrolleeies.DirectionRequirement>("DirectionRequirement");
            builder.EntitySet<Models.Enrolleeies.Test>("Tests");
            builder.EntitySet<Models.Enrolleeies.EnrollmentDocumentType>("EnrollmentDocumentTypes");
            builder.EntitySet<Models.Enrolleeies.EdBranch>("EdBranches");
            builder.EntitySet<Models.Enrolleeies.EdForm>("EdForms");
            builder.EntitySet<Models.Enrolleeies.EnrollmentProperty>("EnrollmentProperty");
            builder.EntitySet<Models.Enrolleeies.EnrollmentState>("EnrollmentState");
            builder.EntitySet<Models.Enrolleeies.EnrollmentType>("EnrollmentType");
            builder.EntitySet<Models.Enrolleeies.Institute>("Institutes");
            builder.EntitySet<Models.Enrolleeies.InstituteDirection>("InstituteDirection");
            builder.EntitySet<Models.Enrolleeies.EnrollerPersonDocument>("EnrollerPersonDocuments");
            builder.EntitySet<Models.Enrolleeies.Enroller>("Enrollers");
            builder.EntitySet<Models.Enrolleeies.TestResult>("TestResult");
            var persons = builder.EntitySet<Models.Enrolleeies.EnrollerPerson>("EnrollerPeople");
            persons.EntityType.Ignore(x => x.Photo);

            SetupEnrollmentPrimaryKeys(builder);

        }

        private static void SetupEnrollmentPrimaryKeys(ODataModelBuilder builder)
        {
            builder.Entity<Enrollment>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.EnrollerPerson>().HasKey(x => x.nCode);
            builder.Entity<Models.Enrolleeies.EnrollmentCategory>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.Bonus>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.CategoryType>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.EdDirection>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.DirectionRequirement>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.Test>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.EnrollmentDocumentType>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.EdBranch>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.EdForm>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.EnrollmentProperty>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.EnrollmentState>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.EnrollmentType>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.Institute>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.InstituteDirection>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.EnrollerPersonDocument>().HasKey(x => x.Id);
            builder.Entity<Models.Enrolleeies.Enroller>().HasKey(x => x.nCode);
            builder.Entity<Models.Enrolleeies.TestResult>().HasKey(x => x.Id);

        }

        private static void SetupPrimaryKeys(ODataModelBuilder builder)
        {
            builder.Entity<ugtuapi.Models.Person>().HasKey(x => x.nCode);
            builder.Entity<ugtuapi.Models.Student>().HasKey(x => x.nCode);
            builder.Entity<Zach>().HasKey(x => x.Ik_zach);
            builder.Entity<StudGrup>().HasKey(x => x.Ik_studGrup);
            builder.Entity<Group>().HasKey(x => x.Id);
            builder.Entity<Curricula>().HasKey(x => x.ik_uch_plan);
            builder.Entity<Department>().HasKey(x => x.UID);
            builder.Entity<StudentInfo>().HasKey(x => x.nCode);
            builder.Entity<Employee>().HasKey(x => x.Id);
            builder.Entity<FacultyRel>().HasKey(x => x.ID);
            builder.Entity<ugtuapi.Models.EducationBranch>().HasKey(x => x.ik_spec);
            builder.Entity<Faculty>().HasKey(x => x.Id);
            builder.Entity<TypeSupply>().HasKey(x => x.ik_typesup);
            builder.Entity<ugtuapi.Models.DocumentType>().HasKey(x => x.Id);
            builder.Entity<Reason>().HasKey(x => x.Id);
            builder.Entity<ReasonType>().HasKey(x => x.Id);
            builder.Entity<Roles>().HasKey(x => x.ik_Roles);
            builder.Entity<Room>().HasKey(x => x.ik_room);
            builder.Entity<RoomType>().HasKey(x => x.ik_room_type);
            builder.Entity<Campus>().HasKey(x => x.ik_campus);
            builder.Entity<ugtuapi.Models.PersonDocument>().HasKey(x => x.Ik_Document);
            builder.Entity<Destination>().HasKey(x => x.Ik_destination);
            builder.Entity<Address>().HasKey(x => x.ik_address);
            builder.Entity<Area>().HasKey(x => x.Id);
            builder.Entity<Country>().HasKey(x => x.Id);
            builder.Entity<SubArea>().HasKey(x => x.Id);
            builder.Entity<Locality>().HasKey(x => x.Id);
            builder.Entity<LocalityType>().HasKey(x => x.Id);
            builder.Entity<Street>().HasKey(x => x.Id);
            builder.Entity<Base_Destination>().HasKey(x => x.ik_basedest);
            builder.Entity<BrunchType>().HasKey(x => x.ik_type_branch);
            builder.Entity<ugtuapi.Models.EducationForm>().HasKey(x => x.Id);
            builder.Entity<CurriculaYear>().HasKey(x => x.ik_year_uch_pl);
            builder.Entity<CurriculaDisciplines>().HasKey(x => x.ik_disc_uch_plan);
            builder.Entity<Content>().HasKey(x => x.ik_upContent);
            builder.Entity<ugtuapi.Models.Discipline>().HasKey(x => x.iK_disc);
            builder.Entity<DisciplineCycle>().HasKey(x => x.IK_ckl_disc);
            builder.Entity<DisciplineType>().HasKey(x => x.ik_type_disc);
            builder.Entity<TutorialClass>().HasKey(x => x.iK_vid_zanyat);
            builder.Entity<TutorialTypeClass>().HasKey(x => x.iK_type_vz);
            builder.Entity<TutorialType>().HasKey(x => x.ikTypeZanyat);
            builder.Entity<DisciplineGroup>().HasKey(x => x.IK_grp_disc);

        }
    }
}
