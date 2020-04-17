using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchAPI.Models.ElasticModels
{
    public class PersonSuggestResponse
    {
        public IEnumerable<PersonElasticModel> Suggests { get; set; }
    }
}
