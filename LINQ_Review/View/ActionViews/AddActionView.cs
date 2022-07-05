namespace LINQ_Review.View
{
    internal static class AddActionView
    {
        public static void DisplayMenu()
        {
            DashSeparatorView.SeparateWithDashes();
            string menu = "\nMODUŁ - DODAWANIE INDEKSÓW\n";
            menu += "\nCzy chcesz dodać nowy rekord?\n";
            Console.WriteLine(menu);
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplayInfo()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nPOZOSTAWIENIE PUSTEGO POLA DLA WSKAŹNIKÓW JEST RÓWNOZNACZNE Z PRZYPISANIEM IM WARTOŚCI 0!\n");
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplayYearQuery()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nWprowadź rok:\n");
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplayIndexValueQuery(string property)
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine($"\nWprowadź wartość dla {property}:\n");
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplayIndexValueSetDefault(string property)
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine($"\nUstawiono wartość domyślną 0 dla {property}\n");
        }

        public static void DisplayNewYearSet(int yearValue, double CEPValue, double CAWValue, double IPValue, double OEValue)
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nDo bazy danych zostanie dodany poniższy rekord rekord:\n");
            Console.WriteLine($"\nROK:{yearValue}; CNI:{CEPValue}; RBM:{CAWValue}; ZI:{IPValue}; PN:{OEValue};\n");
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplaySuccessfulInfo()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nPomyślnie dodano rekord do bazy!\n");
            DashSeparatorView.SeparateWithDashes();
        }
    }
}
