﻿using Next.Steps.Domain.Interfaces;
using Next.Steps.Domain.ValueTypes;
using System;
using System.Collections.Generic;

namespace Next.Steps.Domain.Entities
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public List<Hobby> Hobbies { get; set; }
    }
}
