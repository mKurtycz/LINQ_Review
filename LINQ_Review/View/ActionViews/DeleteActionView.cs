namespace LINQ_Review.View
{
    internal static class DeleteActionView
    {
        // Displays the main menu of the deleting module
        public static void DisplayMenu()
        {
            DashSeparatorView.SeparateWithDashes();
            string menu = "\nMODUŁ - USUWANIE INDEKSÓW\n";
            menu += "\n";
            Console.WriteLine(menu);
            DashSeparatorView.SeparateWithDashes();
        }
    }
}
