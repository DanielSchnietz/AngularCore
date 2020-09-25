using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebApp.Services
{
    public class DirectCostObject
    {
        public double DirectCost;
        public double Overhead;

        public async Task<DirectCostObject> calcDirectCost(dynamic obj, double percentage)
        {
            var result = new DirectCostObject();
            var calc = new PercentageCalculation();
            double res = 0;
            var task = Task.Run(() =>
            {

                foreach (var item in obj)
                {

                    res += item.Price * item.Amount;

                };
                return res;
            });
            result.DirectCost = await task;
            result.Overhead = calc.Multiply(DirectCost, percentage);

            return result;

        }
    }
}
