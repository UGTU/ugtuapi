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
    
    public partial class EdDirection
    {
        public EdDirection()
        {
            this.EducationBranch = new HashSet<EdBranch>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string ThesisName { get; set; }
        public string ExcelPatternName { get; set; }
        public string DiplExcPatternName { get; set; }
        public Nullable<int> ik_FB { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public string Podgot { get; set; }
    
        public virtual ICollection<EdBranch> EducationBranch { get; set; }
    }
}