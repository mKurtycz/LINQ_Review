﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Review.View
{
    internal static class PrintActionView
    {
        public static void ShowMenu()
        {
            DashSeparator.SeparateWithDashes();
            string menu = "\nMODUŁ - WYŚWIETLANIE INDEKSÓW\n";
            menu += "\n";
            Console.WriteLine(menu);
            DashSeparator.SeparateWithDashes();
        }
    }
}
