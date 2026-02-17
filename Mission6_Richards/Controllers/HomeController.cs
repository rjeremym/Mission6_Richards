using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Richards.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6_Richards.Controllers
{
    public class HomeController : Controller
    {

        private MovieContext _context;

        // constructor to initialize the database context
        public HomeController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // get page
        [HttpGet]
        public IActionResult EnterMovie()
        {
            ViewBag.Categories = _context.Categories
        .OrderBy(x => x.CategoryName)
        .ToList();
            return View();
        }

        // post the form data to the database and return confirmation page
        [HttpPost]
        public IActionResult EnterMovie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation");
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View(response);
            }
        }


        public IActionResult MovieList()
        {
            var movies = _context.Movies
                .Include(x => x.Category) // include category name from that table
                .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("EnterMovie", movieToEdit);  // point to existing view
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(movieToDelete);

        }

        [HttpPost]
        public IActionResult Delete(Movie response)
        {
            _context.Movies.Remove(response);
            _context.SaveChanges();
            return RedirectToAction("MovieList");

        }
    } 
       
}
