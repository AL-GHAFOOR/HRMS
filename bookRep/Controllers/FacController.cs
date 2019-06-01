using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using bookRep.BLL;
using bookRep.Models;
using bookRep;

namespace bookRep.Controllers
{
    public class FacController : Controller
    {
        private bookRepContext db = new bookRepContext();
        private eLibraryDbEntities _dataDbEntities = new eLibraryDbEntities();

        public List<ModelSpFaculity> GetAllFacList()
        {
            List<ModelSpFaculity> list = new List<ModelSpFaculity>();

            foreach (sp_faculity_Result result in _dataDbEntities.sp_faculity())
            {
                list.Add(new ModelSpFaculity()
                {
                    Id = result.Id,
                    ConformPassword = result.ConformPassword,
                    DesignationId = result.DesignationId,
                    DName = result.DName,
                    Email_Address = result.Email_Address,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Pasword = result.Pasword
                });
            }

            return list;
        }
        // GET: Fac
        public ActionResult Index()
        {
           
            return View(GetAllFacList());
        }

        // GET: Fac/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelFaculity modelFaculity = db.ModelFaculities.Find(id);
            if (modelFaculity == null)
            {
                return HttpNotFound();
            }
            return View(modelFaculity);
        }

        // GET: Fac/Create
        public ActionResult Create()
        {
            var DesList = new SelectDropDownListManager().GetFacDesignationList().ToList();
            var Department = new SelectDropDownListManager().GetDepartment().ToList();
            var School = new SelectDropDownListManager().GetSchool().ToList();
           
            ViewBag.Designation = DesList;
            ViewBag.Department = Department;
            ViewBag.School = School;
            if (Session["MSG"]!=null)
            {
              
                ViewBag.Message = Session["MSG"].ToString();
                Session.Clear();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModelFaculity modelFaculity)
        {
            if (ModelState.IsValid)
            {
                tbl_faculity_user faculityUser = new tbl_faculity_user();
                faculityUser.Id = modelFaculity.Id;
                faculityUser.Pasword = modelFaculity.Pasword;
                faculityUser.DesignationId = modelFaculity.DesignationId;
                faculityUser.DepartmentId = modelFaculity.Department;
                faculityUser.SchoolId = modelFaculity.School;
                faculityUser.Email_Address = modelFaculity.Email_Address;
                //var pass = SequrityManager.ConvertToByteArray(modelFaculity.Pasword, Encoding.ASCII);
                //var binaryString = SequrityManager.ToBinary(pass);
                faculityUser.Pasword = modelFaculity.Pasword;
                faculityUser.FirstName = modelFaculity.FirstName;
                faculityUser.LastName = modelFaculity.LastName;
                _dataDbEntities.tbl_faculity_user.Add(faculityUser);
                _dataDbEntities.SaveChanges();
                Session["MSG"]= "You have successfully created this user";
               ModelState.Clear();
            }
           
            return RedirectToAction("Create");
        }

        // GET: Fac/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_faculity_user modelFaculity = _dataDbEntities.tbl_faculity_user.Find(id);
            var DesList = new SelectDropDownListManager().GetFacDesignationList().ToList();
            var Department = new SelectDropDownListManager().GetDepartment().ToList();
            var School = new SelectDropDownListManager().GetSchool().ToList();
            ViewBag.Designation = DesList;
            ViewBag.Department = Department;
            ViewBag.School = School;
            if (modelFaculity == null)
            {
                return HttpNotFound();
            }
            return View(modelFaculity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_faculity_user modelFaculity)
        {
            if (ModelState.IsValid)
            {
             
                _dataDbEntities.Entry(modelFaculity).State = EntityState.Modified;
                _dataDbEntities.SaveChanges();
                ViewBag.Message = "You have successfully updated this record";
                return RedirectToAction("Index");
            }
            return View(modelFaculity);
        }

        // GET: Fac/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_faculity_user modelFaculity = _dataDbEntities.tbl_faculity_user.Find(id);
            if (modelFaculity == null)
            {
                return HttpNotFound();
            }
            return View(modelFaculity);
        }

        // POST: Fac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_faculity_user modelFaculity = _dataDbEntities.tbl_faculity_user.Find(id);
            _dataDbEntities.tbl_faculity_user.Remove(modelFaculity);
            _dataDbEntities.SaveChanges();
            return View("Index",GetAllFacList());
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
