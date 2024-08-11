using NUnit.Framework;
using OpenQA.Selenium;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SwagLabE2ETesting.NegativeTestCases;

public class LoginWithInvalidPassword : Setup
{
    [Test]
    public void LoginWithInvalidPasswordTest()
    {
        // Log in
        _driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        _driver.FindElement(By.Id("password")).SendKeys("secret");
        _driver.FindElement(By.Id("login-button")).Click();
        
        // Verify error message
        Assert.AreEqual("Epic sadface: Username and password do not match any user in this service", _driver.FindElement(By.ClassName("error-message-container")).Text);
    }
    
    
}