using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ_Review.Controler;

namespace LINQ_Review
{
    class Program
    {
        static void Main(string[] args)
        {
            //AppControler appControler = new AppControler();
            //appControler.RunApp();
            List<string> lista = new List<string>();
            lista = File.ReadAllLines("DataSetCopy.csv").ToList();

            lista.ForEach(x => Console.WriteLine(x));


            //lista.Add("2000;0;0;0");
            //lista.Add("2001;0;0;0");

            //File.WriteAllLines("DataSet.csv", lista);
        }
    }
}
