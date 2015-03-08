using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ugtuapi.Tests.UgtuApi;

namespace ugtuapi.Tests
{
    [TestClass]
    public class UgtuApiTests
    {
        [TestMethod]
        public void TestGetStudent()
        {
            var container = new Container(new Uri("http://localhost/ugtuapi"));
            var result =
                container.Departments.Expand("Faculty/FacultyRel/EducationBranch")
                    .Where(x => x.UID == Guid.Parse("05573F83-F047-4900-990C-B5154EFAD153")).AsEnumerable()
                    .SelectMany(x => x.Faculty).SelectMany(x => x.FacultyRel).Where(x => x.IsDisbanded == false);
            var s = 0;
            foreach (var fr in result)
            {
                Console.WriteLine("{0}: FormId:{1} DirectionId:{2} {3} {4}", ++s, fr.EducationFormId,
                    fr.EducationBranch.ik_direction, fr.EducationBranch.Cname_spec, fr.EducationBranch.Sh_spec);
            }
        }
    }
}
