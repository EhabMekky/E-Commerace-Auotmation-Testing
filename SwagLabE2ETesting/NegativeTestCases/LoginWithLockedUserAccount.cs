using NUnit.Framework;
using OpenQA.Selenium;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SwagLabE2ETesting.NegativeTestCases;

public class LoginWithLockedUserAccount : Setup
{
    [Test]
    public void LoginWithLockedUserAccountTest()
    {
        // Log in
        _driver.FindElement(By.Id("user-name")).SendKeys("locked_out_user");
        _driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        _driver.FindElement(By.Id("login-button")).Click();
        
        // Verify error message
        Assert.AreEqual("Epic sadface: Sorry, this user has been locked out.", _driver.FindElement(By.ClassName("error-message-container")).Text);
    }
}