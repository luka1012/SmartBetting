using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Double Amount{ get; set; }
        public String Owner { get; set; }
       
        public List<Ticket> Tickets { get; set; }
        public Double GetAmount() {
            if (Tickets == null) {
                return 0;
            }
            double amountSum = 0;
            foreach (var amount in Tickets) {
               amountSum = this.Amount - amount.Stake;
            }
            return amountSum;
        }
        [NotMapped]
        public  double NewAmount { get { return GetAmount(); } private set { } }
    }




}