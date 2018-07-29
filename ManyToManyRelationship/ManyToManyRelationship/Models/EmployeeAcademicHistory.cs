using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManyToManyRelationship.Models
{
    public class EmployeeAcademicHistory
    {
        [Key]
        [Column(Order =1)]
        public int EmployeeId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int AcademicHistoryId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual AcademicHistory AcademicHistory { get; set; }

    }
}