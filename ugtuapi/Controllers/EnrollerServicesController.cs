using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using ugtuapi.Models;
using ugtuapi.Models.Enrolleeies;

namespace ugtuapi.Controllers
{
    public class EnrollerServicesController : ApiController
    {
        private readonly UGTUEnrolleeies _db = new UGTUEnrolleeies();
        
        [HttpGet]
        public JsonResult<EnrollmentInfo> EnrollerList(int year, int directionId, int instituteId, int educationFormId)
        {
            return new JsonResult<EnrollmentInfo>(FetchEnrollmentInfo(year, directionId, instituteId, educationFormId),
                new JsonSerializerSettings(), Encoding.UTF8, this);
        }

        private EnrollmentInfo FetchEnrollmentInfo(int year, int directionId, int instituteId, int educationFormId)
        {
            var instituteDirection =
                _db.Relation_spec_fac.SingleOrDefault(
                    x =>
                        x.EducationBrunchId == directionId && x.EducationFormId == educationFormId &&
                        x.InstituteId == instituteId);
            if (instituteDirection == null) return null;

            var tests =
                _db.ABIT_Diapazon_spec_fac.Where(x => x.InstituteDirectionId == instituteDirection.Id)
                    .SelectMany(x => x.DirectionRequirements)
                    .Select(x => x.Test).ToList();

            var applicants = _db.ABIT_postup.Where(
                x =>
                    x.EnrollmentProperty.Year == year && 
                    x.EnrollmentProperty.InstituteDirectionId == instituteDirection.Id).ToList();

            return new EnrollmentInfo()
            {
                Direction = _db.EducationBranch.Single(x => x.Id == directionId).Name,
                DirectionCode = _db.EducationBranch.Single(x => x.Id == directionId).Sh_spec,
                EducationForm = instituteDirection.EducationForm.Name,
                InstituteName = _db.Fac.Single(x => x.Id == instituteId).Name,
                Year = year,
                Timestamp = DateTime.Now,
                Enrollers = applicants
                    .Select(x =>
                                new EnrollerInfo()
                                {
                                    FirstName = x.Enroller.EnrollerPerson.Cfirstname.Trim(),
                                    FamilyName = x.Enroller.EnrollerPerson.Clastname.Trim(),
                                    MiddleName = x.Enroller.EnrollerPerson.Cotch.Trim(),
                                    Category = x.EnrollmentCategory.Name.Trim(),
                                    CurrentStatus = x.EnrollmentState.Name.Trim(),
                                    HasOriginalDocuments = x.Realy_postup,
                                    ScoreSum = x.TestResults.Sum(m => m.Mark ?? 0),
                                    IsAlive = x.EnrollmentState.EnrollmentType.IsCurrent,
                                    ExtraScore =
                                        x.Enroller.EnrollerPerson.EnrollerPersonDocuments.Sum(
                                            z => z.Bonuses!=null && tests.Contains(z?.Bonuses.Tests) ? z.Bonuses.ExtraMark : 0)
                                }).ToArray()
            };
        }
    }
}
