using Secao_Person.Model;
using System.Collections.Generic;

namespace Secao_Person.Business
{
    public interface IPersonBusiness
    {
        PersonModel Create(PersonModel person);
        PersonModel FindById(long id);
        List<PersonModel> FindAll();
        PersonModel Update(PersonModel person);
        void Delete(long id);
    }
}
