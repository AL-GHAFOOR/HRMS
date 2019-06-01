using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceReportingSystem.Models;

namespace bookRep.Controllers
{
    public class ResetController : Controller
    {
        eLibraryDbEntities db = new eLibraryDbEntities();
        // GET: Reset
        public ActionResult StdChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StdChangePassword(ModelUser _sUser)
        {
            ModelState["email_address"].Errors.Clear();
            if (ModelState.IsValid)
            {
                ModelUser user = Session["User"] as ModelUser;
                var student = db.tbl_Student.FirstOrDefault(a => a.email_address == user.UserId);
                if (student != null)
                {

                    student.Password = _sUser.Password;
                }

                db.SaveChanges();
                ViewBag.Message = "your password is changed ";
            }
            return View();
        }
    }
}