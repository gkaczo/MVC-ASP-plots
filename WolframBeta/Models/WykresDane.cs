using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace WolframBeta.Models
{
    public class WykresDane
    {
      
       // [Range(1,10)]
        [Required(ErrorMessage = "Podaj początek przedziału")]     
        public double A { get; set; }

        [Required(ErrorMessage = "Podaj koniec przedziału")]
        [Range(Double.MinValue, Double.MaxValue)]
        public double B { get; set; }

        [Required(ErrorMessage = "Podaj podziałke")]
        [Range(Double.MinValue, Double.MaxValue)]
        public double Krok { get; set; }

        [Required(ErrorMessage ="Podaj wzór funkcji")]
        public string wzorFunkcji { get; set; }

        public double [] tabx {get;set;}
        public double [] taby { get; set; }

        //public string Info { get; set; }
    }
}