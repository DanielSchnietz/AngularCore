using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebApp.Services
{
    public class PercentageCalculation: Calculation
    {
        public override double Multiply(double value, double percentage)
        {
             return value * percentage / 100;
        }
    }
}
