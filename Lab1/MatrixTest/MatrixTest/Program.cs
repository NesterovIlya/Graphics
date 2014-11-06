using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLib;

namespace MatrixTest
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Double> rez = new List<double>();
            String[] arr = System.IO.File.ReadAllLines("test1.txt");
            foreach (String str in arr)
            {
                List<Double> tmp = str.Split(' ').Select(n => Convert.ToDouble(n)).ToList();
                rez.AddRange(tmp);
            }

            //List<double> arr1 = System.IO.File.ReadAllLines("test1.txt").Split(' ').Select(n => Convert.ToDouble(n)).ToList();
            //List<double> arr2 = System.IO.File.ReadAllText("test2.txt").Split(' ').Select(n => Convert.ToDouble(n)).ToList();

            Matrix A = new Matrix(3,3,rez);
            //Matrix B = new Matrix(3,4,arr2);

            A.print();
            //B.print();
            Console.ReadKey();
        }
    }
}
