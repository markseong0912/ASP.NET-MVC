using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
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
            //base.Dispose(disposing);	
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }
        public ViewResult New() // /Movies/New
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie) //public ActionResult New()
        {            
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
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
            else //updating properties
            {
                //Mapper.Map(Movie, movieInDb) //looks at the properties in movie object and then looks for properties with the same name
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
            //var genres = _context.Genres.ToList();
            //var viewModel = new MovieFormViewModel
            //{
            //    Genres = genres
            //};
            //return View("MovieForm", viewModel); //CustomerForm -> view name
        }
        public ActionResult Edit(int id) //Movies/Edit/id
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        //public ViewResult Index()
        //{
        //    var movies = GetMovies();
        //    return View(movies);
        //}

        //public ActionResult Details(int id)
        //{
        //    var movie = GetMovies().SingleOrDefault(m => m.Id == id);
        //    if (movie == null)
        //        return HttpNotFound();
        //    return View(movie);
        //}

        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie {Id = 1, Name = "Star Wars"},
        //        new Movie {Id = 2, Name = "E.T"}
        //    };
        //}
        // GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer { Name = "Customer 1" },
        //        new Customer { Name = "Customer 2" }
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}
    }
}