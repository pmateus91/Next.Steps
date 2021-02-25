using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Next.Steps.Application.Dtos
{
    public class PersonUpdateDto
    {
        [Required(ErrorMessage = "Person's Id is Required")]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Profession { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Email { get; set; }

        public List<HobbyDto> Hobbies { get; set; }
    }
}