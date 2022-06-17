using Xunit;
using LINQ_Review.Controller;
using LINQ_Review.Exceptions;

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
    }
}