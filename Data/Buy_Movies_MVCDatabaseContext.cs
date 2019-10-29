using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuyMovies.Business;

namespace Buy_Movies_MVC.Models
{
    //Connects and mapps the model object to database.
    public class Buy_Movies_MVCDatabaseContext : DbContext
    {
        public Buy_Movies_MVCDatabaseContext (DbContextOptions<Buy_Movies_MVCDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<BuyMovies.Business.Comment> Comment { get; set; }

        public DbSet<BuyMovies.Business.Customer> Customer { get; set; }

        public DbSet<BuyMovies.Business.Movie> Movie { get; set; }

        public DbSet<BuyMovies.Business.MovieTransaction> MovieTransaction { get; set; }
    }
}
