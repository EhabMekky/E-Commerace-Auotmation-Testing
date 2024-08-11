using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SwagLabE2ETesting
{
    [TestClass]
    public class Setup
    {
        private IWebDriver _driver;
        private readonly bool _closeBrowser = false;
        [TestMethod]
        public void StartBrowser()
        {
            _driver = new ChromeDriver();
            
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }
        
        
        [TearDown]
        public void Dispose()
        {
            if(_closeBrowser)
                _driver.Dispose();
            else Console.WriteLine("Browser remains open for debugging purposes.");
        }
    }
}