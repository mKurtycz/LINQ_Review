using LINQ_Review.Model;
using LINQ_Review.View;

namespace LINQ_Review.Controller
{
    public class DisplayActionController : ActionController
    {
        public DisplayActionController(List<Yearset> yearset) : base(yearset) { }

        // Method implementing the mechanism of runnining the displaying module
        public override bool RunModule()
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

            return changeHasBeenMade;
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
                    double? upperBound, lowerBound;

                    switch (filteringChoice)
                    {
                        case ("ROK"):
                            foundProperty = true;
                            
                            CheckIfQueryIsInitialized();


                            upperBound = GetUpperBoundValue(filteringChoice);
                            
                            if (!(upperBound == null))
                            {
                                query = query.Where(yearset => yearset.Year > (int)upperBound);
                                filteredProperties.Add(filteringChoice);
                            }
                            

                            CheckAndSetLowerBoundValue(upperBound, filteringChoice, out lowerBound);


                            if (!(lowerBound == null))
                            {
                                query = query.Where(yearset => yearset.Year < (int)lowerBound);

                                if (!filteredProperties.Contains(filteringChoice))
                                {
                                    filteredProperties.Add(filteringChoice);
                                }
                            }

                            if (!filteredProperties.Contains(filteringChoice))
                            {
                                MessageView.NoFilteringScopeAppliedMessage();
                            }
                            else if (GetDecision(filteringChoice) == 1)
                            {
                                query = query.OrderByDescending(yearset => yearset.Year);
                            }

                            break;

                        case ("CNI"):
                            foundProperty = true;

                            CheckIfQueryIsInitialized();

                            upperBound = GetUpperBoundValue(filteringChoice);

                            if (!(upperBound == null))
                            {
                                query = query.Where(yearset => yearset.CapitalExpendituresPriceIndicator > upperBound);
                                filteredProperties.Add(filteringChoice);
                            }

                            CheckAndSetLowerBoundValue(upperBound, filteringChoice, out lowerBound);


                            if (!(lowerBound == null))
                            {
                                query = query.Where(yearset => yearset.CapitalExpendituresPriceIndicator < lowerBound);

                                if (!filteredProperties.Contains(filteringChoice))
                                {
                                    filteredProperties.Add(filteringChoice);
                                }
                            }

                            if (!filteredProperties.Contains(filteringChoice))
                            {
                                MessageView.NoFilteringScopeAppliedMessage();
                            }
                            else if (GetDecision(filteringChoice) == 1)
                            {
                                query = query.OrderByDescending(yearset => yearset.CapitalExpendituresPriceIndicator);
                            }

                            break;

                        case ("RBM"):
                            foundProperty = true;

                            CheckIfQueryIsInitialized();

                            upperBound = GetUpperBoundValue(filteringChoice);

                            if (!(upperBound == null))
                            {
                                query = query.Where(yearset => yearset.ConstructionAssemblyWorksIndicator > upperBound);
                                filteredProperties.Add(filteringChoice);
                            }

                            CheckAndSetLowerBoundValue(upperBound, filteringChoice, out lowerBound);


                            if (!(lowerBound == null))
                            {
                                query = query.Where(yearset => yearset.ConstructionAssemblyWorksIndicator < lowerBound);

                                if (!filteredProperties.Contains(filteringChoice))
                                {
                                    filteredProperties.Add(filteringChoice);
                                }
                            }

                            if (!filteredProperties.Contains(filteringChoice))
                            {
                                MessageView.NoFilteringScopeAppliedMessage();
                            }
                            else if (GetDecision(filteringChoice) == 1)
                            {
                                query = query.OrderByDescending(yearset => yearset.ConstructionAssemblyWorksIndicator);
                            }

                            break;

                        case ("ZI"):
                            foundProperty = true;

                            CheckIfQueryIsInitialized();

                            upperBound = GetUpperBoundValue(filteringChoice);

                            if (!(upperBound == null))
                            {
                                query = query.Where(yearset => yearset.InvestnebtPurchasesIndicator > upperBound);
                                filteredProperties.Add(filteringChoice);
                            }

                            CheckAndSetLowerBoundValue(upperBound, filteringChoice, out lowerBound);


                            if (!(lowerBound == null))
                            {
                                query = query.Where(yearset => yearset.InvestnebtPurchasesIndicator < lowerBound);

                                if (!filteredProperties.Contains(filteringChoice))
                                {
                                    filteredProperties.Add(filteringChoice);
                                }
                            }

                            if (!filteredProperties.Contains(filteringChoice))
                            {
                                MessageView.NoFilteringScopeAppliedMessage();
                            }
                            else if (GetDecision(filteringChoice) == 1)
                            {
                                query = query.OrderByDescending(yearset => yearset.InvestnebtPurchasesIndicator);
                            }

                            break;

                        case ("PN"):
                            foundProperty = true;

                            CheckIfQueryIsInitialized();

                            upperBound = GetUpperBoundValue(filteringChoice);

                            if (!(upperBound == null))
                            {
                                query = query.Where(yearset => yearset.OtherExpendituresIndicator > upperBound);
                                filteredProperties.Add(filteringChoice);
                            }

                            CheckAndSetLowerBoundValue(upperBound, filteringChoice, out lowerBound);


                            if (!(lowerBound == null))
                            {
                                query = query.Where(yearset => yearset.OtherExpendituresIndicator < lowerBound);

                                if (!filteredProperties.Contains(filteringChoice))
                                {
                                    filteredProperties.Add(filteringChoice);
                                }
                            }

                            if (!filteredProperties.Contains(filteringChoice))
                            {
                                MessageView.NoFilteringScopeAppliedMessage();
                            }
                            else if (GetDecision(filteringChoice) == 1)
                            {
                                query = query.OrderByDescending(yearset => yearset.OtherExpendituresIndicator);
                            }

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

                    upperBoundValue = GetValue();

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

                    lowerBoundValue = GetValue();

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
        public double? GetValue()
        {
            do
            {
                double value;
                DisplayActionView.DisplayEnterValueQuery();
                string choice = Console.ReadLine().ToUpper();
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

        // Method checking whether lower bound is lower than upper bound, if so it sets this bound
        public void CheckAndSetLowerBoundValue(double? upperBound, string filteringChoice, out double? lowerBound)
        {
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
        }

        // Method retriving, validating a string and returning 0 if it equals "NIE", 1 if it equals "TAK"
        public int GetDecision(string filteringChoice)
        {
            string descendingSorting;

            do
            {
                DisplayActionView.DisplaySortingOptionQuery(filteringChoice);
                descendingSorting = Console.ReadLine().ToUpper();

                if (descendingSorting.Length == 0)
                {
                    MessageView.InvalidDataMessage();
                }
                else if (descendingSorting.Equals("NIE"))
                {
                    return 0;
                }
                else if (descendingSorting.Equals("TAK"))
                {
                    return 1;
                }
            }
            while (true);
        }
    }
}
