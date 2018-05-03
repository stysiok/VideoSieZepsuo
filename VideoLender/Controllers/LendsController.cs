﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoLender.Models;

namespace VideoLender.Controllers
{
    public class LendsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lends
        public ActionResult Index()
        {
            return View(db.Lends.ToList());
        }

        // GET: Lends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lend lend = db.Lends.Find(id);
            if (lend == null)
            {
                return HttpNotFound();
            }
            return View(lend);
        }

        // GET: Lends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PeriodOfLending")] Lend lend)
        {
            if (ModelState.IsValid)
            {
                db.Lends.Add(lend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lend);
        }

        // GET: Lends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lend lend = db.Lends.Find(id);
            if (lend == null)
            {
                return HttpNotFound();
            }
            return View(lend);
        }

        // POST: Lends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PeriodOfLending")] Lend lend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lend);
        }

        // GET: Lends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lend lend = db.Lends.Find(id);
            if (lend == null)
            {
                return HttpNotFound();
            }
            return View(lend);
        }

        // POST: Lends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lend lend = db.Lends.Find(id);
            db.Lends.Remove(lend);
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
