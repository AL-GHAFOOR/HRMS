using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookRep;
using bookRep.BLL;
using bookRep.Models;
using PanArabInternationalApp.EmailConfig;
using ServiceReportingSystem.Models;

namespace ServiceReportingSystem.Controllers
{
   
    public class UserAccountController : Controller
    {
        eLibraryDbEntities db = new eLibraryDbEntities();
        // GET: UserAccount
        public ActionResult Account()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ModelUser user)
        {
            string message = "";
            try
            {
                ModelState["email_address"].Errors.Clear();
                if (ModelState.IsValid)
                {
                    //var UserId = bookRep.Properties.Resources.UserId;
                    //var pass = bookRep.Properties.Resources.Password;
                    var userlist =
                        db.tbl_user.FirstOrDefault(a => a.EmailAddress == user.UserId & a.Password == user.Password);

  //*******************************Adminstration*******************************************************

                    if (userlist!=null)
                    {
                        user.UserName = userlist.UserName;
                        user.Type = userlist.UserType;
                        user.Id =userlist.Id;
                        Session["User"] = user;
                        Session["beingredirected"] = "true";
                        Session["underconstruction"] = "false";

                        return RedirectToAction("Account", "UserAccount");
                    }
 //**************************************************************************************

                    var userMannnaer = db.sp_user().FirstOrDefault(a =>
                        a.email_address == user.UserId && a.Password == user.Password && a.Activation==1);
                    if (userMannnaer != null)
                    {
                        if (userMannnaer.UserType == "fac")
                        {
                            var des = db.tbl_designation.FirstOrDefault(a => a.Id == userMannnaer.PID);
                            if (des != null)
                            {
                                user.Designation = des.Designation;
                            }
                        }
                        user.UserName = userMannnaer.FirstName + " " + userMannnaer.LastName;
                        user.Type = userMannnaer.UserType;
                        user.Id = userMannnaer.PID;
                        Session["User"] = user;
                        Session["beingredirected"] = "true";
                        Session["underconstruction"] = "false";

                        return RedirectToAction("Account", "UserAccount");
                    }

                    message = "Username or password must be wrong. Please try again.";


                }
                TempData["msg"] = message;
               
              //return  View();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                Session["Message"] = e.Message;

                return RedirectToAction("Index", "Home");
            }

        }
        public JsonResult ServiceAction()
        {
            List<ModelBookList> list = new List<ModelBookList>();
            var CategoryList = db.tbl_SubjectArea.ToList();
            foreach (sp_bookList_Result result in db.sp_bookList().Where(a=>a.Published==true))
            {
                list.Add(new ModelBookList()
                {
                    Id = result.Id,
                    SubectArea_Name = SelectDropDownListManager.MultipleCategory(result.SubjectArea_CategoryId, CategoryList),
                    Author = result.Author,
                    Book_Title = result.Book_Title,
                    Description = result.Description,
                    EditionId = result.EditionId,
                    EditionName = result.EditionName,
                    ProgramId = result.ProgramId,
                    ProgramName = result.ProgramName,
                    SchoolId = result.SchoolId,
                    SubjectArea_CategoryId=Convert.ToInt32(SelectDropDownListManager.MultipleCategory(result.SubjectArea_CategoryId)),
                    Published = Convert.ToBoolean(result.Published)

                });
            }

            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public ActionResult ResetPassowrd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ResetPassowrd(ModelUser _model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    new CustomizeMessageSentToEmail().ForgotVefificaionCode(_model);
                    ViewBag.Message = "Your password has been sent your email address";
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            ModelState.Clear();
            return View();
        }
       
        public ActionResult Login()
        {
            if (Session["User"] == null)
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.Message = TempData["msg"].ToString();
                }
                return View("Login");
            }
            
            return PartialView("Account");
        }

        public ActionResult Logout()
        {
            Session.Remove("User");

            Session["beingredirected"] = "false";
            Session["underconstruction"] = "true";
            return RedirectToAction("Index", "Home");
        }

    }
}