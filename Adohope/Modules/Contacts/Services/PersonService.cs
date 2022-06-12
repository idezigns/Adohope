using Adohope.Modules.Contacts.Models;
using Adohope.Modules.Contacts.Repos;
using System.Collections.Generic;

namespace Adohope.Modules.Contacts.Services
{
    public class PersonService
    {
        #region Constructors

        public PersonService(IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }

        #endregion

        #region Properties

        public IPersonRepository PersonRepository { get; }

        #endregion

        #region Methods

        public List<Person> GetAllPersons()
        {
            var persons = PersonRepository.GetAll();

            return persons;
        }

        #endregion
    }
}
