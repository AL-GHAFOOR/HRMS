using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookRep.Models
{
    public class ModelStudent
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [System.Web.Mvc.Remote("RemoteUserIdVerify", "Std", HttpMethod = "POST", ErrorMessage = "Student Id is already registered")]

        public string StudentId { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DisplayName("Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [EmailAddress(ErrorMessage = "E-mail is not valid")]
        [System.Web.Mvc.Remote("RemoteEmailVerify", "Std", HttpMethod = "POST", ErrorMessage = "Invalid Email Address or already registered")]
        public string email_address { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DisplayName("Password")]
        public string Password { get; set; }

        public Nullable<bool> Activation { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DisplayName("Program")]
        public Nullable<int> ProgramId { get; set; }
        [Required(AllowEmptyStrings = false)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "verify Conformation Password does'nt match as Password")]
        public string ConformPassword { get; set; }
    }
}