using LINQ_Review.Model;
using LINQ_Review.Exceptions;
using System.Text;

namespace LINQ_Review.Controller
{
    internal class DataManipulationController
    {
        private string dataSetPath = "DataSet.csv";
        List<string>? headers;

        public DataManipulationController() { }

        public List<YearSet> LoadData()
        {
            try
            {
                headers = File.ReadLines(dataSetPath, Encoding.GetEncoding("utf-8")).Take(2).ToList();
                return File.ReadLines(dataSetPath).Skip(2).Select(line => StringToYearSet(line)).ToList();
            }
            catch
            {
                throw;
            }
        }

        private YearSet StringToYearSet(string stringLine)
        {
            string[] dataFromString = new string[5];
            stringLine.Split(";")[0..5].CopyTo(dataFromString, 0);

            return new YearSet(CheckAndReturnYear(dataFromString[0]),
                                CheckAndReturnIndex(dataFromString[1]),
                                CheckAndReturnIndex(dataFromString[2]),
                                CheckAndReturnIndex(dataFromString[3]),
                                CheckAndReturnIndex(dataFromString[4]));
        }

        private string YearSetToString(YearSet YearSetDataRow)
        {
            return $"{YearSetDataRow.Year};{YearSetDataRow.CapitalExpendituresPriceIndicator};" +
                   $"{YearSetDataRow.ConstructionAssemblyWorksIndicator};{YearSetDataRow.InvestnebtPurchasesIndicator};" +
                   $"{YearSetDataRow.OtherExpendituresIndicator}";
        }

        private int CheckAndReturnYear(string yearString)
        {
            if (yearString.Equals(""))
            {
                return 0;
            }
            else if (Int32.TryParse(yearString, out int year))
            {
                if (year < 1950 || year > DateTime.Now.Year)
                {
                    throw new YearOutOfBoundException();
                }
                else
                {
                    return year;
                }
            }
            else
            {
                throw new InvalidDataTypeException("Znaleziono niepoprawny format danych w kolumnie ROK");
            }
        }

        private double CheckAndReturnIndex(string indexString)
        {
            if (indexString.Equals(""))
            {
                return 0;
            }
            else if (Double.TryParse(indexString, out double index))
            {
                if (index < 0)
                {
                    throw new NegativeValueException();
                }
                else
                {
                    return index;
                }

            }
            else
            {
                Console.WriteLine(indexString);
                throw new InvalidDataTypeException("Znaleziono niepoprawny format danych w kolumnie INDEKS");
            }
        }

        public void SaveChanges(List<YearSet> modifiedDataSet)
        {
            using (StreamWriter streamWriter = new StreamWriter(dataSetPath, false, Encoding.UTF8))
            {
                headers.ForEach(headerRow => streamWriter.WriteLine(headerRow));
                modifiedDataSet.Select(dataRow => YearSetToString(dataRow))
                               .ToList()
                               .ForEach(dataRow => streamWriter.WriteLine(dataRow));
            }
        }
    }
}
