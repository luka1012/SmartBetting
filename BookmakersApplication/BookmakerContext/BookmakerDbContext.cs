using BookmakersApplication.Database;
using BookmakersApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookmakersApplication.BookmakerContext
{
    public class BookmakerDbContext : DbContext
    {
        public DbSet<Tip> Tips { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public BookmakerDbContext():base("SQLEXPRESS")
        {
          System.Data.Entity.Database.SetInitializer<BookmakerDbContext>(new DatabaseInitializer());
        }
      
      public System.Data.Entity.DbSet<BookmakersApplication.Models.SelectedPair> SelectedPairs { get; set; }

    }
}