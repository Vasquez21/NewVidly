using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewVidly.Models;
using NewVidly.ViewModel;
using System.Data.Entity;
using Microsoft.AspNet.Identity;


namespace NewVidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel); 
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        // GET: Movies
        public ActionResult Random()
        {
            List<Movie> movies = GetMovies();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(mov => mov.Id == id);
            if (movie is null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);
            }
        }

        private List<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null) return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        //movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            else
            {
                return View("ListReadOnly");
            }
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByRelaseDate(int year, int month)
        {
            return Content("year:" + year + " / month:" + month); 
        }

    }
}