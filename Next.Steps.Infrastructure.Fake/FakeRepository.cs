using Next.Steps.Domain.Entities;
using Next.Steps.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Next.Steps.Infrastructure.Fake
{
    public class FakeRepository : IRepositoryPerson
    {
        private static List<Person> personList = new List<Person>();
        private static List<Hobby> hobbyList = new List<Hobby>();
        private static int personId = 1;
        private static int hobbyId = 1;

        public FakeRepository()
        {
            var jogar = new Hobby
            {
                Name = "Jogar",
                Category = "Divertimento",
            };

            var dormir = new Hobby
            {
                Name = "Dormir",
                Category = "Perguica",
            };
            var come = new Hobby
            {
                Name = "Come",
                Category = "Fome",
            };

            var person1 = new Person
            {
                FirstName = "Pedro",
                LastName = "Mateus",
                BirthDate = DateTime.Now,
                Email = "pedro.mateus@decode.pt",
                Profession = "Dev",
                Hobbies = new List<Hobby>() { jogar }
            };
            var person2 = new Person
            {
                FirstName = "Pedro",
                LastName = "Monteiro",
                BirthDate = DateTime.Now,
                Email = "pedro.monteiro@decode.pt",
                Profession = "Dev",
                Hobbies = new List<Hobby> { dormir }
            };

            var person3 = new Person
            {
                FirstName = "Carlos",
                LastName = "Ferreira",
                BirthDate = DateTime.Now,
                Email = "carlos.ferreira@decode.pt",
                Profession = "Dev",
                Hobbies = new List<Hobby> { come }
            };

            Add(person1);
            Add(person2);
            Add(person3);
        }

        public IEnumerable<Person> GetAll()
        {
            return personList;
        }

        public Person GetById(int id)
        {
            var index = personList.FindIndex(f => f.Id == id);

            if (index > 0)
            {
                return personList[index];
            }
            else
            {
                return null;
            }
        }

        public bool Add(Person obj)
        {
            obj.Id = personId;

            foreach (var item in obj.Hobbies)
            {
                item.Id = hobbyId;
                hobbyId++;
                hobbyList.Add(item);
            }
            personList.Add(obj);
            personId++;
            return true;
        }

        public bool Update(Person obj)
        {
            var index = personList.FindIndex(f => f.Id == obj.Id);
            personList[index] = obj;
            return true;
        }

        public bool Remove(int id)
        {
            var index = personList.FindIndex(f => f.Id == id);
            personList.RemoveAt(index);
            return true;
        }

        public IEnumerable<Person> Search(string firstname, string lastname)
        {
            return personList.FindAll(p =>
            (!string.IsNullOrWhiteSpace(firstname) && p.FirstName == firstname) ||
            (!string.IsNullOrWhiteSpace(lastname) && p.LastName == lastname));
        }

        public bool Remove(Person obj)
        {
            throw new NotImplementedException();
        }
    }
}