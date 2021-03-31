using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookmakersApplication.BookmakerContext;
using BookmakersApplication.Models;

namespace BookmakersApplication.Controllers
{
    public class TipsAdminController : Controller
    {
        private BookmakerDbContext db = new BookmakerDbContext();

        // GET: TipsAdmin
        public ActionResult Index()
        {
            return View(db.Tips.ToList());
        }

        // GET: TipsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip tip = db.Tips.Find(id);
            if (tip == null)
            {
                return HttpNotFound();
            }
            return View(tip);
        }

        // GET: TipsAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipsAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipId,Pair,Quota1,Quota1X,QuotaX,QuotaX2,Quota2,IsTopOffer,Sport,Status,Result,IsSelected")] Tip tip)
        {
            if (ModelState.IsValid)
            {
                db.Tips.Add(tip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tip);
        }

        // GET: TipsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip tip = db.Tips.Find(id);
            if (tip == null)
            {
                return HttpNotFound();
            }
            return View(tip);
        }

        // POST: TipsAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipId,Pair,Quota1,Quota1X,QuotaX,QuotaX2,Quota2,IsTopOffer,Sport,Status,Result,IsSelected")] Tip tip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tip).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tip);
        }

        // GET: TipsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tip tip = db.Tips.Find(id);
            if (tip == null)
            {
                return HttpNotFound();
            }
            return View(tip);
        }

        // POST: TipsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tip tip = db.Tips.Find(id);
            db.Tips.Remove(tip);
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

        public ActionResult AvailableTips()
        {
            var tips = db.Tips.Where(t => t.Status == Status.Available).ToList();

            return View("Index", tips);
        }
        public ActionResult PairAvailable() { //function for checking pairs

            var tips = db.Tips.ToList();
            foreach (var test in tips) {
                if (test.Status == Status.Finished)
                    db.Tips.Remove(test);
                db.SaveChanges();
            }
            return View("Index",tips);
        }
        public ActionResult WinOrLose() {
            Tip tip = new Tip();
            var tips = db.SelectedPairs.ToList();
            foreach (var test in tips) {
                if (test.SelectedQuota == Quotas.Quota1)
                {
                    tip.Result = Result.HomeWin;
                }
                else if (test.SelectedQuota == Quotas.QuotaX)
                {

                    tip.Result = Result.Draw;
                }
                else if (test.SelectedQuota == Quotas.Quota2) {

                    tip.Result = Result.AwayWin;
                }
                        }
           
            return View("Index", tips);


        }

        
    
    }
}
