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
    }
}
