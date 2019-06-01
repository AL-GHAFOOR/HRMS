using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace bookRep.Models
{
    public class bookRepContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public bookRepContext() : base("name=bookRepContext")
        {
        }

        public System.Data.Entity.DbSet<bookRep.Models.ModelFaculity> ModelFaculities { get; set; }

        public System.Data.Entity.DbSet<bookRep.tbl_Book> tbl_Book { get; set; }

        public System.Data.Entity.DbSet<bookRep.tbl_SubjectArea> tbl_SubjectArea { get; set; }
    }
}
