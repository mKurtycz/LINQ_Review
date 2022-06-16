namespace LINQ_Review.View
{
    internal static class AddActionView
    {
        // Displays the main menu of the adding module
        public static void DisplayMenu()
        {
            DashSeparatorView.SeparateWithDashes();
            string menu = "\nMODUŁ - DODAWANIE INDEKSÓW\n";
            menu += "\n";
            Console.WriteLine(menu);
            DashSeparatorView.SeparateWithDashes();
        }
    }
}
