using LINQ_Review.Model;

namespace LINQ_Review.Controller
{
    abstract internal class ActionController
    {
        public List<Yearset> Dataset { get; private set; }

        public ActionController(List<Yearset> dataset)
        {
            Dataset = dataset;
        }

        // Method implementing the mechanism of runnining the module
        abstract public void RunModule();
    }
}
