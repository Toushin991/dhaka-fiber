//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dhaka_Fiber.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public string ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Nullable<int> House_ { get; set; }
        public Nullable<int> Road_ { get; set; }
        public string Apt_ { get; set; }
        public string Phone_1_ { get; set; }
        public string Phone_2_ { get; set; }
        public string Cell_1_ { get; set; }
        public string Cell_2_ { get; set; }
        public string Email { get; set; }
        public int National_ID_ { get; set; }
        public string Type_of_user { get; set; }
        public int Packages { get; set; }
        public string IP_Address { get; set; }
        public string MAC_Address { get; set; }
        public System.DateTime Activation_Date { get; set; }
    
        public virtual Plan Plan { get; set; }
    }
}
