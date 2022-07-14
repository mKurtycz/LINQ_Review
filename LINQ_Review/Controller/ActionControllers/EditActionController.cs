using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    public class EditActionController : ActionController
{
        private static int numberOfEditedRows = 0;
        public EditActionController(List<Yearset> yearset) : base(yearset) { }

        // Method implementing the mechanism of runnining the editing module
        public override bool RunModule()
        {
            string choice;
            
            do
            {
                EditActionView.DisplayMenu((numberOfEditedRows == 0) ? "" : " następny");
                choice = Console.ReadLine().ToUpper();

                if (choice.Equals(""))
                {
                    MessageView.InvalidDataMessage();
                }
                else if (choice.Equals("NIE"))
                {
                    break;
                }
                else if (choice.Equals("TAK"))
                {
                    EditYearset();
                }
                else
                {
                    MessageView.InvalidDataMessage();
                }

            }
            while (true);

            if (numberOfEditedRows > 0)
            {
                EditActionView.DisplaySummary(numberOfEditedRows);
                changeHasBeenMade = true;
            }

            return changeHasBeenMade;
        }

        public void EditYearset()
        {
            DisplayActionView.DisplayAllDataRows(Dataset);

            do
            {
                EditActionView.DisplayEditQuery();
                string choice = Console.ReadLine().ToUpper();
                int yearToEditValue;

                if (choice.Equals(""))
                {
                    EditActionView.DisplayEditActionCancelationWasTaken();
                    break;
                }
                else if (Int32.TryParse(choice, out yearToEditValue))
                {
                    if (Dataset.Select(yearset => yearset.Year).Contains(yearToEditValue))
                    {
                        Yearset yearsetToEdit = Dataset.Where(yearset => yearset.Year == yearToEditValue).FirstOrDefault();
                        Yearset previousYearset = yearsetToEdit;
                        bool somethingHasBeenChanged = false;

                        do
                        {
                            EditActionView.DisplayEditPropertyQuery("CNI", yearsetToEdit.CapitalExpendituresPriceIndicator);
                            choice = Console.ReadLine().ToUpper();

                            if (choice.Equals(""))
                            {
                                MessageView.InvalidDataMessage();
                            }
                            else if (choice.Equals("NIE"))
                            {
                                break;
                            }
                            else if (choice.Equals("TAK"))
                            {
                                if (EditCEP(ref yearsetToEdit) == true)
                                {
                                    somethingHasBeenChanged = true;
                                }
                                break;
                            }
                            else
                            {
                                MessageView.InvalidDataMessage();
                            }
                        }
                        while (true);

                        do
                        {
                            EditActionView.DisplayEditPropertyQuery("RBM", yearsetToEdit.ConstructionAssemblyWorksIndicator);
                            choice = Console.ReadLine().ToUpper();

                            if (choice.Equals(""))
                            {
                                MessageView.InvalidDataMessage();
                            }
                            else if (choice.Equals("NIE"))
                            {
                                break;
                            }
                            else if (choice.Equals("TAK"))
                            {
                                if (EditCAW(ref yearsetToEdit) == true)
                                {
                                    somethingHasBeenChanged = true;
                                }
                                break;
                            }
                            else
                            {
                                MessageView.InvalidDataMessage();
                            }
                        }
                        while (true);

                        do
                        {
                            EditActionView.DisplayEditPropertyQuery("ZI", yearsetToEdit.InvestnebtPurchasesIndicator);
                            choice = Console.ReadLine().ToUpper();

                            if (choice.Equals(""))
                            {
                                MessageView.InvalidDataMessage();
                            }
                            else if (choice.Equals("NIE"))
                            {
                                break;
                            }
                            else if (choice.Equals("TAK"))
                            {
                                if (EditIP(ref yearsetToEdit) == true)
                                {
                                    somethingHasBeenChanged = true;
                                }
                                break;
                            }
                            else
                            {
                                MessageView.InvalidDataMessage();
                            }
                        }
                        while (true);

                        do
                        {
                            EditActionView.DisplayEditPropertyQuery("PN", yearsetToEdit.OtherExpendituresIndicator);
                            choice = Console.ReadLine().ToUpper();

                            if (choice.Equals(""))
                            {
                                MessageView.InvalidDataMessage();
                            }
                            else if (choice.Equals("NIE"))
                            {
                                break;
                            }
                            else if (choice.Equals("TAK"))
                            {
                                if (EditOE(ref yearsetToEdit) == true)
                                {
                                    somethingHasBeenChanged = true;
                                }
                                break;
                            }
                            else
                            {
                                MessageView.InvalidDataMessage();
                            }
                        }
                        while (true);

                        if (somethingHasBeenChanged)
                        {
                            Dataset.RemoveAll(x => x.Year == yearToEditValue);

                            Dataset.Add(yearsetToEdit);

                            Dataset = Dataset.OrderBy(yearset => yearset.Year).ToList();

                            numberOfEditedRows++;

                            EditActionView.DisplaySuccessfulEditedIndexInfo(previousYearset, yearsetToEdit);
                        }

                        if (somethingHasBeenChanged)
                        {
                            numberOfEditedRows++;
                        }

                        break;
                    }
                    else
                    {
                        MessageView.NoGivenYearInDataset();
                        continue;
                    }
                }
                else
                {
                    MessageView.InvalidDataMessage();
                }

            }
            while (true);
        }

        public bool EditCEP(ref Yearset yearsetToEdit)
        {
            do
            {
                EditActionView.DisplayIndexValueQuery("CNI");
                string choice = Console.ReadLine().ToUpper();
                double indexToChangeValue;

                Console.WriteLine("jestem przed ifem");
                if (choice.Equals(""))
                {
                    EditActionView.DisplayEditActionCancelationWasTaken();
                    return false;
                }
                else if (Double.TryParse(choice, out indexToChangeValue))
                {
                    if (indexToChangeValue < 0)
                    {
                        MessageView.InvalidScopeMessage();
                        continue;
                    }
                    else
                    {
                        yearsetToEdit.CapitalExpendituresPriceIndicator = indexToChangeValue;
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("błędna wartość robię pętle");
                    MessageView.InvalidDataMessage();
                }
            }
            while (true);
        }

        public bool EditCAW(ref Yearset yearsetToEdit)
        {
            do
            {
                EditActionView.DisplayIndexValueQuery("RBM");
                string choice = Console.ReadLine().ToUpper();
                double indexToChangeValue;

                if (choice.Equals(""))
                {
                    EditActionView.DisplayEditActionCancelationWasTaken();
                    return false;
                }
                else if (Double.TryParse(choice, out indexToChangeValue))
                {
                    if (indexToChangeValue < 0)
                    {
                        MessageView.InvalidScopeMessage();
                        continue;
                    }
                    else
                    {
                        yearsetToEdit.ConstructionAssemblyWorksIndicator = indexToChangeValue;
                        return true;
                    }
                }
                else
                {
                    MessageView.InvalidDataMessage();
                }
            }
            while (true);
        }

        public bool EditIP(ref Yearset yearsetToEdit)
        {
            do
            {
                EditActionView.DisplayIndexValueQuery("ZI");
                string choice = Console.ReadLine().ToUpper();
                double indexToChangeValue;

                if (choice.Equals(""))
                {
                    EditActionView.DisplayEditActionCancelationWasTaken();
                    return false;
                }
                else if (Double.TryParse(choice, out indexToChangeValue))
                {
                    if (indexToChangeValue < 0)
                    {
                        MessageView.InvalidScopeMessage();
                        continue;
                    }
                    else
                    {
                        yearsetToEdit.InvestnebtPurchasesIndicator = indexToChangeValue;
                        return true;
                    }
                }
                else
                {
                    MessageView.InvalidDataMessage();
                }
            }
            while (true);
        }

        public bool EditOE(ref Yearset yearsetToEdit)
        {
            do
            {
                EditActionView.DisplayIndexValueQuery("PN");
                string choice = Console.ReadLine().ToUpper();
                double indexToChangeValue;

                if (choice.Equals(""))
                {
                    EditActionView.DisplayEditActionCancelationWasTaken();
                    return false;
                }
                else if (Double.TryParse(choice, out indexToChangeValue))
                {
                    if (indexToChangeValue < 0)
                    {
                        MessageView.InvalidScopeMessage();
                        continue;
                    }
                    else
                    {
                        yearsetToEdit.OtherExpendituresIndicator = indexToChangeValue;
                        return true;
                    }
                }
                else
                {
                    MessageView.InvalidDataMessage();
                }
            }
            while (true);
        }
    }
}
