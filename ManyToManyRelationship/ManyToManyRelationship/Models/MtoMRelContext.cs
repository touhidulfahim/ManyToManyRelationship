using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManyToManyRelationship.Models
{
    public class MtoMRelContext:DbContext
    {
        public MtoMRelContext()
            : base("MtoMRelDbConnection")
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<AcademicHistory> AcademicHistories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAssign> ProjectAssigns { get; set; }


    }
}