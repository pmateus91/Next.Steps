using Microsoft.EntityFrameworkCore;
using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Infrastructure.Context;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Next.Steps.Infrastructure.Repository
{
    public class PersonRepository : BaseRepository<Person>, IRepositoryPerson
    {
        public PersonRepository(NextStepsContext _nextStepsContext) : base(_nextStepsContext)
        {
        }

        public IEnumerable<Person> Search(string firstname, string lastname)
        {
            return _nextStepsContext.Persons.Where(p =>
            (!string.IsNullOrWhiteSpace(firstname) && p.FirstName == firstname) ||
            (!string.IsNullOrWhiteSpace(lastname) && p.LastName == lastname))
                .Include(p => p.Hobbies);
        }

        public override IEnumerable<Person> GetAll()
        {
            return _nextStepsContext.Persons.Include(p => p.Hobbies).ToList();
        }

        public override Person GetById(int id)
        {
            return _nextStepsContext.Persons
             .Where(p => p.Id == id)
             .Include(p => p.Hobbies)
             .FirstOrDefault();
        }

        public bool Remove(int id)
        {
            try
            {
                var person = GetById(id);
                _nextStepsContext.Persons.Remove(person);
                _nextStepsContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return false;
            }
        }
    }
}