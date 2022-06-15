using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Review.View
{
    internal static class AppView
    {
        public static void Run()
        {
            DashSeparator.SeparateWithDashes();
            Console.WriteLine("\nAPLIKACJA DO PRACY ZE WSKAŹNIKAMI\n");
            DashSeparator.SeparateWithDashes();
        }

        public static void ShutDown()
        {
            DashSeparator.SeparateWithDashes();
            Console.WriteLine("\nDZIĘKUJEMY ZA SKORZYSTANIE Z APLIKACJI!\n");
            DashSeparator.SeparateWithDashes();
        }
    }
}
