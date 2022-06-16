using LINQ_Review.Model;

namespace LINQ_Review.View
{
    internal static class DisplayActionView
    {
        // Displays the main menu of the displaying module
        public static void DisplayMenu()
        {
            DashSeparatorView.SeparateWithDashes();
            string contentToPrint = "\nMODUŁ - WYŚWIETLANIE INDEKSÓW\n";
            contentToPrint += "\nDostęne akcje:";
            contentToPrint += "\n1 - Wyświetlanie wszystkich rekordów z pliku";
            contentToPrint += "\n2 - Filtrowanie i wyświetlanie danych indeksów";
            contentToPrint += "\n3 - Powrót do menu głownego";
            contentToPrint += "\n\nWpisz numer akcji i zaakceptuj klawiszem ENTER.\n";
            Console.WriteLine(contentToPrint);
            DashSeparatorView.SeparateWithDashes();
        }

        // Displays markings of data used in app
        public static void DisplayDataLegend()
        {
            string contentToPrint = "\nOZNACZENIA STOSOWANE DLA DANYCH:\n";
            contentToPrint += "\nCNI - wskaźnik cen nakładów inwestycyjnych,";
            contentToPrint += "\nRBM - wskaźnik robót budowlano montażowych,";
            contentToPrint += "\nZI - wskaźnik zakupów inwestycyjnych,";
            contentToPrint += "\nPN - wskaźnik pozostałych nakładów.\n";

            Console.WriteLine(contentToPrint);
        }

        // Displays data labels, which are used during displaying results
        public static void DisplayDataLabels()
        {
            string contentToPrint = "|\t ROK \t CNI \t RBM \t ZI \t PN \t |";
            Console.WriteLine(contentToPrint);
            DashSeparatorView.SeparateWithDashes();
        }

        // Displays all data rows that are stored in given list
        public static void DisplayAllDataRows(List<Yearset> dataset)
        {
            DashSeparatorView.SeparateWithDashes();
            DisplayDataLegend();
            DashSeparatorView.SeparateWithDashes();
            DisplayDataLabels();
            dataset.ForEach(dataRow => DisplayDataRow(dataRow));
        }

        // Displays a single data row 
        private static void DisplayDataRow(Yearset dataRow)
        {
            string contentToPrint = $"|\t{dataRow.Year} \t";
            contentToPrint += $"{dataRow.CapitalExpendituresPriceIndicator} \t";
            contentToPrint += $"{dataRow.ConstructionAssemblyWorksIndicator} \t";
            contentToPrint += $"{dataRow.InvestnebtPurchasesIndicator} \t";
            contentToPrint += $"{dataRow.OtherExpendituresIndicator} \t |";
            Console.WriteLine(contentToPrint);
            DashSeparatorView.SeparateWithDashes();
        }

        // Displays filtering settings query with data markings 
        public static void DisplayValuesToFilterQuery()
        {
            DashSeparatorView.SeparateWithDashes();
            string contentToPrint = "\nROK";
            contentToPrint += "\nCNI - wskaźnik cen nakładów inwestycyjnych";
            contentToPrint += "\nRBM - wskaźnik robót budowlano montażowych";
            contentToPrint += "\nZI - wskaźnik zakupów inwestycyjnych";
            contentToPrint += "\nPN - wskaźnik pozostałych nakładów\n";
            contentToPrint += "\nWybierz z powyższej listy te właściwości, według któreych chcesz przefiltrować dane,";
            contentToPrint += "\na następnie zatwierdź klawiszem ENTER:\n";
            contentToPrint += "\nAby przerwać nie wpisuj żadnej wartości i zatwierdż klawiszem ENTER,";
            contentToPrint += "\nAby wyświetlić wybrany zestaw danych wpisz 1.\n";

            Console.WriteLine(contentToPrint);
            DashSeparatorView.SeparateWithDashes();
        }

        // Displays a query, which asks user whether data should bounded from below 
        public static void DisplayGreaterThanQuery(string property)
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine($"\nCzy {property} ma być ograniczony z dołu?\n");
            DashSeparatorView.SeparateWithDashes();
        }

        // Displays a query, which asks user whether data should restricted from above 
        public static void DisplayLessThanQuery(string property)
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine($"\nCzy {property} ma być ograniczony z góry?\n");
            DashSeparatorView.SeparateWithDashes();
        }

        // Displays a value query
        public static void DisplayEnterValueQuery()
        {
            DashSeparatorView.SeparateWithDashes();
            Console.WriteLine("\nWprowadź liczbę:\n");
            DashSeparatorView.SeparateWithDashes();
        }
    }
}
