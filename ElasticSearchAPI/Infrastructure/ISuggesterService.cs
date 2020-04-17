using ElasticSearchAPI.Models;
using ElasticSearchAPI.Models.ElasticModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElasticSearchAPI.Infrastructure
{
    public interface ISuggesterService
    {
        void Indexing(IRepository people);
        PersonSuggestResponse Suggest(string keyword);
    }
}
