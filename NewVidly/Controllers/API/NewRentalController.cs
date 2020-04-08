using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using NewVidly.Dtos;
using NewVidly.Models;

namespace NewVidly.Controllers.API
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        // POST /api/rentals 
        [HttpPost] 
        public IHttpActionResult CreateNewRental(RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (rentalDto.MoviesId.Count == 0)
                return BadRequest("No moviesId have been given");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is not valid");


            var movies = _context.Movies.Where(m => rentalDto.MoviesId.Contains(m.Id)).ToList();

            if (movies.Count() != rentalDto.MoviesId.Count)
                return BadRequest("One or more movies id are invalid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberInStock--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
