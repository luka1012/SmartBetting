using BookmakersApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookmakersApplication.ViewModel
{
    public class Offer
    {

        public Quotas SelectedQuota { get; set; } = Quotas.None;

        public Tip Tip { get; set; }
    }
}