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
                        bool somethingHasBeenChanged = false;

                        // CNI
                        EditActionView.DisplayEditPropertyQuery("CNI", yearsetToEdit.CapitalExpendituresPriceIndicator);
                        do
                        {
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
                                if (EditCNI(ref yearsetToEdit) == true)
                                {
                                    somethingHasBeenChanged = true;
                                }

                                //other indices to be implemented

                                //RBM - CAW


                                //ZI - IP


                                //PN - OE


                                if (somethingHasBeenChanged)
                                {
                                    Dataset.RemoveAll(x => x.Year == yearToEditValue);

                                    Dataset.Add(yearsetToEdit);
                                   
                                    Dataset = Dataset.OrderBy(yearset => yearset.Year).ToList();
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

        public bool EditCNI(ref Yearset yearsetToEdit)
        {
            do
            {
                EditActionView.DisplayIndexValueQuery("CNI");
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
                        yearsetToEdit.CapitalExpendituresPriceIndicator = indexToChangeValue;
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

        public bool EditRBM()
        {
            return false;
        }

        public bool EditZI()
        {
            return false;
        }

        public bool EditPN()
        {
            return false;
        }
    }
}
