using NUnit.Framework;
using OpenQA.Selenium;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SwagLabE2ETesting.NegativeTestCases;

public class MissInfoInCheckOutInformation : Setup
{
    [Test]
    public void MissFirstName()
    {
        // Log in first
        Login();
        
        // Add two items to cart
        _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
        _driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();

        // Go to cart
        _driver.FindElement(By.Id("shopping_cart_container")).Click();
        
        // Check out
        _driver.FindElement(By.Id("checkout")).Click();
        
        // Proceed to checkout
        _driver.FindElement(By.Id("last-name")).SendKeys("Khallaf");
        _driver.FindElement(By.Id("postal-code")).SendKeys("12345");
        _driver.FindElement(By.Id("continue")).Click();
        
        // Verify error message
        Assert.AreEqual("Error: First Name is required", 
            _driver.FindElement(By.ClassName("error-message-container")).Text);
    }

    [Test]
    public void MissLastName()
    {
        // Log in first
        Login();
        
        // Add two items to cart
        _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
        _driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();
        
        // Go to cart
        _driver.FindElement(By.Id("shopping_cart_container")).Click();
        
        // Check out
        _driver.FindElement(By.Id("checkout")).Click();
        
        // Proceed to checkout
        _driver.FindElement(By.Id("first-name")).SendKeys("Ehab");
        _driver.FindElement(By.Id("postal-code")).SendKeys("12345");
        _driver.FindElement(By.Id("continue")).Click();
        
        // Verify error message
        Assert.AreEqual("Error: Last Name is required", 
            _driver.FindElement(By.ClassName("error-message-container")).Text);
    }
    
    [Test]
    public void MissPostalCode()
    {
        // Log in first
        Login();
        
        // Add two items to cart
        _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
        _driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light")).Click();
        
        // Go to cart
        _driver.FindElement(By.Id("shopping_cart_container")).Click();
        
        // Check out
        _driver.FindElement(By.Id("checkout")).Click();
        
        // Proceed to checkout
        _driver.FindElement(By.Id("first-name")).SendKeys("Ehab");
        _driver.FindElement(By.Id("last-name")).SendKeys("Khallaf");
        _driver.FindElement(By.Id("continue")).Click();
        
        // Verify error message
        Assert.AreEqual("Error: Postal Code is required", 
            _driver.FindElement(By.ClassName("error-message-container")).Text);
    }
}