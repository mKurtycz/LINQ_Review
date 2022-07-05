using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    public class AddActionController : ActionController
    {
        public AddActionController(List<Yearset> yearset) : base (yearset) { }

        // Method implementing the mechanism of runnining the adding module
        public override bool RunModule()
        {
            string choice;
            
            do
            {
                AddActionView.DisplayMenu();
                choice = Console.ReadLine().ToUpper();

                if (choice.Equals(""))
                {
                    MessageView.InvalidDataMessage();
                }
                else if (choice.Equals("NIE"))
                {
                    break;
                }
                else if (choice.Equals("TAK"))
                {
                    AddYearset();
                }
                else
                {
                    MessageView.InvalidDataMessage();
                }

            }
            while (true);

            return changeHasBeenMade;
        }

        public void AddYearset()
        { 
            int yearValue = -1;
            
            do
            {
                AddActionView.DisplayYearQuery();
                string properetyStringValue = Console.ReadLine();

                if (properetyStringValue.Equals(""))
                {
                    MessageView.InvalidYearDataMessage();
                    break;
                }
                
                if (Int32.TryParse(properetyStringValue, out yearValue))
                {
                    if (yearValue < 1900)
                    {
                        MessageView.InvalidDataMessage();
                        continue;
                    }
                    else if (Dataset.Select(x => x.Year).Contains(yearValue))
                    {
                        MessageView.YearsetAlreadySavedMessage();
                        continue;
                    }

                    break;
                }
                else
                {
                    MessageView.InvalidDataMessage();
                }
                
            }
            while (true);

            if (yearValue!=-1)
            {
                double CEPValue = -1;
                double CAWValue = -1;
                double IPValue = -1;
                double OEValue = -1;

                do
                {
                    AddActionView.DisplayIndexValueQuery("CNI");
                    string CEPStringValue = Console.ReadLine();

                    if (CEPStringValue.Equals(""))
                    {
                        CEPValue = 0;
                        AddActionView.DisplayIndexValueSetDefault("CNI");
                        break;
                    }

                    if (Double.TryParse(CEPStringValue, out CEPValue))
                    {
                        if (CEPValue < 0)
                        {
                            MessageView.InvalidDataMessage();
                            continue;
                        }

                        break;
                    }
                    else
                    {
                        MessageView.InvalidDataMessage();
                    }
                }
                while (true);

                do
                {
                    AddActionView.DisplayIndexValueQuery("RBM");
                    string CAWStringValue = Console.ReadLine();

                    if (CAWStringValue.Equals(""))
                    {
                        CAWValue = 0;
                        AddActionView.DisplayIndexValueSetDefault("RBM");
                        break;
                    }

                    if (Double.TryParse(CAWStringValue, out CAWValue))
                    {
                        if (CAWValue < 0)
                        {
                            MessageView.InvalidDataMessage();
                            continue;
                        }

                        break;
                    }
                    else
                    {
                        MessageView.InvalidDataMessage();
                    }
                }
                while (true);

                do
                {
                    AddActionView.DisplayIndexValueQuery("ZI");
                    string IPStringValue = Console.ReadLine();

                    if (IPStringValue.Equals(""))
                    {
                        IPValue = 0;
                        AddActionView.DisplayIndexValueSetDefault("ZI");
                        break;
                    }

                    if (Double.TryParse(IPStringValue, out IPValue))
                    {
                        if (IPValue < 0)
                        {
                            MessageView.InvalidDataMessage();
                            continue;
                        }

                        break;
                    }
                    else
                    {
                        MessageView.InvalidDataMessage();
                    }
                }
                while (true);

                do
                {
                    AddActionView.DisplayIndexValueQuery("PN");
                    string OEStringValue = Console.ReadLine();

                    if (OEStringValue.Equals(""))
                    {
                        OEValue = 0;
                        AddActionView.DisplayIndexValueSetDefault("PN");
                        break;
                    }

                    if (Double.TryParse(OEStringValue, out OEValue))
                    {
                        if (OEValue < 0)
                        {
                            MessageView.InvalidDataMessage();
                            continue;
                        }

                        break;
                    }
                    else
                    {
                        MessageView.InvalidDataMessage();
                    }
                }
                while (true);

                AddActionView.DisplayNewYearSet(yearValue, CEPValue, CAWValue, IPValue, OEValue);
                
                Dataset.Add(new Yearset(yearValue, CEPValue, CAWValue, IPValue, OEValue));
                changeHasBeenMade = true;
                AddActionView.DisplaySuccessfulInfo();
            }
        }
    }
}
