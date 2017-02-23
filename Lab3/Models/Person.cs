using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public class Person
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "The First Name field is required.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Enter a name between 2 and 20 characters long.")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name field is required.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Enter a name between 2 and 20 characters long.")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "The Date of Birth field is required.")]
        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                int age = DateTime.Today.Year - DateOfBirth.Year;

                if (DateTime.Now.Month < DateOfBirth.Month || (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
                    age--;

                return age;
            }
        }
    }
}
