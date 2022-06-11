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
            string[] dataFromString = stringLine.Split(";");

            return new YearSet(CheckAndReturnYear(dataFromString[0]),
                                CheckAndReturnIndex(dataFromString[1]),
                                CheckAndReturnIndex(dataFromString[2]),
                                CheckAndReturnIndex(dataFromString[3]),
                                CheckAndReturnIndex(dataFromString[4]));

            int CheckAndReturnYear(string yearString)
            {
                int year;

                if(yearString.Equals(""))
                {
                    return 0;
                }
                else if (Int32.TryParse(yearString, out year))
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

            int CheckAndReturnIndex(string indexString)
            {
                int index;

                if (indexString.Equals(""))
                {
                    return 0;
                }
                else if (Int32.TryParse(indexString, out index))
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
                    throw new InvalidDataTypeException("Znaleziono niepoprawny format danych w kolumnie INDEKS");
                }
            }
        } 

        public void SaveChanges()
        {

        }
    }
}
