using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMovies.Business
{
    //Holds a movie transaction
    public class MovieTransaction
    {

        //Holds transaction id.
        public int Id { get; set; }

        //Holds movie id.
        public int MovieId { get; set; }

        //Holds customer id.
        public int CustomerId { get; set; }


        //Holds movie relationship.
        public Movie  Movie{get; set;}

        //Holds customer relationship.
        public Customer Customer { get; set; }

    }
}
