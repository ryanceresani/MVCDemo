using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public class PersonRepo
    {
        private readonly ApplicationDbContext _context;

        public PersonRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Person> PersonList { get; set; }


        public PersonRepo()
        {
            PersonList = new List<Person>();

            Person p = new Person
            {
                ID = 0,
                LastName = "Smith",
                FirstName = "John",
                DateOfBirth = new DateTime(1967, 2, 18)
            };

            PersonList.Add(p);

           p = new Person
            {
               ID = 1,
               FirstName = "Alan",
               LastName = "Turing",
               DateOfBirth = new DateTime(1912, 07, 23)
           };

            PersonList.Add(p);

            p = new Person
            {
                ID = 2,
                FirstName = "Charles",
                LastName = "Babbage",
                DateOfBirth = new DateTime(1791, 12, 26)
            };
   
            PersonList.Add(p);
        }

        public void Add(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
        }

        public void Remove(Person person)
        {
            _context.Remove(person);
            _context.SaveChanges();
        }
        public void Edit(Person person)
        {

            _context.SaveChanges();
        }
    }
}
