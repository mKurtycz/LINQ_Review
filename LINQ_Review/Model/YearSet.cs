﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Review.Model
{
    struct Yearset
    {
        public int Year { get; private set; }
        public double CapitalExpendituresPriceIndicator { get; private set; }
        public double ConstructionAssemblyWorksIndicator { get; private set; }
        public double InvestnebtPurchasesIndicator { get; private set; }
        public double OtherExpendituresIndicator { get; private set; }

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
