using ElasticSearchAPI.Infrastructure;
using ElasticSearchAPI.Models;
using ElasticSearchAPI.Models.ElasticModels;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            //_elasticSearch.Indexing(repository);
        }

        [HttpGet("{keyword}")]
        public IEnumerable<PersonElasticModel> Get(string keyword)
        {
            return _elasticSearch.Suggest(keyword).Suggests;
        }
    }
}
