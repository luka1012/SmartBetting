using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace BookmakersApplication.Models
{
    public class Wallet
    {
        public int id { get; set; }
        [Range(0, double.MaxValue)]
        public double Amount { get; set; }
        public String Owner { get; set; }

        public List<Ticket> Tickets { get; set; }

    }




}