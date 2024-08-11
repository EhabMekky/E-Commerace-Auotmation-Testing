using System.Collections;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SwagLabE2ETesting;

public class AddProductToCart : Setup
{
    [Test]
    public void AddProductToCartTest()
    {
        #region Log in

        // Log in first
        _driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        _driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        _driver.FindElement(By.Id("login-button")).Click();

        #endregion

        string[] productList = { "add-to-cart-sauce-labs-onesie", "add-to-cart-sauce-labs-bike-light" };
        foreach (var item in productList)
        {
            _driver.FindElement(By.Name(item)).Click();
        }

        // Verify the shopping cart badge have 2 items
        Assert.AreEqual("2", _driver.FindElement(By.ClassName("shopping_cart_badge")).Text);
        
        // Check cart after adding
        _driver.FindElement(By.ClassName("shopping_cart_link")).Click();

        string[] expectedItemNames = { "Sauce Labs Onesie", "Sauce Labs Bike Light" };
        var cartItems = _driver.FindElements(By.ClassName("inventory_item_name")).Select(x => x.Text).ToArray();
        CollectionAssert.AreEqual(expectedItemNames,cartItems );
    }
}