using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookmakersApplication.Models
{
    public class SelectedPair
    {
        public int SelectedPairId { get; set; }

        public Tip SelectedTip { get; set; }
        public Quotas SelectedQuota { get; set; }
        // persisting the quota value separately because quota values could be changed over time
        public double QuotaValue { get; set; }

        public Ticket Ticket { get; set; }
    }
}