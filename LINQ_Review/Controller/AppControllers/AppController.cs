using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    internal class AppController
    {
        private DataManipulationController? internalDataManipulationControler;
        private ActionController? actionControler;
        private List<YearSet>? dataSet;

        public AppController() { }

        public void RunApp()
        {
            AppView.Run();
            int state = 0;
            bool changeHasBeenMade = false;

            do
            {
                MenuView.ShowMenu();

                //VALIDATION
                if (Int32.TryParse(Console.ReadLine(), out state) == false || state < 1 || state > 5)
                {
                    MessageView.IncorrectDataMessage();
                }
                else if (state == 5)
                {
                    state = -1;
                }
                else {
                    if (dataSet == null)
                    {
                        Console.WriteLine("wykonuje");
                        internalDataManipulationControler = new DataManipulationController();
                        dataSet = internalDataManipulationControler.LoadData();
                    }

                    switch (state)
                    {
                        case 1:
                            actionControler = new PrintActionController(dataSet);
                            actionControler.RunModule();
                            break;
                        case 2:
                            actionControler = new AddActionController(dataSet);
                            actionControler.RunModule();
                            break;
                        case 3:
                            actionControler = new EditActionController(dataSet);
                            actionControler.RunModule();
                            break;
                        case 4:
                            actionControler = new DeleteActionController(dataSet);
                            actionControler.RunModule();
                            break;
                    }
                }
            }
            while (state != -1);

            if (changeHasBeenMade == true)
            {
                internalDataManipulationControler.SaveChanges();
            }

            AppView.ShutDown();
            
        }
    }
}
