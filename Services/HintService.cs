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
            var normalizedSearchTerm = data.ToLower();
           // DatabaseAccess.CheckDbForHint(normalizedSearchTerm.Split(" "));
            return normalizedSearchTerm;
        }
    }
}
