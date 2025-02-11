using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Taylor.Models;

namespace Mission06_Taylor.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context; //naming convention to say that this is a private variable brought in through the constructor
        public HomeController(MovieContext temp) //Constructor. Builds an instance of the database, brings it in and stores it in a permanent variable.
        { 
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet] //Get methods are the default. This just renders the page. The post below is what actually sends the data from the form
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            _context.Movies.Add(response); //Adds that record from the response to the database
            _context.SaveChanges(); //Commits to the database

            return View("SubmissionSuccessful", response);
        }
    }
}
