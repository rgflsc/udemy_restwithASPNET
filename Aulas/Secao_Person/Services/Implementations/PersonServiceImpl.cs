using Secao_Person.Model;
using System.Collections.Generic;

namespace Secao_Person.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        public PersonModel Create(PersonModel person)
        {
            return person;
        }
        public PersonModel FindById(long id)
        {
            return new PersonModel
            {
                Id = 1,
                FirstName = "Rodrigo",
                LastName = "Garcia",
                Address = "Rua Teste, 1",
                Gender = "Male"
            };
        }
        public List<PersonModel> FindAll()
        {
            List<PersonModel> persons = new List<PersonModel>();

            for (int i = 0; i < 8; i++)
            {
                PersonModel person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        private PersonModel MockPerson(int i) => new PersonModel
        {
            Id = i,
            FirstName = "Pessoa",
            LastName = "" + i,
            Address = "Rua Pessoa " + i + ", 1",
            Gender = "Male"
        };

        public PersonModel Update(PersonModel person)
        {
            return person;
        }
        public void Delete(long id)
        {
        }
    }
}
