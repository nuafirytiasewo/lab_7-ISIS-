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
    public class Building_materialsController : Controller
    {
        private ADOModelDB db = new ADOModelDB();

        // GET: Building_materials
        public ActionResult Index()
        {
            return View(db.Building_materials.ToList());
        }

        // GET: Building_materials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building_materials building_materials = db.Building_materials.Find(id);
            if (building_materials == null)
            {
                return HttpNotFound();
            }
            return View(building_materials);
        }

        // GET: Building_materials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Building_materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Material_id,Material_name")] Building_materials building_materials)
        {
            if (ModelState.IsValid)
            {
                db.Building_materials.Add(building_materials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(building_materials);
        }

        // GET: Building_materials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building_materials building_materials = db.Building_materials.Find(id);
            if (building_materials == null)
            {
                return HttpNotFound();
            }
            return View(building_materials);
        }

        // POST: Building_materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Material_id,Material_name")] Building_materials building_materials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(building_materials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(building_materials);
        }

        // GET: Building_materials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building_materials building_materials = db.Building_materials.Find(id);
            if (building_materials == null)
            {
                return HttpNotFound();
            }
            return View(building_materials);
        }

        // POST: Building_materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Building_materials building_materials = db.Building_materials.Find(id);
            db.Building_materials.Remove(building_materials);
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
