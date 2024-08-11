using System.Collections;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SwagLabE2ETesting;

public class SortProduct : Setup
{

   [Test]
   public void SortProductTest()
   {
       #region Log in

       // Log in first
       _driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
       _driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
       _driver.FindElement(By.Id("login-button")).Click();

       #endregion
       
       // Access the sort dropdown
       SelectElement dropDown = new SelectElement(_driver.FindElement(By.ClassName("product_sort_container")));

       #region sort by price low to high

       // sort by price low to high
       // dropDown.SelectByValue("lohi");
       // Verify the sort
       //Assert.AreEqual("Sauce Labs Onesie", _driver.FindElement(By.ClassName("inventory_item_name")).Text);

       #endregion

       #region sort alphabetically descending
       // sort alphabetically descending
       dropDown.SelectByValue("za");
       // Verify the sort
       Assert.AreEqual("Test.allTheThings() T-Shirt (Red)", _driver.FindElement(By.ClassName("inventory_item_name")).Text);
       #endregion
   }
}