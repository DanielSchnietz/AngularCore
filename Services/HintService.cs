using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebApp.Services
{
    public class HintService
    {
        //normalize data and filter cloud for this data to respond with hints to ask questions 
        private string NormalizeData(string data)
        {
            //add more steps to get accurate search results
            var normalizedSearchTerm = data.ToLower();

            return normalizedSearchTerm;
        }
    }
}
