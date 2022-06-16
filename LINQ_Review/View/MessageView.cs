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
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nWPROWADZONO NIEPOPRAWNE DANE!\n");
        }

        public static void AlreadyUsedFilteringProperty()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nFILTROWANIE PO TEJ WŁAŚCIWOŚCI JEST JUŻ ZAAPLIKOWANE!\n");
        }

        public static void NoDataToPrint()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nBRAK DANYCH DO WYŚWIETLENIA\n");
        }

        public static void NoGivenData()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nNIE PODANO WYMAGANYCH DANYCH!\n");
        }

        public static void IncorrectScope()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nPODANY ZAKRES JEST NIEPOPRAWNY! GÓRNA GRANICA MUSI MIEĆ WARTOŚĆ WIĘKSZĄ NIŻ DOLNA GRANICA!\n");
            DashSeparatorView.SeparateWithDashes();
        }
    }
}
