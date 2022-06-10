using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Review.View
{
    internal static class MessageView
    {
        public static void IncorrectDataMessage()
        {
            DashSeparator.SeparateWithDashes();
            Console.WriteLine("\nWPROWADZONO NIEPOPRAWNE DANE!\n");
            DashSeparator.SeparateWithDashes();
        }
    }
}
