using Secao_Person.Model;
using Secao_Person.Model.Context;
using Secao_Person.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Secao_Person.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository _repository;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
        }
        public PersonModel Create(PersonModel person)
        {
            return _repository.Create(person);
        }
        public PersonModel FindById(long id)
        {
            return _repository.FindById(id);
        }
        public List<PersonModel> FindAll()
        {
            return _repository.FindAll();
        }
        public PersonModel Update(PersonModel person)
        {
            return _repository.Update(person);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
