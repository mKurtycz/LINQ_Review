using Xunit;
using LINQ_Review.Controller;
using LINQ_Review.Exceptions;
using LINQ_Review.Model;

namespace LINQ_ReviewTests
{
    public class DataManipulationControllerTests
    {
        [Fact]
        public void CheckAndReturnYear_ForEmptyString_Return0()
        {
            DataManipulationController controller = new DataManipulationController();

            int result = controller.CheckAndReturnYear("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1950", 1950)]
        [InlineData("2000", 2000)]
        [InlineData("2022", 2022)]
        public void CheckAndReturnYear_ForStringWithIntValueInRangeOf1950ToDateTime_Now_Year_ReturnsYearIntValue(string yearString, int year)
        {
            DataManipulationController controller = new DataManipulationController();

            int result = controller.CheckAndReturnYear(yearString);

            Assert.Equal(year, result);
        }

        [Theory]
        [InlineData("1949")]
        [InlineData("1900")]
        [InlineData("2023")]
        [InlineData("2050")]
        public void CheckAndReturnYear_ForStringWithIntValueOutOfRangeOf1950ToDateTime_Now_Year_ThrowsYearOutOfBoundException(string yearString)
        {
            DataManipulationController controller = new DataManipulationController();

            Action action = () => controller.CheckAndReturnYear(yearString);

            Assert.Throws<YearOutOfBoundException>(action);
        }

        [Theory]
        [InlineData("19ab")]
        [InlineData("----")]
        [InlineData("0a0b")]
        [InlineData("2010r")]
        public void CheckAndReturnYear_ForStringWithNoIntValue_ThrowsInvalidDataTypeException(string yearString)
        {
            DataManipulationController controller = new DataManipulationController();

            Action action = () => controller.CheckAndReturnYear(yearString);

            Assert.Throws<InvalidDataTypeException>(action);
        }

        [Theory]
        [InlineData("1990;110;;98,0;0", 1990, 110, 0, 98.0, 0)]
        [InlineData("2001;;;;", 2001, 0, 0, 0, 0)]
        public void StringToYearset_ForStringData_ReturnYearsetObject(string stringLine, int year, double CEP, double CAW, double IP, double OE)
        {
            DataManipulationController controller = new DataManipulationController();

            Yearset yearset = controller.StringToYearset(stringLine);

            Assert.Equal(year, yearset.Year);
            Assert.Equal(CEP, yearset.CapitalExpendituresPriceIndicator);
            Assert.Equal(CAW, yearset.ConstructionAssemblyWorksIndicator);
            Assert.Equal(IP, yearset.InvestnebtPurchasesIndicator);
            Assert.Equal(OE, yearset.OtherExpendituresIndicator);
        }

        [Theory]
        [MemberData(nameof(YearsetData))]
        public void YearsetToString_ForYearsetObject_ReturnStringContainingDataSeparatedWithSemicolons(Yearset yearset, string stringLineExpected)
        {
            DataManipulationController controller = new DataManipulationController();

            string result = controller.YearsetToString(yearset);

            Assert.Equal(stringLineExpected, result);
        }

        public static IEnumerable<object[]> YearsetData =>
            new List<object[]>
            {
                new object[]
                {
                    new Yearset(2000, 100, 101, 102, 103),
                    "2000;100;101;102;103"
                },

                new object[]
                {
                    new Yearset(1960, 0, 10.1, 0, 0),
                    "1960;0;10,1;0;0"
                }
            };
    }
}