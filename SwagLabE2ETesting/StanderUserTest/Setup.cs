using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SwagLabE2ETesting
{
    public class Setup
    {
        protected IWebDriver _driver;
        protected readonly bool _closeBrowser = false;
        
        [SetUp]
        public void StartBrowser()
        {
            _driver = new ChromeDriver();
            
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }
        
        protected void Login()
        {
            _driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            _driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            _driver.FindElement(By.Id("login-button")).Click();
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