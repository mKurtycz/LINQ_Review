namespace LINQ_Review.View
{
    internal static class MessageView
    {
        // Displays a message, when appears attempt to process invalid data
        public static void InvalidDataMessage()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nWPROWADZONO NIEPOPRAWNE DANE!\n");
        }

        // Displays a message, when user tries to filter data using the same property twice
        public static void AlreadyUsedFilteringPropertyMessage()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nFILTROWANIE PO TEJ WŁAŚCIWOŚCI JEST JUŻ ZAAPLIKOWANE!\n");
        }

        // Displays a message, when there is no data to display 
        public static void NoDataToPrintMessage()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nBRAK DANYCH DO WYŚWIETLENIA!\n");
        }

        // Displays a message, when user didn't submit any data
        public static void NoGivenDataMessage()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nNIE PODANO WYMAGANYCH DANYCH!\n");
        }

        // Displays a message, when user tries to set wrong scope of filtering
        public static void InvalidScopeMessage()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nPODANY ZAKRES JEST NIEPOPRAWNY! GÓRNA GRANICA MUSI MIEĆ WARTOŚĆ WIĘKSZĄ NIŻ DOLNA GRANICA!\n");
        }

        // Displays a message, when user doesn't specify scope of filtering
        public static void NoFilteringScopeAppliedMessage()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nNIE WYBRANO ZAKRESU FILTROWANIA!\n");
        }

        public static void InvalidYearDataMessage()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nPOLE ROK NIE MOŻE BYĆ PUSTE!\n");
        }

        public static void YearsetAlreadySavedMessage()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nDLA PODANEGO ROKU ISTNIEJE JUŻ REKORD!\n");
        }
    }
}
