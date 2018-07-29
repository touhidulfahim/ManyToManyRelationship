using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManyToManyRelationship.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public virtual ICollection<ProjectAssign> ProjectAssigns { get; set; }

    }
}