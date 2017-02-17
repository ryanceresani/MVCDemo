using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public class PersonRepo
    {

        public List<Person> PersonList { get; set; }


        public PersonRepo()
        {
            PersonList = new List<Person>();

            Person p = new Person
            {
                LastName = "Smith",
                FirstName = "John",
                DateOfBirth = new DateTime(1967, 2, 18)
            };

            PersonList.Add(p);
        }

        public void Add(Person person)
        {
            PersonList.Add(person);
        }
    }
}
