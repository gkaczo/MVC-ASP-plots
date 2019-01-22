using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NCalc;

namespace WolframBeta.Models
{
    public class Funkcja
    {

        string wzorFunkcji;
        static private Expression r;

        public Funkcja()
        {

        }

        public Funkcja(string wzorFunkcji)
        {
            this.wzorFunkcji = wzorFunkcji;
             r = new Expression(wzorFunkcji);
           
        }

        public double WartoscFunkcji(double x)
        {
            double y = 0;
            r.Parameters["x"] = x;
            if (!double.TryParse(r.Evaluate().ToString(), out y))
            {
                throw new System.ArgumentException();
            }
            return y;
        }

       
    }
}