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
    
    public partial class EdForm
    {
        public EdForm()
        {
            this.InstituteDirections = new HashSet<InstituteDirection>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ik_FB { get; set; }
        public string Cname_form_pril { get; set; }
    
        public virtual ICollection<InstituteDirection> InstituteDirections { get; set; }
    }
}
