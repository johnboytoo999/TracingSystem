using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TracingSystem.Models
{
    public partial class IssueList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "maximum {1} characters allowed")]
        public string Summary { get; set; }

        [Required]
        public string Description { get; set; }

        public int Status { get; set; }
        public int CreateUserId { get; set; }
        public int LstMaintUserId { get; set; }
        public DateTime CreateDt { get; set; }
        public DateTime LstMaintDt { get; set; }
    }
}
