using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Services.Description;
using BookmakersApplication.BookmakerContext;
using BookmakersApplication.Database;
using BookmakersApplication.Models;

namespace BookmakersApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            // just for testing purposes; 

            BookmakerDbContext context = new BookmakerDbContext();

            InitialValues.Initialize(context); 

            Tip tip = context.Tips.First();

            Console.WriteLine("The first tip is {0}", tip.Pair); 
        }
    }
        
       
       
    }

