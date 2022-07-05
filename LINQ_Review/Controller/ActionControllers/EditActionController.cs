using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    public class EditActionController : ActionController
{
        public EditActionController(List<Yearset> yearset) : base(yearset) { }

        // Method implementing the mechanism of runnining the editing module
        public override bool RunModule()
        {
            EditActionView.DisplayMenu();

            return changeHasBeenMade;
        }
    }
}
