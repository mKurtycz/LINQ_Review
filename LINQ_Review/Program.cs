using LINQ_Review.Controller;
using LINQ_Review.Model;

namespace LINQ_Review
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AppController appControler = new AppController();
                appControler.RunApp();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
