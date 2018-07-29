using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManyToManyRelationship.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public virtual ICollection<ProjectAssign> ProjectAssigns { get; set; }



    }
}