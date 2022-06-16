namespace LINQ_Review.View
{
    internal static class EditActionView
    {
        // Displays the main menu of the editing module
        public static void DisplayMenu()
        {
            DashSeparatorView.SeparateWithDashes();
            string menu = "\nMODUŁ - EDYTOWANIE INDEKSÓW\n";
            menu += "\n";
            Console.WriteLine(menu);
            DashSeparatorView.SeparateWithDashes();
        }
    }
}
