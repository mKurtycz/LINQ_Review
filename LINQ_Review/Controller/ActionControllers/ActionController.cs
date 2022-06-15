using LINQ_Review.Model;

namespace LINQ_Review.Controller
{
    abstract internal class ActionController
    {
        public List<YearSet> DataSet { get; private set; }

        public ActionController(List<YearSet> dataSet)
        {
            DataSet = dataSet;
        }

        abstract public void RunModule();
    }
}
