using MediatR;
using Next.Steps.Application.Dtos;
using Next.Steps.Application.Query;
using Next.Steps.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Next.Steps.Application.QueryHandler
{
    public class PersonGetAllHandler : RequestHandler<PersonGetAllQuery, IEnumerable<PersonReadDto>>
    {
        private readonly IServicePerson _personService;

        public PersonGetAllHandler(IServicePerson personService)
        {
            _personService = personService;
        }

        protected override IEnumerable<PersonReadDto> Handle(PersonGetAllQuery request)
        {
            var list = _personService.GetAll();

            var personList = new List<PersonReadDto>();

            foreach (var item in list)
            {
                var hobList = new List<HobbyDto>();

                foreach (var h in item.Hobbies)
                {
                    hobList.Add(new HobbyDto
                    {
                        Id = h.Id,
                        Name = h.Name,
                        Category = h.Category
                    });
                }

                personList.Add(new PersonReadDto
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Profession = item.Profession,
                    Birthdate = item.BirthDate.ToString(),
                    Email = item.Email,
                    Hobbies = hobList
                });
            }
            return personList;
        }
    }
}