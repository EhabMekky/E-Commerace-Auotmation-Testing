using NUnit.Framework;
using OpenQA.Selenium;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SwagLabE2ETesting.NegativeTestCases;

public class LoginWithPasswordOnly : Setup
{
    [Test]
    public void LoginWithPasswordOnlyTest()
    {
        // Log in
        _driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        _driver.FindElement(By.Id("login-button")).Click();
        
        // Verify error message
        Assert.AreEqual("Epic sadface: Username is required", _driver.FindElement(By.ClassName("error-message-container")).Text);
    }
}