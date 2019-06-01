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

namespace bookRep.Controllers
{
    public class editionController : Controller
    {
        private eLibraryDbEntities db = new eLibraryDbEntities();

        // GET: edition
        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_edition.ToListAsync());
        }

        // GET: edition/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_edition tbl_edition = await db.tbl_edition.FindAsync(id);
            if (tbl_edition == null)
            {
                return HttpNotFound();
            }
            return View(tbl_edition);
        }

        // GET: edition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: edition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,EditionName")] tbl_edition tbl_edition)
        {
            if (ModelState.IsValid)
            {
                db.tbl_edition.Add(tbl_edition);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_edition);
        }

        // GET: edition/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_edition tbl_edition = await db.tbl_edition.FindAsync(id);
            if (tbl_edition == null)
            {
                return HttpNotFound();
            }
            return View(tbl_edition);
        }

        // POST: edition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,EditionName")] tbl_edition tbl_edition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_edition).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_edition);
        }

        // GET: edition/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_edition tbl_edition = await db.tbl_edition.FindAsync(id);
            if (tbl_edition == null)
            {
                return HttpNotFound();
            }
            return View(tbl_edition);
        }

        // POST: edition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_edition tbl_edition = await db.tbl_edition.FindAsync(id);
            db.tbl_edition.Remove(tbl_edition);
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
