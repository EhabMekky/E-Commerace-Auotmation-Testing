using NUnit.Framework;
using OpenQA.Selenium;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SwagLabE2ETesting.NegativeTestCases;

public class LoginWithInvalidUsername : Setup
{
    [Test]
    public void LoginWithInvalidUsernameTest()
    {
        // Log in first
        _driver.FindElement(By.Id("user-name")).SendKeys("standard");
        _driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        _driver.FindElement(By.Id("login-button")).Click();
        
        // Verify error message
        Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", _driver.FindElement(By.ClassName("error-message-container")).Text);
    }
}