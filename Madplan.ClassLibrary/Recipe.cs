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
    
    public partial class Recipe
    {
        public Recipe()
        {
            this.DietPlans = new HashSet<DietPlans>();
            this.FoodProduct = new HashSet<FoodProduct>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
    
        public virtual ICollection<DietPlans> DietPlans { get; set; }
        public virtual ICollection<FoodProduct> FoodProduct { get; set; }
    }
}
