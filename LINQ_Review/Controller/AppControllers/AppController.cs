using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    public class AppController
    {
        // Controller that handles with dataset changes 
        private DataManipulationController? internalDataManipulationControler;

        // Controller that handles with running given actions
        private ActionController? actionControler;

        // List that stores data from csv file
        private List<Yearset>? dataset;

        public AppController() { }

        // Method implementing the mechanism of runnining the app
        public void RunApp()
        {
            AppView.Run();

            // Auxiliary variables
            
            // Stores values that correspond to individual actions
            int state = 0;

            // Stores an information whether the dataset has been changed
            bool changeHasBeenMade = false;

            do
            {
                MenuView.DisplayMainMenu();

                // Validating data read from user
                if (Int32.TryParse(Console.ReadLine(), out state) == false || state < 1 || state > 5)
                {
                    MessageView.InvalidDataMessage();
                }
                // If user presses "5" + ENTER it breaks the loop and moves on to saving possible changes and closes the app
                else if (state == 5)
                {
                    break;
                }
                else
                {
                    // Only when user presses "1"-"4" + ENTER the app reads data from a csv file
                    if (dataset == null)
                    {
                        internalDataManipulationControler = new DataManipulationController();
                        dataset = internalDataManipulationControler.LoadData();
                    }

                    changeHasBeenMade = ReturnProperActionController(state, dataset).RunModule();
                }
            }
            while (state != -1);

            //Only when there appeared changes in the dataset app saves them to csv
            if (changeHasBeenMade == true)
            {
                internalDataManipulationControler.SaveChanges(dataset);
            }

            AppView.ShutDown();
        }

        public ActionController ReturnProperActionController(int state, List<Yearset> dataset) => state switch
        {
            1 => new DisplayActionController(dataset),
            2 => new AddActionController(dataset),
            3 => new EditActionController(dataset),
            4 => new DeleteActionController(dataset),
        };
    }
}