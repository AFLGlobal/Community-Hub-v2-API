using System;
using System.Collections.Generic;

namespace Community_Hub_v2_API.Models.Db
{
    public partial class Location
    {
        public Location()
        {
            Employee = new HashSet<Employee>();
            Project = new HashSet<Project>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationCountry { get; set; }

        public ICollection<Employee> Employee { get; set; }
        public ICollection<Project> Project { get; set; }
    }
}
