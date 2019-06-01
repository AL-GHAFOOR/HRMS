using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace bookRep.Models
{
    public class ModelSpFaculity
    {
        public int Id { get; set; }
        [DisplayName("Email Address")]

        public string Email_Address { get; set; }
        [DisplayName("First Name")]

        public string FirstName { get; set; }
        [DisplayName("Last Name")]

        public string LastName { get; set; }
        public string DesignationId { get; set; }
        public string Pasword { get; set; }
        public string ConformPassword { get; set; }
        [DisplayName("Designation Name")]
        public string DName { get; set; }
    }
}