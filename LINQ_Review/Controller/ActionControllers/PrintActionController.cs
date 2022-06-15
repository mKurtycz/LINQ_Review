using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    internal class PrintActionController : ActionController
    {
        public PrintActionController(List<YearSet> yearSet) : base(yearSet) { }

        public override void RunModule()
        {
            int state = 0;
            do
            {
                PrintActionView.ShowMenu();

                //VALIDATION
                if (Int32.TryParse(Console.ReadLine(), out state) == false || state < 1 || state > 3)
                {
                    MessageView.IncorrectDataMessage();
                }
                else if (state == 3)
                {
                    break;
                }
                else
                {
                    switch (state)
                    {
                        case 1:
                            PrintActionView.PrintAllDataRows(DataSet);
                            break;
                        case 2:
                            SortFiltrAndPrintDataRows();
                            break;
                    }
                }
            }
            while (state != -1);
        }

        private void SortFiltrAndPrintDataRows()
        {
            IEnumerable<YearSet> query = null;
            List<string> filterProperties = new List<string>();
            
            do
            {
                string choice;
                PrintActionView.ShowValueToFilter();
                choice = Console.ReadLine().ToUpper();

                if (choice.Length == 0)
                {
                    MessageView.IncorrectDataMessage();
                }
                else if (choice.Equals("0"))
                {
                    break;
                }
                else if (choice.Equals("1"))
                {
                    if (query == null)
                    {
                        MessageView.NoDataToPrint();
                    }
                    else
                    {
                        PrintActionView.PrintAllDataRows(query.ToList());
                        break;
                    }
                }
                else if (filterProperties.Contains(choice))
                {
                    MessageView.AlreadyUsedFilteringProperty();
                }
                else
                {
                    bool found = false;
                    switch(choice)
                    {
                        case ("ROK"):
                            queryInitializerCheck();
                            found = true;
                            filterProperties.Add(choice);
                            break;

                        case ("CNI"):
                            queryInitializerCheck();
                            found = true;
                            filterProperties.Add(choice);
                            break;

                        case ("RBM"):
                            queryInitializerCheck();
                            found = true;
                            filterProperties.Add(choice);
                            break;

                        case ("ZI"):
                            queryInitializerCheck();
                            found = true;
                            filterProperties.Add(choice);
                            break;

                        case ("PN"):
                            queryInitializerCheck();
                            found = true;
                            filterProperties.Add(choice);
                            break;
                    }

                    if (found == false)
                    {
                        MessageView.IncorrectDataMessage();
                    }
                }

            }
            while (true);

            void queryInitializerCheck()
            {
                if (query == null)
                {
                    query = DataSet;
                }
            }
            
            //pętla z wyborem filtrów, możliwość przerwania
            // CODE
            
            //pytanie o bazę do sortowania i kierunek
            // CODE

            //wyświetlanie wyniku
        }
    }
}
