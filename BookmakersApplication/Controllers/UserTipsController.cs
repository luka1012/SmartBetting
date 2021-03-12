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
using System.Net.Http;



namespace BookmakersApplication.Controllers
{
    public class UserTipsController : Controller
    {
        private BookmakerDbContext db = new BookmakerDbContext();

        private Tip tip = new Tip();



        public ActionResult Index()
        {

            return View(db.Tips.ToList());

        }

        // GET: UserInsertTips/Details/5
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

        // GET: UserTips/Select
        
        public ActionResult Create()
        {
            var vm = new Tip();
            vm.Options = db.Tips.ToList();
            return View("Index",vm);
        }

        // POST: UserInsertTips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipId,Pair,Quota1,Quota1X,QuotaX,QuotaX2,Quota2,IsTopOffer,Sport,Status,Result,AllTips,SelectedItems")] Tip tip)
        {
            if (ModelState.IsValid)
            {
                db.Tips.Add(tip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tip);
        }

        // GET: UserInsertTips/Edit/5
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

        // POST: UserInsertTips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipId,Pair,Quota1,Quota1X,QuotaX,QuotaX2,Quota2,IsTopOffer,Sport,Status,Result,AllTips,SelectedItems")] Tip tip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tip).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tip);
        }

        // GET: UserInsertTips/Delete/5
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

        // POST: UserInsertTips/Delete/5
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


        [HttpPost]
        public ActionResult Ispis(Tip model)
        {
            if (ModelState.IsValid)
            {
                foreach (var q in model.Options)
                {
                    var t = model.SelectedtItems;
                    model.Options = db.Tips.ToList();
                    // Save the data 
                }
                return RedirectToAction("ThankYou"); //PRG Pattern
            }
            //to do : reload courses and options on model.
            return View(model);
        }








        /*[HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Select()
         {

             SelectedPair sp = new SelectedPair();
             var tip = db.Tips.ToList();
             foreach (var test in tip) {
                 if (test.isSelected == true)
                     db.Tips.AddRange(tip);
                 db.SaveChanges();
             }
             return View("Index",tip);
         }*/


        /*  public ActionResult SelectPair()
          {
              Ticket t = new Ticket();
              SelectedPair sp = new SelectedPair();
              var tip = db.Tips.ToList();
              foreach (var test in tip) {
                  test.Pair = "";

              }
              return View(tip);
          }*/




    }

    }

   

