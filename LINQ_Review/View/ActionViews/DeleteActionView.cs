namespace LINQ_Review.View
{
    internal static class DeleteActionView
    {
        // Displays the main menu of the deleting module
        public static void DisplayMenu(string repetition)
        {
            DashSeparatorView.SeparateWithDashes();
            string menu = "\nMODUŁ - USUWANIE INDEKSÓW\n";
            menu += $"\nCzy chcesz usunąć{repetition} rekord?\n";
            Console.WriteLine(menu);
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplaySummary(int numberOfDeletedRows)
        {
            string properForm = "";

            switch (numberOfDeletedRows)
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
            Console.WriteLine($"\nPomyślnie usunięto {numberOfDeletedRows} {properForm} z listy rekordów!\n");
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplayDeleteQuery()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nZ powyższych wybierz zestaw, który chcesz usunąć, wpisz rok wybranego zestawu i wciśnij ENTER\n");
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplayDeleteActionCancelationWasTaken()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nAnulowano akcję usuwania rekordu!\n");
            DashSeparatorView.SeparateWithDashes();
        }

        public static void DisplaySuccessfulDeletionSummary(int yearToDeleteValue)
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine($"\nPomyślnie usunięto zestaw indeksów dla roku: {yearToDeleteValue}!\n");
            DashSeparatorView.SeparateWithDashes();
        }
    }
}
