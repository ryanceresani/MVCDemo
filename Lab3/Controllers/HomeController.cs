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
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult ShowPerson()
        {
            ViewData["Title"] = "Show Person";
            Person p = new Person
            {
                LastName = "Smith",
                FirstName = "John",
                DateOfBirth = new DateTime(1968, 2, 16)
            };

            int age = DateTime.Today.Year - p.DateOfBirth.Year;

            if (DateTime.Now.Month < DateTime.Now.Month || (DateTime.Now.Month == DateTime.Now.Month && DateTime.Now.Day < DateTime.Now.Day))
            age--;

            p.Age = age;

            return View();
        }
    }
}

