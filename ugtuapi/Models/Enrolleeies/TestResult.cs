//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ugtuapi.Models.Enrolleeies
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestResult
    {
        public int Id { get; set; }
        public Nullable<int> Mark { get; set; }
        public int EnrollmentId { get; set; }
        public int TestId { get; set; }
        public int ik_sdach { get; set; }
        public Nullable<int> id_rasp_kab { get; set; }
        public string NNvedom { get; set; }
    
        public virtual Test Test { get; set; }
        public virtual Enrollment Enrollment { get; set; }
    }
}
