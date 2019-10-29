using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyMovies.Business
{
    //Represents a customer.
    public class Customer
    {
        //Holds customer id.
        public int Id { get; set; }

        //Holds customer name.
        [Required]
        public string CustomerName { get; set; }

        //Holds customer external id.
        public string CutomerExternalId { get {

                return CustomerName + Id;
            } }


        //Holds email address.
        [Required]
        public string Email { get; set; }
    }
}
