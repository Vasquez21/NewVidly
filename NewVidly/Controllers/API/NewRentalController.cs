using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewVidly.Dtos;

namespace NewVidly.Controllers.API
{
    public class NewRentalController : ApiController
    {
        // POST /api/movies 
        [HttpPost] 
        public IHttpActionResult CreateNewRental(RentalDto rentalDto)
        {
            throw new NotImplementedException();
        }
    }
}
