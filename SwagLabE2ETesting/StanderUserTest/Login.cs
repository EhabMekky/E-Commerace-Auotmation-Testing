using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SwagLabE2ETesting;

public class Login : Setup
{
    [Test]
    public void LoginTest()
    {
        _driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        _driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        _driver.FindElement(By.Id("login-button")).Click();
    }
}