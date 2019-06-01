using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bookRep.Models
{
    public class ModelBook
    {
        [Required(AllowEmptyStrings = true)]
        public int Id { get; set; }
        [Display(Name = "Title")]
        [Required(AllowEmptyStrings = false)]

        public string Book_Title { get; set; }
        [Display(Name = "Edition")]
        [Required(AllowEmptyStrings = false)]

        public int EditionId { get; set; }

        public int SchoolId { get; set; }
        [Display(Name = "Program")]
        [Required(AllowEmptyStrings = false)]

        public int ProgramId { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Category")]
        public string SubjectArea_CategoryId { get; set; }
        
        
        [Display(Name = "Category")]
        public int[] MultiCategegory { get; set; }
        [Display(Name = "Author")]
        [Required(AllowEmptyStrings = false)]
        public string Author { get; set; }
         public bool Published { get; set; }

        public string Description { get; set; }
        public string UserId { get; set; }
        public string UserType { get; set; }
        [Display(Name = "Upload PDF")]
        public HttpPostedFileBase [] BookdocumBase { get; set; }
        public HttpPostedFileBase coverFile { get; set; }
    }
}