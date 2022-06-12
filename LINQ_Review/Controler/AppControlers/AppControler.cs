using LINQ_Review.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Review.Controler
{
    internal class AppControler
    {
        private DataManipulationControler internalDataManipulationControler;
        private IActionControler actionControler;

        public AppControler()
        {
            try
            {
                internalDataManipulationControler = new DataManipulationControler();
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
                            actionControler = new PrintActionControler();
                            actionControler.RunModule();
                            break;
                        case 2:
                            actionControler = new AddActionControler();
                            actionControler.RunModule();
                            break;
                        case 3:
                            actionControler = new EditActionControler();
                            actionControler.RunModule();
                            break;
                        case 4:
                            actionControler = new DeleteActionControler();
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
