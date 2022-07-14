using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Review.Model
{
    public struct Yearset
    {
        public int Year { get; private set; }
        public double CapitalExpendituresPriceIndicator { get;  set; }
        public double ConstructionAssemblyWorksIndicator { get;  set; }
        public double InvestnebtPurchasesIndicator { get;  set; }
        public double OtherExpendituresIndicator { get;  set; }

        public Yearset(int year, double CEP, double CAW, double IP, double OE)
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
