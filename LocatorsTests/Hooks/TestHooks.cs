using Drivers;
using Reqnroll;

[Binding]
public class TestHooks
{
    [AfterScenario]
    public void AfterScenario()
    {
        DriverFactory.QuitDriver();
    }
}

