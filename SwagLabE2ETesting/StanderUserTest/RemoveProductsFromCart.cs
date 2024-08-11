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
        #region Log in

        // Log in first
        _driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        _driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        _driver.FindElement(By.Id("login-button")).Click();

        #endregion
        
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        
        string[] productList = { "add-to-cart-sauce-labs-onesie", "add-to-cart-sauce-labs-bike-light" };
        foreach (var item in productList)
        {
            _driver.FindElement(By.Name(item)).Click();
            Thread.Sleep(3000);
        }

        // Verify the shopping cart badge have 2 items
        Assert.AreEqual("2", _driver.FindElement(By.ClassName("shopping_cart_badge")).Text);
        
        // Check cart after adding
        _driver.FindElement(By.ClassName("shopping_cart_link")).Click();
        Thread.Sleep(3000);

        wait.Until(d=>d.FindElement(By.Id("remove-sauce-labs-onesie")));
        string[] removeItems = { "remove-sauce-labs-onesie","remove-sauce-labs-bike-light" };

        foreach (var item in removeItems)
        {
            _driver.FindElement(By.Id(item)).Click();
            Thread.Sleep(3000);
        }
    }

}