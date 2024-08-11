using NUnit.Framework;
using OpenQA.Selenium;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SwagLabE2ETesting.NegativeTestCases;

public class LoginWithUsernameOnly : Setup
{
    [Test]
    public void LoginWithUsernameOnlyTest()
    {
        // Log in
        _driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        _driver.FindElement(By.Id("login-button")).Click();
        
        // Verify error message
        Assert.AreEqual("Epic sadface: Password is required", _driver.FindElement(By.ClassName("error-message-container")).Text);
    }
}