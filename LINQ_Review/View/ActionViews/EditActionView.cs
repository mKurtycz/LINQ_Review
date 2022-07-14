using LINQ_Review.Model;

namespace LINQ_Review.View
{
    internal static class EditActionView
    {
        // Displays the main menu of the editing module
        public static void DisplayMenu(string repetition)
        {
            DashSeparatorView.SeparateWithDashes();
            string menu = "\nMODUŁ - EDYTOWANIE INDEKSÓW\n";
            menu += $"\nCzy chcesz zedytować{repetition} rekord ?\n";
            Console.WriteLine(menu);
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplaySummary(int numberOfEditeddRows)
        {
            string properForm = "";

            switch (numberOfEditeddRows)
            {
                case > 5 and < 22:
                case int number when number % 100 == 0:
                    properForm = "rekordów";
                    break;

                case 1:
                    properForm = "rekord";
                    break;

                case int number when (number % 10) is 2 or 3 or 4:
                    properForm = "rekordy";
                    break;
            }

            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine($"\nPomyślnie zedytowano {numberOfEditeddRows} {properForm} z listy rekordów!\n");
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplayEditQuery()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nZ powyższych wybierz zestaw, który chcesz zedytować, wpisz rok wybranego zestawu i wciśnij ENTER\n");
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplayEditActionCancelationWasTaken()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nAnulowano akcję edytowania rekordu!\n");
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplayEditPropertyQuery(string propertyName, double propertyValue)
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine($"\nDla wybranego roku wartość {propertyName} jest równa - {propertyValue}.\nCzy chcesz ją zmienić?\n");
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplayIndexValueQuery(string property)
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine($"\nWprowadź nową wartość dla {property}:\n");
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplaySuccessfulEditedIndexInfo(Yearset previousYearset, Yearset editedYearset)
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nPomyślnie zedytowano zestaw wskaźników!\n");
            Console.WriteLine("\nPOPRZEDNIE WARTOŚCI:\n");
            DisplayActionView.DisplayDataLabels();
            DisplayActionView.DisplayDataRow(previousYearset);
            Console.WriteLine("\nNOWE WARTOŚCI WARTOŚCI:\n");
            DisplayActionView.DisplayDataLabels();
            DisplayActionView.DisplayDataRow(editedYearset);
            DashSeparatorView.SeparateWithDashes();
        }
    }
}