using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab3.Models;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        private PersonRepo repo;
        private readonly ApplicationDbContext _context;

        public  HomeController(ApplicationDbContext context)
        {
            _context = context;
            repo = new PersonRepo(context);
        }

        public IActionResult Index()
        {
            var date = DateTime.Now;
            var time = date.ToString("h:mm:ss tt");
            var day = date.ToString("dddd MMMM dd, yyyy");

            ViewData["Date"] = day;
            ViewData["Time"] = time;

            TimeSpan noon = new TimeSpan(12, 0, 0);
            TimeSpan six = new TimeSpan(18, 0, 0);

            //var testTime = new DateTime(date.Year, date.Month, date.Day, 5, 0, 0);
            //Replace date.TimeOfDay with custom test time to test logic.
            if (date.TimeOfDay < noon)
            {
                ViewData["Greeting"] = "Good Morning!";
            }
            else if (date.TimeOfDay < six)
            {
                ViewData["Greeting"] = "Good Afternoon!";
            }
            else
            {
                ViewData["Greeting"] = "Good Evening!";
            }

            var nextYear = new DateTime(date.Year + 1, 1, 1);
            int daysInYear = DateTime.IsLeapYear(date.Year) ? 366 : 365;
            int daysLeftInYear = daysInYear - date.DayOfYear;
            ViewData["DaysLeft"] = daysLeftInYear;
            ViewData["NextYear"] = nextYear.ToString("yyyy");

            return View(_context.Persons.ToList());
        }
        // GET: /<controller>/
        public IActionResult ShowPerson(int? id)
        {
            Person per;
            if (id == null)
            {
                per = new Person
                { 
                    FirstName = "Alan",
                    LastName = "Turing",
                    DateOfBirth = new DateTime(1912, 07, 23)
                };
                ViewData["RemoveEnabled"] = false;
            }
            else
            {
                ViewData["RemoveEnabled"] = true;
                per = _context.Persons.SingleOrDefault(p => p.ID == id);
            }

            return View(per);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var person = _context.Persons
                    .SingleOrDefault(p => p.ID == id);
            if (person == null)
            {
                return NotFound();
            }
            ViewData["RemoveEnabled"] = true;
            return View("ShowPerson", person);
        }

        public IActionResult EditPerson(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var person = _context.Persons
                    .SingleOrDefault(p => p.ID == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                repo.Edit(person);
                return RedirectToAction("Index");
            }
            else
            {
                return View(person);
            }
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(Person p)
        {
            if (ModelState.IsValid)
            {
                repo.Add(p);
                return RedirectToAction("Index");

            }  else  {
                return View(p);
            }
        }

        public IActionResult RemovePerson(int? id)
        {
           var person = _context.Persons.SingleOrDefault(p => p.ID == id);
           repo.Remove(person);
           return RedirectToAction("Index");
        }
    }
}

