﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Review.View
{
    internal static class EditActionView
    {
        public static void ShowMenu()
        {
            DashSeparatorView.SeparateWithDashes();
            string menu = "\nMODUŁ - EDYTOWANIE INDEKSÓW\n";
            menu += "\n";
            Console.WriteLine(menu);
            DashSeparatorView.SeparateWithDashes();
        }
    }
}
