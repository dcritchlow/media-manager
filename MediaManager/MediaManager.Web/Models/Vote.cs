//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MediaManager.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vote
    {
        public int VotesId { get; set; }
        public int MovieId { get; set; }
        public string UserName { get; set; }
    
        public virtual Movie Movie { get; set; }
    }
}
