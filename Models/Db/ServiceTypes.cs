using System;
using System.Collections.Generic;

namespace Community_Hub_v2_API.Models.Db
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            Project = new HashSet<Project>();
        }

        public int ServiceTypeId { get; set; }
        public string ServiceTypeValue { get; set; }

        public ICollection<Project> Project { get; set; }
    }
}
