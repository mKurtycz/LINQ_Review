using LINQ_Review.Model;
using LINQ_Review.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Review.Controler
{
    internal class DataManipulationControler
    {
        private string dataSetPath = "DataSetCopy.csv";
        List<string> headers;
        public List<YearSet> dataSet;

        public DataManipulationControler()
        {
            try
            {
                headers = File.ReadLines(dataSetPath).Take(2).ToList();
                dataSet = File.ReadLines(dataSetPath).Skip(2).Select(line => StringToYearSet(line)).ToList();
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

        double CheckAndReturnIndex(string indexString)
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

        public void SaveChanges()
        {

        }
    }
}
