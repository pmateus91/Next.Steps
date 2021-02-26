using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Next.Steps.Application.Dtos
{
    public class PersonWriteDto
    {
        [Required(ErrorMessage = "Person's Firstname is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Person's Lastname is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Person's Profession is Required")]
        public string Profession { get; set; }

        [Required(ErrorMessage = "Person's Birthday is Required")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Person's Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        public virtual IEnumerable<HobbyWriteDto> Hobbies { get; set; }
    }
}