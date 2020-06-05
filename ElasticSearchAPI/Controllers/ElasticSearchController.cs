using ElasticSearchAPI.Infrastructure;
using ElasticSearchAPI.Models;
using ElasticSearchAPI.Models.ElasticModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ElasticSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElasticSearchController : Controller
    {
        private ISuggesterService _elasticSearch;

        public ElasticSearchController(ISuggesterService elasticSearch, IRepository repository)
        {
            _elasticSearch = elasticSearch;

            _elasticSearch.Indexing(repository);
        }

        [HttpGet("{keyword}")]
        public List<PersonElasticModel> Get(string keyword)
        {
            return _elasticSearch.Suggest(keyword).Suggests;
        }
    }
}
