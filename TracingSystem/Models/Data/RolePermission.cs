using System;
using System.Collections.Generic;

#nullable disable

namespace TracingSystem.Models
{
    public partial class RolePermission
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool CreateIssue { get; set; }
        public bool ResolveIssue { get; set; }
        public bool UpdateIssue { get; set; }
        public bool DeleteIssue { get; set; }
    }
}
