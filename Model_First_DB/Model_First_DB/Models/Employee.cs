//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model_First_DB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
        public string Gender { get; set; }
        public int DepartmentId { get; set; }
        public string Email { get; set; }
    
        public virtual Department Department { get; set; }
    }
}