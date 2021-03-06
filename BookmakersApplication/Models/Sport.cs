using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookmakersApplication.Models
{
    public class Sport
    {
        public int id { get; set; }
        public String Name { get; set; }
        public Boolean Odd { get; set; }


    }
    public class SportDBContext : DbContext
    {
        public System.Data.Entity.DbSet<BookmakersApplication.Models.Sport> Sport { get; set; }

    }
}