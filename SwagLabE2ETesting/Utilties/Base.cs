using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SwagLabE2ETesting.Utilties;

public class Base
{
    private IWebDriver _driver;

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

    }

    protected IWebDriver getDriver()
    {
        return _driver;
    }

    [TearDown]
    public void ClenUp()
    {

        _driver?.Quit();
        _driver?.Dispose();
    }
}