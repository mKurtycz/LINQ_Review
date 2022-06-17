using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    public class AddActionController : ActionController
    {
        public AddActionController(List<Yearset> yearset) : base (yearset) { }

        // Method implementing the mechanism of runnining the adding module
        public override void RunModule()
        {
            AddActionView.DisplayMenu();
        }
    }
}
