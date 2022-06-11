using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Review.Model
{
    struct YearSet
    {
        public int Year { get; private set; }
        public int CapitalExpendituresPriceIndicator { get; private set; }
        public int ConstructionAssemblyWorksIndicator { get; private set; }
        public int InvestnebtPurchasesIndicator { get; private set; }
        public int OtherExpendituresIndicator { get; private set; }

        public YearSet(int year, int CEP, int CAW, int IP, int OE)
        {
            Year = year;
            CapitalExpendituresPriceIndicator = CEP;
            ConstructionAssemblyWorksIndicator = CAW;
            InvestnebtPurchasesIndicator = IP;
            OtherExpendituresIndicator = OE;
        }

        public override string ToString()
        {
            return $"{{\n    Year: {Year};" +
                $"\n    CEP: {CapitalExpendituresPriceIndicator};" +
                $"\n    CAW: {ConstructionAssemblyWorksIndicator};" +
                $"\n    IP: {InvestnebtPurchasesIndicator};" +
                $"\n    OE: {OtherExpendituresIndicator};\n}}";
        }
    }
}
