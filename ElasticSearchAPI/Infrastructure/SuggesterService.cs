using ElasticSearchAPI.Models;
using ElasticSearchAPI.Models.ElasticModels;
using Nest;
using System;
using System.Linq;

namespace ElasticSearchAPI.Infrastructure
{
    public class SuggesterService : ISuggesterService
    {
        private ElasticClient elasticClient;

        public SuggesterService()
        {
            elasticClient = new ElasticClient(new ConnectionSettings(new Uri("http://localhost:9200/")));
        }

        public void Indexing(IRepository people)
        {

            if (!elasticClient.Indices.Exists("people").Exists)
            {
                elasticClient.Indices.Create("people", d => d.Map<PersonElasticModel>(map => map.AutoMap().Properties(prop => prop.Completion(c => c.Name(n => n.Suggest)))));

                var _people = people.Persons.Select(p => new PersonElasticModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                });


                elasticClient.IndexMany(_people, "people");
            }
        }

        public PersonSuggestResponse Suggest(string keyword)
        {
            var searchResponse = elasticClient.Search<PersonElasticModel>(s => s.Index("people")
                    .Suggest(su => su
                        .Completion("suggest", cs => cs
                            .Field(f => f.Suggest)
                            .Prefix(keyword)
                            .Fuzzy(f => f
                                .Fuzziness(Fuzziness.Auto)
                            ).Size(20)
                        )
                    ));


            var suggestions = from suggest in searchResponse.Suggest["suggest"]
                              from option in suggest.Options
                              select new PersonElasticModel
                              {
                                  Id = option.Source.Id,
                                  FirstName = option.Source.FirstName
                              };

            return new PersonSuggestResponse
            {
                Suggests = suggestions.ToList()
            };
        }
    }
}
