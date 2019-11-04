using Secao_Person.Model;
using Secao_Person.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Secao_Person.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private MySqlContext _context;

        public PersonServiceImpl(MySqlContext context)
        {
            _context = context;
        }
        public PersonModel Create(PersonModel person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }
        public PersonModel FindById(long id)
        {
            return _context.Person.SingleOrDefault(p => p.Id.Equals(id));
        }
        public List<PersonModel> FindAll()
        {
            return _context.Person.ToList();
        }
        public PersonModel Update(PersonModel person)
        {
            if (!Exist(person.Id))
            {
                return new PersonModel();
            }

            var result = _context.Person.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        private bool Exist(long id)
        {
            return _context.Person.Any(p => p.Id.Equals(id));
        }

        public void Delete(long id)
        {
            var result = _context.Person.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (result != null) _context.Person.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
