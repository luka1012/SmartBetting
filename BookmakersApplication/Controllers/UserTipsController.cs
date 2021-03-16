﻿using System;
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
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace BookmakersApplication.Controllers
{

    public class UserTipsController : Controller
    {
        private BookmakerDbContext db = new BookmakerDbContext();

        private Tip tip = new Tip();



        /* public ActionResult Index()
         {

             return View(db.Tips.ToList());

         }*/
        public ActionResult MyIndex()
        {
            ViewBag.Msg = ViewBag.Message;
            return View("Index");
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

        /*  public ActionResult Create()
          {
              var vm = new Tip();
             vm.Options = GetItems();
              return View(vm);
          }*/
        /* [HttpGet]
        public ActionResult Create()
        {
            var vm = new OptionTip { Options = GetItems() };
            vm.Options = GetItems();
            return View("Index",vm.Options.ToList());
        }*/
        private List<Tip> GetItems()
        {
            return db.Tips.ToList();

        }






        // POST: UserInsertTips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipId,Pair,Quota1,Quota1X,QuotaX,QuotaX2,Quota2,IsTopOffer,Sport,Status,Result,AllTips,SelectedtItems")] Tip tip)
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
        public ActionResult Edit([Bind(Include = "TipId,Pair,Quota1,Quota1X,QuotaX,QuotaX2,Quota2,IsTopOffer,Sport,Status,Result,SelectedtItems")] Tip tip)
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
            return RedirectToAction("MyIndex");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        /* [HttpPost]
         public ActionResult Index(Tip model) {
             if (ModelState.IsValid)
             {
                 var t = model.SelectedtItems;

             }
         }*/
        
        public ActionResult Index()
        {

            var vm = new Tip { Options = GetItems() };
            vm.Options = GetItems();
            return View("Index", vm.Options);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "TipId,Pair,Quota1,Quota1X,QuotaX,QuotaX2,Quota2,IsTopOffer,Sport,Status,Result,SelectedtItems")] Tip model)
        {

            // Tip option = new Tip();
            if (!ModelState.IsValid)
            {

                var t = model.SelectedtItems;


                db.Tips.Add(model);
                db.SaveChanges();
                return RedirectToAction("MyIndex");

            }
                

            model.Options = GetItems();
            return View("Index", model.Options.ToList());

        }
     
    }
       
    }



    

    



   

