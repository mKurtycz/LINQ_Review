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
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nAPLIKACJA DO PRACY ZE WSKAŹNIKAMI\n");
        }

        public static void ShutDown()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nDZIĘKUJEMY ZA SKORZYSTANIE Z APLIKACJI!\n");
            DashSeparatorView.SeparateWithDashes();
        }
    }
}
