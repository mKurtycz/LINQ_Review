using LINQ_Review.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Review.Controller
{
    internal class PrintActionController : IActionController
    {
        public void RunModule()
        {
            PrintActionView.ShowMenu();
        }
    }
}
