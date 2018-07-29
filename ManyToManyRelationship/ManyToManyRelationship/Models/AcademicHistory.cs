using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManyToManyRelationship.Models
{
    public class AcademicHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int AcademicHistoryId { get; set; }
        public string Degree { get; set; }
        public string Institute { get; set; }
        public string Subject { get; set; }
        public string PassingYear { get; set; }
        public virtual ICollection<EmployeeAcademicHistory> EmployeeAcademicHistories { get; set; }
    }
}