using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ElasticSearchAPI.Models.ElasticModels
{
    public class PersonElasticModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public CompletionField Suggest
        {
            get
            {
                return new CompletionField
                {
                    Input = FirstName.Split()
                };
            }
        }
    }
}
