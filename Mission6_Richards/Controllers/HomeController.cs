using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Richards.Models;

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
            return View();
        }

        // post the form data to the database and return confirmation page
        [HttpPost]
        public IActionResult EnterMovie(Application response)
        {
            _context.Applications.Add(response);
            _context.SaveChanges();

            return View("Confirmation");
        }
    } 
       
}
