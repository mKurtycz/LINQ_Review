using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    public class DisplayActionController : ActionController
    {
        public DisplayActionController(List<Yearset> yearset) : base(yearset) { }

        // Method implementing the mechanism of runnining the displaying module
        public override void RunModule()
        {
            int state = 0;
            do
            {
                DisplayActionView.DisplayMenu();

                //VALIDATION
                if (Int32.TryParse(Console.ReadLine(), out state) == false || state < 1 || state > 3)
                {
                    MessageView.InvalidDataMessage();
                }
                else if (state == 3)
                {
                    break;
                }
                else
                {
                    switch (state)
                    {
                        case 1:
                            DisplayActionView.DisplayAllDataRows(Dataset);
                            break;
                        case 2:
                            SortFiltrAndDisplayDataRows();
                            break;
                    }
                }
            }
            while (state != -1);
        }

        // Method implementing the mechanism of filtering, sorting and displaying data
        public void SortFiltrAndDisplayDataRows()
        {
            IEnumerable<Yearset> query = null;
            List<string> filteredProperties = new List<string>();
            
            do
            {
                string filteringChoice;
                
                DisplayActionView.DisplayValuesToFilterQuery();
                filteringChoice = Console.ReadLine().ToUpper();

                if (filteringChoice.Length == 0)
                {
                    break;
                }
                else if (filteringChoice.Equals("1"))
                {
                    if (query == null)
                    {
                        MessageView.NoDataToPrintMessage();
                    }
                    else
                    {
                        DisplayActionView.DisplayAllDataRows(query.ToList());
                        break;
                    }
                }
                else if (filteredProperties.Contains(filteringChoice))
                {
                    MessageView.AlreadyUsedFilteringPropertyMessage();
                }
                else
                {
                    bool foundProperty = false;
                    
                    switch(filteringChoice)
                    {
                        case ("ROK"):
                            foundProperty = true;
                            
                            CheckIfQueryIsInitialized();
                          
                            double? upperBound = GetUpperBoundValue(filteringChoice);
                            
                            if (!(upperBound == null))
                            {
                                query = query.Where(x => x.Year > (int)upperBound);
                                filteredProperties.Add(filteringChoice);
                            }
                            
                            double? lowerBound;

                            do
                            {
                                lowerBound = LessThan(filteringChoice);
                                
                                if (lowerBound == null)
                                {
                                    break;
                                }
                                else if (lowerBound < upperBound)
                                {
                                    MessageView.InvalidScopeMessage();
                                }
                                else
                                {
                                    break;
                                }
                            }
                            while (true);
                            
                            if (!(lowerBound == null))
                            {
                                query = query.Where(x => x.Year < (int)lowerBound);

                                if (!filteredProperties.Contains(filteringChoice))
                                {
                                    filteredProperties.Add(filteringChoice);
                                }
                            }

                            if (!filteredProperties.Contains(filteringChoice))
                            {
                                MessageView.NoFilteringScopeAppliedMessage();
                            }

                            break;

                        case ("CNI"):
                            foundProperty = true;

                            CheckIfQueryIsInitialized();

                            break;

                        case ("RBM"):
                            foundProperty = true;

                            CheckIfQueryIsInitialized();

                            filteredProperties.Add(filteringChoice);
                            break;

                        case ("ZI"):
                            foundProperty = true;
                            
                            CheckIfQueryIsInitialized();

                            filteredProperties.Add(filteringChoice);
                            break;

                        case ("PN"):
                            foundProperty = true;

                            CheckIfQueryIsInitialized();

                            filteredProperties.Add(filteringChoice);
                            break;
                    }

                    if (foundProperty == false)
                    {
                        MessageView.InvalidDataMessage();
                    }
                }

            }
            while (true);

            // Method initializing the query variable when user decides to filter data
            void CheckIfQueryIsInitialized()
            {
                if (query == null)
                {
                    query = Dataset;
                }
            }
        }

        // Method returning value of the upper bound value or returning null if user decided not to set it 
        public double? GetUpperBoundValue(string property)
        {
            string choice;
            do
            {
                DisplayActionView.DisplayGreaterThanQuery(property);
                choice = Console.ReadLine().ToUpper();
                if (choice.Length == 0)
                {
                    MessageView.InvalidDataMessage();
                }
                else if (choice.Equals("NIE"))
                {
                    return null;
                }
                else if (choice.Equals("TAK"))
                {
                    double? upperBoundValue = null;

                    upperBoundValue = TakeValue();

                    if (upperBoundValue == null)
                    {
                        MessageView.NoGivenDataMessage();
                    }

                    return upperBoundValue;

                }
                else
                {
                    MessageView.InvalidDataMessage();
                }

            }
            while (true);

        }

        // Method returning value of the lower bound value or returning null if user decided not to set it 
        public double? LessThan(string property)
        {
            string choice;
            do
            {
                DisplayActionView.DisplayLessThanQuery(property);
                choice = Console.ReadLine().ToUpper();
                if (choice.Length == 0)
                {
                    MessageView.InvalidDataMessage();
                }
                else if (choice.Equals("NIE"))
                {
                    return null;
                }
                else if (choice.Equals("TAK"))
                {
                    double? lowerBoundValue = null;

                    lowerBoundValue = TakeValue();

                    if (lowerBoundValue == null)
                    {
                        MessageView.NoGivenDataMessage();
                    }

                    return lowerBoundValue;

                }
                else
                {
                    MessageView.InvalidDataMessage();
                }

            }
            while (true);

        }

        // Method retriving and validating a value of bound from user
        public double? TakeValue()
        {
            string choice;
            do
            {
                double value;
                DisplayActionView.DisplayEnterValueQuery();
                choice = Console.ReadLine().ToUpper();
                if (choice.Length == 0)
                {
                    return null;
                }
                else if (Double.TryParse(choice, out value))
                {
                    return value;
                }
                else
                {
                    MessageView.InvalidDataMessage();
                }
            }
            while (true);
        }
    }
}
