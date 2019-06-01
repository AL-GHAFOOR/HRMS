using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bookRep;
using bookRep.Models;

namespace bookRep.Controllers
{
    public class _SubjectAreaController : Controller
    {
        private eLibraryDbEntities db = new eLibraryDbEntities();

        // GET: _SubjectArea
        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_SubjectArea.ToListAsync());
        }

        // GET: _SubjectArea/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SubjectArea tbl_SubjectArea = await db.tbl_SubjectArea.FindAsync(id);
            if (tbl_SubjectArea == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SubjectArea);
        }

        // GET: _SubjectArea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: _SubjectArea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SubectArea_Name")] tbl_SubjectArea tbl_SubjectArea)
        {
            if (ModelState.IsValid)
            {
                bool exists = System.IO.Directory.Exists(Server.MapPath("~/App_Data/"+ tbl_SubjectArea.SubectArea_Name));

                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/App_Data/"+tbl_SubjectArea.SubectArea_Name));
                }
                  
                db.tbl_SubjectArea.Add(tbl_SubjectArea);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_SubjectArea);
        }

        // GET: _SubjectArea/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SubjectArea tbl_SubjectArea = await db.tbl_SubjectArea.FindAsync(id);
            if (tbl_SubjectArea == null)
            {
                return HttpNotFound();
            }
            return PartialView(tbl_SubjectArea);
        }

        // POST: _SubjectArea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SubectArea_Name")] tbl_SubjectArea tbl_SubjectArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_SubjectArea).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_SubjectArea);
        }

        // GET: _SubjectArea/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SubjectArea tbl_SubjectArea = await db.tbl_SubjectArea.FindAsync(id);
            if (tbl_SubjectArea == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SubjectArea);
        }

        // POST: _SubjectArea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_SubjectArea tbl_SubjectArea = await db.tbl_SubjectArea.FindAsync(id);
            db.tbl_SubjectArea.Remove(tbl_SubjectArea);
            await db.SaveChangesAsync();
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
