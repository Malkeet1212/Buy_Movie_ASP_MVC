using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMovies.Business
{
    //Represents a movie.
    public class Movie
    {
        //Holds Movie id
        public int Id { get; set; }

        //Holds movie name.
        [Required]
        public string MovieName { get; set; }

        //Holds movie genre.
        [Required]
        public string Genre { get; set; }

        //Holds movie price.
        [Required]
        public decimal Price { get; set; }
    }
}
