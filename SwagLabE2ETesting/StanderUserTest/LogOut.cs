using NUnit.Framework;
using OpenQA.Selenium;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SwagLabE2ETesting;

public class LogOut : Setup
{
    [Test]
    public void LogOutTest()
    {
        // Log in first
        Login();
        
        // Log out
        _driver.FindElement(By.Id("react-burger-menu-btn")).Click();
        _driver.FindElement(By.Id("logout_sidebar_link")).Click();
        
        // Verify user is logged out
        Assert.AreEqual("https://www.saucedemo.com/", _driver.Url);
    }
}