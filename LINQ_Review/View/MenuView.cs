using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Review.View
{
    internal static class MenuView
    {
        public static void ShowMenu()
        {
            DashSeparatorView.SeparateWithDashes();

            string menu = "\nMENU GŁÓWNE\n";
            menu +="\nDostęne akcje:";
            menu += "\n1 - Wyświetlanie indeksów";
            menu += "\n2 - Dodawanie indeksów";
            menu += "\n3 - Edycja indeksów";
            menu += "\n4 - Usuwanie indeksów";
            menu += "\n5 - Zamknięcie aplikacji";
            menu += "\n\nWpisz numer akcji i zaakceptuj klawiszem ENTER.\n";

            Console.WriteLine(menu);
            DashSeparatorView.SeparateWithDashes();
        }
    }
}
