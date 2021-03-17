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
using System.Data.Entity.Validation;
using System.Diagnostics;
using BookmakersApplication.ViewModel;

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
        public ActionResult Success()
        {
            ViewBag.Msg = ViewBag.Message;
            return View("Success");
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


            List<Offer> Offers = new List<Offer>();

            var Tips = db.Tips.ToList(); 

            foreach(var Tip in Tips)
            {
                Offers.Add(new Offer() { Tip = Tip }); 
            }

            return View("Index",Offers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post( IList<Offer> model)
        {
            
            // Tip option = new Tip();
            if (model.Where(o => o.SelectedQuota != Quotas.None).Count() > 0) // Selected pairs must contain at least one pair with selected quota other than None
            {
                Ticket ticket = new Ticket();

                ticket.SelectedPairs = new List<SelectedPair>();

                var offers = model.Where(o => o.SelectedQuota != Quotas.None); 


                foreach (var t in offers)
                {

                    ticket.SelectedPairs.Add(new SelectedPair() { SelectedTip = db.Tips.Find(t.Tip.TipId), SelectedQuota = t.SelectedQuota, QuotaValue = getQuotaValue(t.SelectedQuota, t.Tip.TipId) });//TODO:fix hardcoded values
                }

                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("MyIndex");

            }



            return RedirectToAction("Index");

        }

        private double getQuotaValue(Quotas selectedQuota, int tipId)
        {
            var tip = db.Tips.Find(tipId);

            if (tip != null)
            {
                switch (selectedQuota)
                {
                    case Quotas.Quota1:
                        return tip.Quota1;
                    case Quotas.Quota1x:
                        return tip.Quota1X;
                    case Quotas.QuotaX:
                        return tip.QuotaX;
                    case Quotas.QuotaX2:
                        return tip.QuotaX2;
                    case Quotas.Quota2:
                        return tip.Quota2;
                    case Quotas.None:
                        throw new HttpException("A qouta is not selected");

                    default:
                        throw new HttpException("A qouta is not selected");

                }
            } else
            {
                throw new HttpException("Not Found Exception");
            }
        }
    }
       
    }



    

    



   

