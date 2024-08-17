using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SwagLabE2ETesting;

public class RemoveProductsFromCart : Setup
{
    [Test]
    public void RemoveItemsFromCart()
    {
        // Log in first
        Login();
        
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        
        string[] productList = { "add-to-cart-sauce-labs-onesie", "add-to-cart-sauce-labs-bike-light" };
        foreach (var item in productList)
        {
            _driver.FindElement(By.Name(item)).Click();
        }

        // Verify the shopping cart badge have 2 items
        Assert.AreEqual("2", _driver.FindElement(By.ClassName("shopping_cart_badge")).Text);
        
        // Check cart after adding
        _driver.FindElement(By.ClassName("shopping_cart_link")).Click();

        wait.Until(d=>d.FindElement(By.Id("remove-sauce-labs-onesie")));
        string[] removeItems = { "remove-sauce-labs-onesie","remove-sauce-labs-bike-light" };

        foreach (var item in removeItems)
        {
            _driver.FindElement(By.Id(item)).Click();
        }
        
        // Verify the shopping cart badge have 0 items
        Assert.AreEqual("0", _driver.FindElement(By.ClassName("shopping_cart_badge")).Text);
    }

}