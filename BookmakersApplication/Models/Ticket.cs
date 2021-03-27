using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookmakersApplication.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public Wallet Wallet { get; set; }

        public List<SelectedPair> SelectedPairs { get; set; } 
        public Double Stake { get; set; }
        public Double GetWinning() {

            if(SelectedPairs == null)
            {
                return 0; 
            }
            double quotaSum = 0;
            foreach (var selectedPair in SelectedPairs) {
                quotaSum += selectedPair.QuotaValue;
            }
            //calculating potential winning from stake and final quota of ticket
            double winning = this.Stake * 0.95 * quotaSum;
            return winning;
        }
        [NotMapped]
        public double Winning { get { return GetWinning(); } private set { } }
   
        }

       





    }

    

    
     
    
    
