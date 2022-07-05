using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    public class DeleteActionController : ActionController
    {
        public DeleteActionController(List<Yearset> yearset) : base(yearset) { }

        // Method implementing the mechanism of runnining the deleting module
        public override bool RunModule()
        {
            DeleteActionView.DisplayMenu();
            return changeHasBeenMade;
        }
    }
}
