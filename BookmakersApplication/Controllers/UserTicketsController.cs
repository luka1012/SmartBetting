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
    public class UserTicketsController : Controller
    {
        private BookmakerDbContext db = new BookmakerDbContext();

        // GET: UserTickets
        public ActionResult Index()
        {
            return View(db.Tickets.Include(x => x.SelectedPairs).ToList());
        }

        // GET: UserTickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);

            List <SelectedPair> selectedPairs= db.SelectedPairs.Where(p => p.Ticket.TicketId == id).Include(x => x.SelectedTip).ToList();

            ticket.SelectedPairs = selectedPairs; 
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: UserTickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketId,Stake,Winning")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        // GET: UserTickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);

            List<SelectedPair> selectedPairs = db.SelectedPairs.Where(p => p.Ticket.TicketId == id).Include(x => x.SelectedTip).ToList();

            ticket.SelectedPairs = selectedPairs;
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: UserTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketId,Stake,SelectedPairs")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: UserTickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: UserTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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
