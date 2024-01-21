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
    public class Evaluation_criteriaController : Controller
    {
        private ADOModelDB db = new ADOModelDB();

        // GET: Evaluation_criteria
        public ActionResult Index()
        {
            return View(db.Evaluation_criteria.ToList());
        }

        // GET: Evaluation_criteria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation_criteria evaluation_criteria = db.Evaluation_criteria.Find(id);
            if (evaluation_criteria == null)
            {
                return HttpNotFound();
            }
            return View(evaluation_criteria);
        }

        // GET: Evaluation_criteria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evaluation_criteria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Criteria_id,Criteria_name")] Evaluation_criteria evaluation_criteria)
        {
            if (ModelState.IsValid)
            {
                db.Evaluation_criteria.Add(evaluation_criteria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evaluation_criteria);
        }

        // GET: Evaluation_criteria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation_criteria evaluation_criteria = db.Evaluation_criteria.Find(id);
            if (evaluation_criteria == null)
            {
                return HttpNotFound();
            }
            return View(evaluation_criteria);
        }

        // POST: Evaluation_criteria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Criteria_id,Criteria_name")] Evaluation_criteria evaluation_criteria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluation_criteria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evaluation_criteria);
        }

        // GET: Evaluation_criteria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation_criteria evaluation_criteria = db.Evaluation_criteria.Find(id);
            if (evaluation_criteria == null)
            {
                return HttpNotFound();
            }
            return View(evaluation_criteria);
        }

        // POST: Evaluation_criteria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluation_criteria evaluation_criteria = db.Evaluation_criteria.Find(id);
            db.Evaluation_criteria.Remove(evaluation_criteria);
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
