using Core.Utilities;

namespace Tests.GlobalSetup
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [OneTimeSetUp]
        public static void RunBeforeAllTests()
        {
            TestEnvironmentSetup.RunBeforeAllTests();
        }
    }
}
