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
    public class WalletsController : Controller
    {
        private BookmakerDbContext db = new BookmakerDbContext();
        Wallet wl = new Wallet();
        Ticket tc = new Ticket();

        // GET: Wallets
        public ActionResult Index()
        {
            return View(db.Wallets.ToList());
        }

        // GET: Wallets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wallet wallet = db.Wallets.Find(id);
            if (wallet == null)
            {
                return HttpNotFound();
            }
            return View(wallet);
        }

        // GET: Wallets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wallets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Amount,Owner")] Wallet wallet)
        {
            if (ModelState.IsValid)
            {
                db.Wallets.Add(wallet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wallet);
        }

        // GET: Wallets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wallet wallet = db.Wallets.Find(id);
            if (wallet == null)
            {
                return HttpNotFound();
            }
            return View(wallet);
        }

        // POST: Wallets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Amount,Owner")] Wallet wallet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wallet).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wallet);
        }

        // GET: Wallets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wallet wallet = db.Wallets.Find(id);
            if (wallet == null)
            {
                return HttpNotFound();
            }
            return View(wallet);
        }

        // POST: Wallets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wallet wallet = db.Wallets.Find(id);
            db.Wallets.Remove(wallet);
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

        public ActionResult SelectedTickets() {
            var tickets = db.Wallets.ToList();

            return View(tickets);

        }


        public ActionResult WalletState()
        {
            Ticket ticket = new Ticket();
            Wallet wallet = new Wallet();
            var customers = db.Tickets.Where(t => t.Stake == t.TicketId).ToList();
            foreach (var test in customers) {
               
                test.Wallet.Amount = test.Wallet.Amount - ticket.Stake;
                db.Wallets.Add(wallet);
                db.SaveChanges();
            }
           
            return View("Index",customers);



        }
        public ActionResult AmountOfOwner() {
            Ticket ticket = new Ticket();
            Wallet wallet = new Wallet();
            wallet.Tickets = db.Tickets.Where(t => t.TicketId == t.TicketId).ToList();
            foreach(var test in wallet.Tickets)
            {
                wallet.Amount = wallet.Amount - test.Stake;
                db.Wallets.Add(wallet);

            }
            return View("Index", wallet);
        }
        
    }
}
