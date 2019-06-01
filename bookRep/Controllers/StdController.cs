using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bookRep;
using bookRep.BLL;
using bookRep.Models;
using SRVTextToImage;

namespace bookRep.Controllers
{
    public class StdController : Controller
    {
        private eLibraryDbEntities db = new eLibraryDbEntities();
        [AllowAnonymous]
        [HttpPost]
        public ActionResult RemoteEmailVerify(string email_address)
        {
            if (db.tbl_Student.Count(a=>a.email_address==email_address)>0)
            {
                return Json(false);
            }
            if (email_address.Contains("eastdelta.edu.bd"))
            {
                return Json(true);
            }

            return Json(false);
        }
        public ActionResult RemoteUserIdVerify(string StudentId)
        {
            var count = db.tbl_Student.Count(a => a.StudentId == StudentId);
            if (count>0)
            {
                return Json(false);

            }
            return Json(true);
        }
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public FileResult GetCaptchaImage()
        {
            CaptchaRandomImage CI = new CaptchaRandomImage();
            this.Session["CaptchaImageText"] = CI.GetRandomString(5); 
            // here 5 means I want to get 5 char long captcha
            //CI.GenerateImage(this.Session["CaptchaImageText"].ToString(), 300, 75);
            // Or We can use another one for get custom color Captcha Image 
            CI.GenerateImage(this.Session["CaptchaImageText"].ToString(), 300, 75, Color.DarkOliveGreen, Color.White);
            MemoryStream stream = new MemoryStream();
            CI.Image.Save(stream, ImageFormat.Png);
            stream.Seek(0, SeekOrigin.Begin);
            return new FileStreamResult(stream, "image/png");

             
        }
        

        // GET: Std
        public ActionResult Index()
        {
            List<ModelStudent> list = new List<ModelStudent>();

            foreach (tbl_Student result in db.tbl_Student.ToList())
            {
                list.Add(new ModelStudent()
                {
                    Id = result.Id,
                    StudentId = result.StudentId,
                    Activation = result.Activation,
                    ConformPassword = result.ConformPassword,
                    email_address = result.email_address,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Password = result.Password,
                    ProgramId = result.ProgramId
                   
                });
            }

            return PartialView("Index", list);
        }

        // GET: Std/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Student tbl_Student = db.tbl_Student.Find(id);
            if (tbl_Student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Student);
        }

        // GET: Std/Create
        public ActionResult Create()
        {
            var ProgramList = new SelectDropDownListManager().GetProgramlist().ToList();
            ViewBag.Program = ProgramList;
            return View("Create");
        }
        public ActionResult StudentLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModelStudent model,string CaptchaText)
        {
            if (ModelState.IsValid)
            {
                if (Session["CaptchaImageText"]!=null)
                {
                    if (Session["CaptchaImageText"].ToString() == CaptchaText)
                    {
                        ViewBag.Message = "Catcha Validation Success!";
                        try
                        {
                            tbl_Student _student = new tbl_Student();
                            _student.Password = model.Password;
                            _student.StudentId = model.StudentId;
                            _student.Activation = false;
                            _student.ConformPassword = model.ConformPassword;
                            _student.FirstName = model.FirstName;
                            _student.LastName = model.LastName;
                            _student.email_address = model.email_address;
                            _student.ProgramId = model.ProgramId;
                            db.tbl_Student.Add(_student);
                            if (db.SaveChanges() > 0)
                            {
                                ViewBag.Message =
                                    "We have created your account. Please contact library to activate.";

                                    ModelState.Clear();
                            }
                            
                        }
                        catch (Exception e)
                        {
                            ViewBag.Message =e.Message;
                        }
                        
                        

                        //tbl_Student.Activation = false;

                        //db.tbl_Student.Add(tbl_Student);
                        //db.SaveChanges();
                        //tbl_Student=new tbl_Student();
                    }
                    else
                    {
                        ViewBag.Message = "Catcha Validation Failed!";
                    }

                   
                }
                var ProgramList = new SelectDropDownListManager().GetProgramlist().ToList();
                ViewBag.Program = ProgramList;
            }

            return View("Create");
        }

        public ActionResult RegStudent()
        {
            var ProgramList = new SelectDropDownListManager().GetProgramlist().ToList();
            ViewBag.Program = ProgramList;
            return PartialView("RegStudent");
        }
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegStudent(ModelStudent model, string CaptchaText)
        {
            if (ModelState.IsValid)
            {
                if (Session["CaptchaImageText"] != null)
                {
                    if (Session["CaptchaImageText"].ToString() == CaptchaText)
                    {
                        ViewBag.Message = "Catcha Validation Success!";
                        try
                        {
                            tbl_Student _student = new tbl_Student();
                            _student.Password = model.Password;
                            _student.StudentId = model.StudentId;
                            _student.Activation = false;
                            _student.ConformPassword = model.ConformPassword;
                            _student.FirstName = model.FirstName;
                            _student.LastName = model.LastName;
                            _student.email_address = model.email_address;
                            _student.ProgramId = model.ProgramId;
                            db.tbl_Student.Add(_student);
                            if (db.SaveChanges() > 0)
                            {
                                ViewBag.Message =
                                    "Your registration is successfully completed . after sometimes later you can login when activate your account ";
                                ModelState.Clear();
                            }

                        }
                        catch (Exception e)
                        {
                            ViewBag.Message = e.Message;
                        }



                        //tbl_Student.Activation = false;

                        //db.tbl_Student.Add(tbl_Student);
                        //db.SaveChanges();
                        //tbl_Student=new tbl_Student();
                    }
                    else
                    {
                        ViewBag.Message = "Catcha Validation Failed!";
                    }


                }
                var ProgramList = new SelectDropDownListManager().GetProgramlist().ToList();
                ViewBag.Program = ProgramList;
            }

            return PartialView("RegStudent");
        }
        // GET: Std/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Student tbl_Student = db.tbl_Student.Find(id);
            if (tbl_Student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Student);
        }

        // POST: Std/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,FirstName,LastName,email_address,Password,Activation")] tbl_Student tbl_Student)
        {
            if (ModelState.IsValid)
            {
               
                db.Entry(tbl_Student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Student);
        }

        // GET: Std/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Student tbl_Student = db.tbl_Student.Find(id);
            if (tbl_Student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Student);
        }

        // POST: Std/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Student tbl_Student = db.tbl_Student.Find(id);
            db.tbl_Student.Remove(tbl_Student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
