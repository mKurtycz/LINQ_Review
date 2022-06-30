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
            AppController controller = new AppController();

            var result = controller.ReturnProperActionController(state, new List<Yearset>());
            Object ob = new Object();

            Assert.Equal(result.GetType(), actionControllerTypeObject.GetType());
        }

        public static readonly List<Yearset> YearsetTestData = new List<Yearset>();

        public static IEnumerable<object[]> ActionControllerTestData =>
            new List<object[]>
            {
                new object[]
                {
                    1,
                    new DisplayActionController(YearsetTestData)
                },
                new object[]
                {
                    2,
                    new AddActionController(YearsetTestData)
                },
                new object[]
                {
                    3,
                    new EditActionController(YearsetTestData)
                },
                new object[]
                {
                    4,
                    new DeleteActionController(YearsetTestData)
                },
            };
    }
}
