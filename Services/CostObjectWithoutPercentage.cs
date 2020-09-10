using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebApp.Services
{
    public class CostObjectWithoutPercentage
    {
        public string Description { get; set; }
        public int Value { get; set; }
        public CostObjectWithoutPercentage(string description, int value)
        {
            Description = description;
            Value = value;
        }
   
    }
}
