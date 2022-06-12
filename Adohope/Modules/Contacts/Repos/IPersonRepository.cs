using Adohope.Modules.Contacts.Models;
using System.Collections.Generic;

namespace Adohope.Modules.Contacts.Repos
{
    public interface IPersonRepository
    {
        public void Add(Person person);
        public List<Person> GetAll();
        public void Remove(Person person);
    }
}