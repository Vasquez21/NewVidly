using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewVidly.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }

        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

        [Required]
        public List<int> MoviesId { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}