using BookmakersApplication.BookmakerContext;
using BookmakersApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookmakersApplication.Database
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<BookmakerDbContext>
    {
        protected override void Seed(BookmakerDbContext dbContext)
        {
            base.Seed(dbContext);
            IList<Models.Tip> currentOffers = new List<Tip> {
             new Tip(){ Pair= "Chelsea-Manchester",TipId=1, IsTopOffer=false, Quota1=1.5,Quota1X=1.3, QuotaX=4, QuotaX2=1.8, Quota2=2.5, Sport="Nogome" },
                new Tip() {Pair= "Dinamo-Hajduk",TipId=2, IsTopOffer=true, Quota1=1.3,Quota1X=1.15, QuotaX=4, QuotaX2=2.8, Quota2=5,Sport="Nogomet" } ,
                new Tip() { Pair= "Liverpool-Manchester United",TipId=3, IsTopOffer=false, Quota1=2.3,Quota1X=1.7, QuotaX=3, QuotaX2=1.8, Quota2=2.5,Sport="Nogomet" } ,
                new Tip() { Pair= "Bayern Munchen-Hoffenheim",TipId=4, IsTopOffer=false, Quota1=1.3,Quota1X=1.5, QuotaX=5, QuotaX2=2, Quota2=5, Sport="Nogomet" } ,
                new Tip() {Pair= "Milan-Lazio",TipId=5, IsTopOffer=true, Quota1=1.5 ,Quota1X=1.9, QuotaX=3, QuotaX2=1.8, Quota2=4,Sport="Nogomet" },
                new Tip(){ Pair="Đoković-Nadal", TipId=6,IsTopOffer=true, Quota1=1.6,Quota2=2.5, Sport="Tenis"},
                new Tip(){ Pair="Chicago Bulls-Boston Celtics",TipId=7,IsTopOffer=false,Quota1=3, Quota1X=1.4, QuotaX=50, QuotaX2=1.2,Quota2=1.5,Sport="Košarka"}
            };
            dbContext.Tips.AddRange(currentOffers);
            dbContext.SaveChanges();


            IList<Models.Wallet> currentWallet = new List<Wallet> {
                new Wallet(){id=1, Amount=45,Owner="Marko Marković" },
                new Wallet(){id=2, Amount=25,Owner="Ante Petrić" },
                new Wallet(){id=3, Amount=50,Owner="Marko Perković" }

            };
            dbContext.Wallets.AddRange(currentWallet);
            dbContext.SaveChanges();
        }
    }
}