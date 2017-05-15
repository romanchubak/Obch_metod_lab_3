using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace met_obch_lab_3
{
    class Program
    {
        static double function(double x, double y) { return y / x - y - x; }
        static double meanFunc(double x) { return x * (Math.Pow(Math.E,0-x) - 1); } 

        static void Main(string[] args)
        {
            //y'=y/x -y-x, y(1) = 1/e - 1 , [1,4.5] 
            // точний розвязок y = x(1/e-1);
            double y0 = meanFunc(1);
            double a = 1, b = 4.5, e = 0.000000001;
            int N = 10;
            double yi = y0;
            Console.WriteLine("Точне значення: {0}",meanFunc(b));
            while ( Math.Abs(yi - meanFunc(b)) > e)
            {
                double h = (b - a) / N;
                yi = y0;
                for (int i = 0; i < N; i++)
                {
                    double ti = a + h * i;
                    double k1 = function(ti, yi);
                    double k2 = function(ti + h/ 4, yi + h / 4 * k1);
                    double k3 = function(ti + h / 2, yi + h * k2 / 2);
                    double k4 = function(ti + h, yi + h * k1 - 2 * h * k2 + 2 * h * k3);                    
                    yi +=  h / 6 * (k1 + 4 * k3 + k4);
                }
                N *= 2;
            }
            Console.WriteLine("yi = {0}, N = {1}",yi,N);
            Console.ReadKey();
        }
    }
}
