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
        public void RunApp()
        {
            int state = 0;
            AppView.Run();

            do
            {
                MenuView.ShowMenu();
                
                //VALIDATION
                if (Int32.TryParse(Console.ReadLine(), out state)==false || state < 1 || state > 5)
                {
                    MessageView.IncorrectDataMessage();
                }
                else
                {
                    switch(state)
                    {
                        case 1:
                            PrintAction();
                            break;
                        case 2:
                            AddAction();
                            break;
                        case 3:
                            EditAction();
                            break;
                        case 4:
                            DeleteAction();
                            break;
                        case 5:
                            state = -1;
                            break;
                    }
                }
            }
            while (state != -1);

            AppView.ShutDown();
        }

        private void AddAction()
        {
            AddActionView.ShowMenu();
        }

        private void DeleteAction()
        {
            DeleteActionView.ShowMenu();
        }

        private void EditAction()
        {
            EditActionView.ShowMenu();
        }

        private void PrintAction()
        {
            PrintActionView.ShowMenu();
        }
    }
}
