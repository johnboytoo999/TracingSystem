using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TracingSystem.Models
{
    public partial class TrackingUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "帳號")]
        public string Account { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]   // 輸入密碼時，隱匿文字 （以 *符號 代替）
        [Display(Name = "密碼")]
        public string Password { get; set; }
        public string UserName { get; set; }
        public int UserRole { get; set; }
        public DateTime CreateDt { get; set; }
        public DateTime LstMaintDt { get; set; }
    }
}
