using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    internal class DeleteActionController : ActionController
    {
        public DeleteActionController(List<YearSet> yearSet) : base(yearSet) { }

        public override void RunModule()
        {
            DeleteActionView.ShowMenu();
        }
    }
}
