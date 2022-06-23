using Xunit;
using LINQ_Review.Controller;
using LINQ_Review.Model;

namespace LINQ_ReviewTests
{
    public class AppControllerTests
    {
        [Theory]
        [MemberData(nameof(ActionControllerTestData))]
        public void ReturnProperActionController_ForGivenStateValue_ReturnsProperActionControllerTypeObject(int state, object actionControllerTypeObject)
        {
            AppController appController = new AppController();

            var result = appController.ReturnProperActionController(state, new List<Yearset>());
            Object ob = new Object();

            Assert.Equal(result.GetType(), actionControllerTypeObject.GetType());
        }

        public static readonly List<Yearset> ActionControllerTestDataYearset = new List<Yearset>();

        public static IEnumerable<object[]> ActionControllerTestData =>
            new List<object[]>
            {
                new object[]
                {
                    1,
                    new DisplayActionController(ActionControllerTestDataYearset)
                },
                new object[]
                {
                    2,
                    new AddActionController(ActionControllerTestDataYearset)
                },
                new object[]
                {
                    3,
                    new EditActionController(ActionControllerTestDataYearset)
                },
                new object[]
                {
                    4,
                    new DeleteActionController(ActionControllerTestDataYearset)
                },
            };
    }
}
