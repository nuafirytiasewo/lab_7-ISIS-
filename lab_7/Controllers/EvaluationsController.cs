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
    public class EvaluationsController : Controller
    {
        private ADOModelDB db = new ADOModelDB();

        // GET: Evaluations
        public ActionResult Index()
        {
            var evaluations = db.Evaluations.Include(e => e.Evaluation_criteria).Include(e => e.Real_estate_objects);
            return View(evaluations.ToList());
        }

        // GET: Evaluations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluations evaluations = db.Evaluations.Find(id);
            if (evaluations == null)
            {
                return HttpNotFound();
            }
            return View(evaluations);
        }

        // GET: Evaluations/Create
        public ActionResult Create()
        {
            ViewBag.Criteria_id = new SelectList(db.Evaluation_criteria, "Criteria_id", "Criteria_name");
            ViewBag.Object_id = new SelectList(db.Real_estate_objects, "Object_id", "Address");
            return View();
        }

        // POST: Evaluations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Evaluation_id,Object_id,Evaluation_date,Criteria_id,Evaluation")] Evaluations evaluations)
        {
            if (ModelState.IsValid)
            {
                db.Evaluations.Add(evaluations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Criteria_id = new SelectList(db.Evaluation_criteria, "Criteria_id", "Criteria_name", evaluations.Criteria_id);
            ViewBag.Object_id = new SelectList(db.Real_estate_objects, "Object_id", "Address", evaluations.Object_id);
            return View(evaluations);
        }

        // GET: Evaluations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluations evaluations = db.Evaluations.Find(id);
            if (evaluations == null)
            {
                return HttpNotFound();
            }
            ViewBag.Criteria_id = new SelectList(db.Evaluation_criteria, "Criteria_id", "Criteria_name", evaluations.Criteria_id);
            ViewBag.Object_id = new SelectList(db.Real_estate_objects, "Object_id", "Address", evaluations.Object_id);
            return View(evaluations);
        }

        // POST: Evaluations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Evaluation_id,Object_id,Evaluation_date,Criteria_id,Evaluation")] Evaluations evaluations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Criteria_id = new SelectList(db.Evaluation_criteria, "Criteria_id", "Criteria_name", evaluations.Criteria_id);
            ViewBag.Object_id = new SelectList(db.Real_estate_objects, "Object_id", "Address", evaluations.Object_id);
            return View(evaluations);
        }

        // GET: Evaluations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluations evaluations = db.Evaluations.Find(id);
            if (evaluations == null)
            {
                return HttpNotFound();
            }
            return View(evaluations);
        }

        // POST: Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluations evaluations = db.Evaluations.Find(id);
            db.Evaluations.Remove(evaluations);
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
