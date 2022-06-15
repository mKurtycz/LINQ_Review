using LINQ_Review.Model;

namespace LINQ_Review.View
{
    internal static class PrintActionView
    {
        public static void ShowMenu()
        {
            DashSeparatorView.SeparateWithDashes();
            string menu = "\nMODUŁ - WYŚWIETLANIE INDEKSÓW\n";
            menu += "\nDostęne akcje:";
            menu += "\n1 - Wyświetlanie wszystkich rekordów z pliku";
            menu += "\n2 - Filtrowanie i wyświetlanie danych indeksów";
            menu += "\n3 - Powrót do menu głownego";
            menu += "\n\nWpisz numer akcji i zaakceptuj klawiszem ENTER.\n";
            Console.WriteLine(menu);
            DashSeparatorView.SeparateWithDashes();
        }

        public static void PrintDataLegend()
        {
            string menu = "\nOZNACZENIA STOSOWANE DLA DANYCH:\n";
            menu += "\nCNI - wskaźnik cen nakładów inwestycyjnych,";
            menu += "\nRBM - wskaźnik robót budowlano montażowych,";
            menu += "\nZI - wskaźnik zakupów inwestycyjnych,";
            menu += "\nPN - wskaźnik pozostałych nakładów.\n";

            Console.WriteLine(menu);
        }

        public static void PrintDataLabels()
        {
            string labels = "|\t ROK \t CNI \t RBM \t ZI \t PN \t |";
            Console.WriteLine(labels);
            DashSeparatorView.SeparateWithDashes();
        }

        public static void PrintAllDataRows(List<YearSet> dataSet)
        {
            DashSeparatorView.SeparateWithDashes();
            PrintActionView.PrintDataLegend();
            DashSeparatorView.SeparateWithDashes();
            PrintActionView.PrintDataLabels();
            dataSet.ForEach(dataRow => PrintActionView.PrintDataRow(dataRow));
        }

        private static void PrintDataRow(YearSet yearSetDataRow)
        {
            string yearSetToPrint = $"|\t{yearSetDataRow.Year} \t";
            yearSetToPrint += $"{yearSetDataRow.CapitalExpendituresPriceIndicator} \t";
            yearSetToPrint += $"{yearSetDataRow.ConstructionAssemblyWorksIndicator} \t";
            yearSetToPrint += $"{yearSetDataRow.InvestnebtPurchasesIndicator} \t";
            yearSetToPrint += $"{yearSetDataRow.OtherExpendituresIndicator} \t |";
            Console.WriteLine(yearSetToPrint);
            DashSeparatorView.SeparateWithDashes();
        }

        public static void ShowValueToFilter()
        {
            DashSeparatorView.SeparateWithDashes();
            
            string menu = "\nWpisz nazwę właściwości, według której chcesz przefiltrować dane:\n";
            menu += "\nROK,";
            menu += "\nCNI - wskaźnik cen nakładów inwestycyjnych,";
            menu += "\nRBM - wskaźnik robót budowlano montażowych,";
            menu += "\nZI - wskaźnik zakupów inwestycyjnych,";
            menu += "\nPN - wskaźnik pozostałych nakładów.\n";
            menu += "\nAby przerwać wpisz 0,";
            menu += "\nAby wyświetlić wybrany zestaw danych wpisz 1.\n";
            menu += "\nWybór zatwierdź klawiszem ENTER\n";

            Console.WriteLine(menu);
            DashSeparatorView.SeparateWithDashes();
        }

        public static void ShowAdditionalFiltering()
        {
            Console.WriteLine("Czy chcesz przefiltrować dane według dodatkowej właściwości?");
        }
    }
}
