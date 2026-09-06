using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using project.Models;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private static List<Student> _students = new List<Student>
    {
        new Student { Id = 1, FirstName = "Alice", LastName = "ne", GradeLevel = 12, MathScore = 95, EnglishScore = 88 },
        new Student { Id = 2, FirstName = "Bob", LastName = "ne", GradeLevel = 12, MathScore = 82, EnglishScore = 91 }
    };
        [HttpGet]
        public IActionResult StudentTab()
        {
            return View(_students);
        }

        [HttpPost]
        public IActionResult StudentTab(string firstName, string lastName, int gradeLevel, double mathScore, double englishScore)
        {
            int newId = _students.Count > 0 ? _students.Max(s => s.Id) + 1 : 1;
            _students.Add(new Student
            {
                Id = newId,
                FirstName = firstName,
                LastName = lastName,
                GradeLevel = gradeLevel,
                MathScore = mathScore,
                EnglishScore = englishScore
            });
            return View(_students);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
