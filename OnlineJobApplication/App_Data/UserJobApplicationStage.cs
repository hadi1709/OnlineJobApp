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
    
    public partial class UserJobApplicationStage
    {
        public int Id { get; set; }
        public int StageId { get; set; }
        public string UserJobApplicationId { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Stage Stage { get; set; }
        public virtual UserJobApplication UserJobApplication { get; set; }
    }
}
