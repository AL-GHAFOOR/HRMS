using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookRep.Models
{
    public class ModelFaculity
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [EmailAddress(ErrorMessage = "E-mail is not valid")]
        [System.Web.Mvc.Remote("RemoteEmailVerify", "Std", HttpMethod = "POST", ErrorMessage = "Invalid Email Address")]
        public string Email_Address { get; set; }
        [Required(AllowEmptyStrings = false)]
        
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string DesignationId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Pasword { get; set; }
        [Required(AllowEmptyStrings = false)]
        [System.ComponentModel.DataAnnotations.Compare("Pasword", ErrorMessage = "verify Conformation Password does'nt match as Password")]

        public string ConformPassword { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Department { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string School { get; set; }
        
    }
}