namespace LINQ_Review.View
{
    internal static class MenuView
    {
        // Displays the main menu of the app
        public static void DisplayMainMenu()
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
