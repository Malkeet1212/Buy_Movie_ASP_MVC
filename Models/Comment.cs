using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMovies.Business
{
    //Represents a  customer comment.
    public class Comment
    {
        //Holds comment id.
        public int Id { get; set; }

        // Holds customer id.
        public int   CustomerId{get; set;}

        //Holds customer relationship.
        public Customer Customer { get; set; }

        //Holds comment text.
        [Required]
        public string CommentText { get; set; }

    }
}
