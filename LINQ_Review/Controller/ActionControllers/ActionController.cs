using LINQ_Review.Model;

namespace LINQ_Review.Controller
{
    abstract public class ActionController
    {
        protected List<Yearset> Dataset { get; set; }
        protected static bool changeHasBeenMade = false;

        public ActionController(List<Yearset> dataset)
        {
            Dataset = dataset;
        }

        // Method implementing the mechanism of runnining the module
        abstract public bool RunModule();
    }
}
