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
                        Console.WriteLine(query.GetType());
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
                            double? greaterVaule = GreaterThan(choice);
                            if (!(greaterVaule == null))
                            {
                                query = query.Where(x => x.Year > (int)greaterVaule);
                                found = true;
                                filterProperties.Add(choice);
                            }
                            
                            double? lessValue;
                            do
                            {
                                lessValue = LessThan(choice);
                                if (lessValue == null)
                                {
                                    break;
                                }
                                else if (lessValue < greaterVaule)
                                {
                                    MessageView.IncorrectScope();
                                }
                                else
                                {
                                    break;
                                }
                            }
                            while (true);
                            
                            if (!(lessValue == null))
                            {
                                query = query.Where(x => x.Year < (int)lessValue);

                                found = (found == false) ? true : false;
                                if (!filterProperties.Contains(choice))
                                {
                                    filterProperties.Add(choice);
                                }
                            }

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

            double? GreaterThan(string property)
            {
                string choice;
                do
                {
                    PrintActionView.GreaterThanQuery(property);
                    choice = Console.ReadLine().ToUpper();
                    if (choice.Length == 0)
                    {
                        MessageView.IncorrectDataMessage();
                    }
                    else if (choice.Equals("NIE"))
                    {
                        return null;
                    }
                    else if (choice.Equals("TAK"))
                    {
                        double? greaterThanValue = null;

                        greaterThanValue = TakeValue();
                        
                        if (greaterThanValue == null)
                        {
                            MessageView.NoGivenData();
                        }

                        return greaterThanValue;

                    }
                    else
                    {
                        MessageView.IncorrectDataMessage();
                    }

                }
                while (true);

            }

            double? LessThan(string property)
            {
                string choice;
                do
                {
                    PrintActionView.LessThanQuery(property);
                    choice = Console.ReadLine().ToUpper();
                    if (choice.Length == 0)
                    {
                        MessageView.IncorrectDataMessage();
                    }
                    else if (choice.Equals("NIE"))
                    {
                        return null;
                    }
                    else if (choice.Equals("TAK"))
                    {
                        double? lessThanValue = null;

                        lessThanValue = TakeValue();

                        if (lessThanValue == null)
                        {
                            MessageView.NoGivenData();
                        }

                        return lessThanValue;

                    }
                    else
                    {
                        MessageView.IncorrectDataMessage();
                    }

                }
                while (true);

            }

            double? TakeValue()
            {
                string choice;
                do
                {
                    double value;
                    PrintActionView.EnterValue();
                    choice = Console.ReadLine().ToUpper();
                    if (choice.Length == 0)
                    {
                        return null;
                    }
                    else if (Double.TryParse(choice, out value))
                    {
                        return value;
                    }
                    else
                    {
                        MessageView.IncorrectDataMessage();
                    }
                }
                while (true);
            }
            //pętla z wyborem filtrów, możliwość przerwania
            // CODE
            
            //pytanie o bazę do sortowania i kierunek
            // CODE

            //wyświetlanie wyniku
        }
    }
}
