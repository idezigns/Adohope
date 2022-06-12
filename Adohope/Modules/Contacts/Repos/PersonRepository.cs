using Adohope.Modules.Contacts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adohope.Modules.Contacts.Repos
{
    public class PersonRepository : IPersonRepository
    {
        #region Constructors

        public PersonRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        #endregion

        #region Properties

        public readonly DbContext DbContext;

        #endregion

        #region Interfaces

        public List<Person> GetAll()
        {
            return DbContext.Set<Person>()
                .Include(p => p.MultiValues)
                .ToList();
        }

        public void Add(Person person)
        {
            DbContext.Set<Person>().Add(person);
        }

        public void Remove(Person person)
        {
            DbContext.Set<Person>().Remove(person);
        }

        #endregion
    }
}
