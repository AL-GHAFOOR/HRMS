using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace bookRep.Models
{
    public class ModelBookList
    {
        public int Id { get; set; }
        [DisplayName("Book Title")]

        public string Book_Title { get; set; }
        public Nullable<int> EditionId { get; set; }
        public Nullable<int> SchoolId { get; set; }
        public Nullable<int> ProgramId { get; set; }
        public Nullable<int> SubjectArea_CategoryId { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string UserType { get; set; }
        [DisplayName("School Name")]

        public string SchoolName { get; set; }
        [DisplayName("Program Name")]

        public string ProgramName { get; set; }
        [DisplayName("Edition Name")]
        public string EditionName { get; set; }
        public string UserName { get; set; }
        [DisplayName("Book Category")]
        public string SubectArea_Name { get; set; }
        public bool Published { get; set; }
    }
}