using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookRep.Models;

namespace bookRep.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(ModelStudent _model)
        {
            return View();
        }
    }
}