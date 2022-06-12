using Adohope.Modules.Contacts.Contexts;
using Adohope.Modules.Contacts.Repos;
using Adohope.Modules.Contacts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Modules.Contacts.Factories
{
    public class PersonServiceFactory
    {
        public static PersonService CreateService(string backupPath)
        {
            var contextFactory = new ContactsContextFactory(backupPath);
            var contactsContext = contextFactory.CreateDbContext();
            var personRepository = new PersonRepository(contactsContext);
            return new PersonService(personRepository);
        }
    }
}
