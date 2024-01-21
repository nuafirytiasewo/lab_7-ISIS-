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
    public class Real_estate_objectsController : Controller
    {
        private ADOModelDB db = new ADOModelDB();

        // GET: Real_estate_objects
        public ActionResult Index()
        {
            var real_estate_objects = db.Real_estate_objects.Include(r => r.Building_materials).Include(r => r.Districts);
            return View(real_estate_objects.ToList());
        }

        // GET: Real_estate_objects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Real_estate_objects real_estate_objects = db.Real_estate_objects.Find(id);
            if (real_estate_objects == null)
            {
                return HttpNotFound();
            }
            return View(real_estate_objects);
        }

        // GET: Real_estate_objects/Create
        public ActionResult Create()
        {
            ViewBag.Building_material = new SelectList(db.Building_materials, "Material_id", "Material_name");
            ViewBag.District = new SelectList(db.Districts, "District_id", "District_name");
            return View();
        }

        // POST: Real_estate_objects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Object_id,District,Address,Floor,Number_of_rooms,Type,Status,Cost,Object_description,Building_material,Area,Announcement_date")] Real_estate_objects real_estate_objects)
        {
            if (ModelState.IsValid)
            {
                db.Real_estate_objects.Add(real_estate_objects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Building_material = new SelectList(db.Building_materials, "Material_id", "Material_name", real_estate_objects.Building_material);
            ViewBag.District = new SelectList(db.Districts, "District_id", "District_name", real_estate_objects.District);
            return View(real_estate_objects);
        }

        // GET: Real_estate_objects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Real_estate_objects real_estate_objects = db.Real_estate_objects.Find(id);
            if (real_estate_objects == null)
            {
                return HttpNotFound();
            }
            ViewBag.Building_material = new SelectList(db.Building_materials, "Material_id", "Material_name", real_estate_objects.Building_material);
            ViewBag.District = new SelectList(db.Districts, "District_id", "District_name", real_estate_objects.District);
            return View(real_estate_objects);
        }

        // POST: Real_estate_objects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Object_id,District,Address,Floor,Number_of_rooms,Type,Status,Cost,Object_description,Building_material,Area,Announcement_date")] Real_estate_objects real_estate_objects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(real_estate_objects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Building_material = new SelectList(db.Building_materials, "Material_id", "Material_name", real_estate_objects.Building_material);
            ViewBag.District = new SelectList(db.Districts, "District_id", "District_name", real_estate_objects.District);
            return View(real_estate_objects);
        }

        // GET: Real_estate_objects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Real_estate_objects real_estate_objects = db.Real_estate_objects.Find(id);
            if (real_estate_objects == null)
            {
                return HttpNotFound();
            }
            return View(real_estate_objects);
        }

        // POST: Real_estate_objects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Real_estate_objects real_estate_objects = db.Real_estate_objects.Find(id);
            db.Real_estate_objects.Remove(real_estate_objects);
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
