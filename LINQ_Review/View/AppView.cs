namespace LINQ_Review.View
{
    internal static class AppView
    {
        // Displays an initial message 
        public static void Run()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nAPLIKACJA DO PRACY ZE WSKAŹNIKAMI\n");
        }

        // Displays a thank-you message 
        public static void ShutDown()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nDZIĘKUJEMY ZA SKORZYSTANIE Z APLIKACJI!\n");
            DashSeparatorView.SeparateWithDashes();
        }
    }
}
