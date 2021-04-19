using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewVidly.Models;
using NewVidly.ViewModels;

namespace NewVidly.Controllers
{
    public class MoviesController : Controller
    {
        //GET:/Movies        
        
        public ActionResult Index()
        {
            var movie = new Movie() { Name = "Movies" };

            var customers = new List<Customer> //object initializer for creating customers
            {
                new Customer { Name = "Shrek!" },
                new Customer { Name = "Wall-E" }
            };

            var viewModel = new RandomMovieViewModels
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);

        }
        // GET: Movies/Random
        //public ActionResult Random()
        //{

        //    var movie = new Movie() { Name = "Movie" };

        //    var customers = new List<Customer> //object initializer for creating customers
        //    {
        //        new Customer { Name = "Shrek!" },
        //        new Customer { Name = "Wall-E" }
        //    };

        //    var viewModel = new RandomMovieViewModels
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };
        //    return View(viewModel);
        //    ////return Content("Episode 1");
        //    //return HttpNotFound();
        //    //return new EmptyResult();// dont want to have anything on the page
        //    //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" });
        //    //redirecting to previous page or the page before
        //}
        //[Route("movies/released/{year}/{month:regex(\\d{2}:range(1, 12))}")]
        //public ActionResult ByReleaseDate(int year, int month) //after creating a custom route it needs to be defined in the controller
        //{
        //    return Content(year + "/" + month);   
        //}

        //public ActionResult Edit(int id)
        //{
        //    return Content("id = " + id);
        //}

        //public ActionResult Index(int ?pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";

        //    return Content(String.Format("pageIndex={0}, sortBy={1}", pageIndex, sortBy)); //cant embed the values because it would require a custom route with two parameters
        //}
    }
}