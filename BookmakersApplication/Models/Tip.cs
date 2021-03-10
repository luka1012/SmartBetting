using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.ComponentModel.DataAnnotations;

namespace BookmakersApplication.Models
{
    public class Tip    {
        public int TipId { get; set; }

        [Required]
        public String Pair { get; set; }
        public double Quota1 { get; set; }
        public double Quota1X { get; set; }
        public double QuotaX { get; set; }
        public double QuotaX2 { get; set; }
        public double Quota2 { get; set; }
        public Boolean IsTopOffer { get; set; } = false; 
        public String Sport { get; set; }
        public Status Status { get; set; } = Status.Available; 
        public Result Result { get; set; }

      

        
    }
        
}