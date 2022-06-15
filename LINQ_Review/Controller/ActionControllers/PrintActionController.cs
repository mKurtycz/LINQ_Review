using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    internal class PrintActionController : ActionController
    {
        public PrintActionController(List<YearSet> yearSet) : base(yearSet) { }

        public override void RunModule()
        {
            PrintActionView.ShowMenu();
        }
    }
}
