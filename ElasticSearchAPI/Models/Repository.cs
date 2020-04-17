using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchAPI.Models
{
    public class Repository : IRepository
    {
        private PrototypingElasticSearchWithASPNETCoreContext _context;

        public Repository(PrototypingElasticSearchWithASPNETCoreContext context)
        {
            _context = context;
        }

        public IQueryable<Person> Persons => _context.Person;

        public void Insert(Person person)
        {
            _context.Add(person);

            _context.SaveChanges();
        }
    }
}
