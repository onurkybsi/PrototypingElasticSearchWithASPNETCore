using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchAPI.Models
{
    public interface IRepository
    {
        IQueryable<Person> Persons { get; }

        void Insert(Person person);
    }
}
