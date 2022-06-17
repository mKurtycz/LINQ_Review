using LINQ_Review.Model;
using LINQ_Review.Exceptions;
using System.Text;

namespace LINQ_Review.Controller
{
    public class DataManipulationController
    {
        private string dataSetPath = "DataSet.csv";
        List<string>? headers;

        public DataManipulationController() { }

        // Method implementing the mechanism of reading data from a csv file
        public List<Yearset> LoadData()
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

        // Method implementing the mechanism of maping csv data row to yearset
        public Yearset StringToYearSet(string stringLine)
        {
            string[] dataFromString = new string[5];
            stringLine.Split(";")[0..5].CopyTo(dataFromString, 0);

            return new Yearset(CheckAndReturnYear(dataFromString[0]),
                                CheckAndReturnIndex(dataFromString[1]),
                                CheckAndReturnIndex(dataFromString[2]),
                                CheckAndReturnIndex(dataFromString[3]),
                                CheckAndReturnIndex(dataFromString[4]));
        }

        // Method implementing the mechanism of maping yearset to csv data row
        public string YearSetToString(Yearset YearSetDataRow)
        {
            return $"{YearSetDataRow.Year};{YearSetDataRow.CapitalExpendituresPriceIndicator};" +
                   $"{YearSetDataRow.ConstructionAssemblyWorksIndicator};{YearSetDataRow.InvestnebtPurchasesIndicator};" +
                   $"{YearSetDataRow.OtherExpendituresIndicator}";
        }

        // Method validating a string and converting it to an int year value
        public int CheckAndReturnYear(string yearString)
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

        // Method validating a string and converting it to a double index value
        public double CheckAndReturnIndex(string indexString)
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

        // Method implementing the mechanism of saving data to a csv file
        public void SaveChanges(List<Yearset> modifiedDataSet)
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
