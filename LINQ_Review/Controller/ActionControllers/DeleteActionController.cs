using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    public class DeleteActionController : ActionController
    {
        private static int numberOfDeletedRows = 0;
        public DeleteActionController(List<Yearset> yearset) : base(yearset) { }

        // Method implementing the mechanism of runnining the deleting module
        public override bool RunModule()
        {
            string choice;

            do
            {
                DeleteActionView.DisplayMenu((numberOfDeletedRows == 0)? "" : " następny");
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
                    DeleteYearset();
                }
                else
                {
                    MessageView.InvalidDataMessage();
                }

            }
            while (true);

            if (numberOfDeletedRows > 0)
            {
                DeleteActionView.DisplaySummary(numberOfDeletedRows);
                changeHasBeenMade = true;
            }

            return changeHasBeenMade;
        }

        public void DeleteYearset()
        {
            DisplayActionView.DisplayAllDataRows(Dataset);

            do
            {
                DeleteActionView.DisplayDeleteQuery();
                string choice = Console.ReadLine().ToUpper();
                int yearToDeleteValue;

                if (choice.Equals(""))
                {
                    DeleteActionView.DisplayDeleteActionCancelationWasTaken();
                    break;
                }
                else if (Int32.TryParse(choice, out yearToDeleteValue)) 
                {
                    if (Dataset.Select(yearset => yearset.Year).Contains(yearToDeleteValue))
                    {
                        Dataset.RemoveAll(x => x.Year == yearToDeleteValue);
                        numberOfDeletedRows++;

                        DeleteActionView.DisplaySuccessfulDeletionSummary(yearToDeleteValue);
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
    }
}
