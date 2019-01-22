using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WolframBeta.Models;

namespace WolframBeta.Controllers
{
    public class WykresDaneController : Controller
    {
        List<double> yLst = new List<double>();
        List<double> xLst = new List<double>();
        double A;  //poczatek przedzialu
        double B;  //koniec przedzialu

        // GET: WykresDane
        public ActionResult Index()
        {
            return View();
        }
        //GET
        public ViewResult PobierzDane()
        {
            return View();
        }

        
        private void GenerujPunkty(double krok, string wzorFunkcji)
        {
           
                Funkcja f = new Funkcja(wzorFunkcji);

                double x;
                x = A - krok;

                while (x < B)
                {
                    x = x + krok;
                    if (f.WartoscFunkcji(x) < double.MaxValue) //unikamy przepelnienia stosu
                    {
                        xLst.Add(x);
                        yLst.Add(f.WartoscFunkcji(x));
                    }

                }
    
        }
        

        [HttpPost]
       // [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PobierzDane(WykresDane w)
        {
            if (ModelState.IsValid)
            {
                A = w.A;
                B = w.B;
                GenerujPunkty(w.Krok, w.wzorFunkcji);

                int count = xLst.Count;

                w.tabx = new double[count];
                w.taby = new double[count];

                for (int i = 0; i < count; i++)
                {
                    w.tabx[i] = xLst[i];
                    w.taby[i] = yLst[i];

                }
                return Json(w);
            }
            return View();

        }
    }
}