using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularWebApp.Services
{
    public class Calculation
    {
        public double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public double Add(double firstNumber, double secondNumber, double thirdNumber)
        {
            return firstNumber + secondNumber + thirdNumber;
        }

        public double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public virtual double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        public double Divide(double firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber;
        }


    }
}
