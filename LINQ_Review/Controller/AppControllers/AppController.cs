using LINQ_Review.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Review.Controller
{
    internal class AppController
    {
        private DataManipulationController internalDataManipulationControler;
        private IActionController actionControler;

        public AppController()
        {
            try
            {
                internalDataManipulationControler = new DataManipulationController();
            }
            catch
            {
                throw;
            }
        }

        public void RunApp()
        {
            AppView.Run();
            int state = 0;

            do
            {
                MenuView.ShowMenu();

                //VALIDATION
                if (Int32.TryParse(Console.ReadLine(), out state) == false || state < 1 || state > 5)
                {
                    MessageView.IncorrectDataMessage();
                }
                else
                {
                    switch (state)
                    {
                        case 1:
                            actionControler = new PrintActionController();
                            actionControler.RunModule();
                            break;
                        case 2:
                            actionControler = new AddActionController();
                            actionControler.RunModule();
                            break;
                        case 3:
                            actionControler = new EditActionController();
                            actionControler.RunModule();
                            break;
                        case 4:
                            actionControler = new DeleteActionController();
                            actionControler.RunModule();
                            break;
                        case 5:
                            state = -1;
                            break;
                    }
                }
            }
            while (state != -1);
        }
    }
}
