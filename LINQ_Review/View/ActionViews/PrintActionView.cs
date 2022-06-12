using System;
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
            menu += "\nDostęne akcje:";
            menu += "\n1 - Wyświetlanie wszystkich rekordów z pliku";
            menu += "\n2 - Filtrowanie i wyświetlanie danych indeksów";
            menu += "\n3 - Powrót do menu głownego";
            menu += "\n\nWpisz numer akcji i zaakceptuj klawiszem ENTER.\n";
            Console.WriteLine(menu);
            DashSeparator.SeparateWithDashes();
        }
    }
}
