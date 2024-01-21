using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab_7.Models;

namespace lab_7.Controllers
{
    public class RealtorsController : Controller
    {
        private ADOModelDB db = new ADOModelDB();

        // GET: Realtors
        public ActionResult Index()
        {
            return View(db.Realtor.ToList());
        }

        // GET: Realtors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realtor realtor = db.Realtor.Find(id);
            if (realtor == null)
            {
                return HttpNotFound();
            }
            return View(realtor);
        }

        // GET: Realtors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Realtors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Realtor_id,Last_name,First_name,Middle_name,Contact_phone")] Realtor realtor)
        {
            if (ModelState.IsValid)
            {
                db.Realtor.Add(realtor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(realtor);
        }

        // GET: Realtors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realtor realtor = db.Realtor.Find(id);
            if (realtor == null)
            {
                return HttpNotFound();
            }
            return View(realtor);
        }

        // POST: Realtors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Realtor_id,Last_name,First_name,Middle_name,Contact_phone")] Realtor realtor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realtor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(realtor);
        }

        // GET: Realtors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realtor realtor = db.Realtor.Find(id);
            if (realtor == null)
            {
                return HttpNotFound();
            }
            return View(realtor);
        }

        // POST: Realtors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Realtor realtor = db.Realtor.Find(id);
            db.Realtor.Remove(realtor);
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
