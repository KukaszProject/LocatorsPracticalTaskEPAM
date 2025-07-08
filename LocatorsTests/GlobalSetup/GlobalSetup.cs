namespace LocatorsTests
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [OneTimeSetUp]
        public void RunBeforeAllTests()
        {
            CleanFolder("Downloads");
            CleanFolder("Screenshots");
            CleanFolder("Logs");
        }

        private void CleanFolder(string folderName)
        {
            var folderPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, folderName);
            if (Directory.Exists(folderName))
            {
                Directory.Delete(folderName, true);
            }
        }
    }
}
