//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineJobApplication.App_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Job
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Job()
        {
            this.UserJobApplications = new HashSet<UserJobApplication>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime DateOpened { get; set; }
        public System.DateTime DateClosed { get; set; }
        public int CareerAreasId { get; set; }
        public string Qualification { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual CareerArea CareerArea { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserJobApplication> UserJobApplications { get; set; }
    }
}