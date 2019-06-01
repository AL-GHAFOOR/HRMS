using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceReportingSystem.Models
{
    public class ModelUser
    {
      
        public string UserId { get; set; }
    
        [DisplayName("Service Manger")]
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DisplayName("Email Address")]
        public string email_address { get; set; }
        public string Type { get; set; }
       
        public string Password { get; set; }
        public string RoleId { get; set; }
        public string Designation { get; set; }
        public int? Id { get; set; }
    }
}