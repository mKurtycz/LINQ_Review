using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    internal class AddActionController : ActionController
    {
        public AddActionController(List<YearSet> yearSet) : base (yearSet) { }

        public override void RunModule()
        {
            AddActionView.ShowMenu();
        }
    }
}
