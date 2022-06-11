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
            try
            {
                AppControler appControler = new AppControler();
                appControler.RunApp();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
