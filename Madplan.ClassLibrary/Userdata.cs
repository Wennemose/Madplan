//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Madplan.ClassLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Userdata
    {
        public System.Guid UserId { get; set; }
        public Nullable<int> Weight { get; set; }
        public Nullable<int> Height { get; set; }
        public Nullable<int> Age { get; set; }
    
        public virtual aspnet_Users aspnet_Users { get; set; }
    }
}
