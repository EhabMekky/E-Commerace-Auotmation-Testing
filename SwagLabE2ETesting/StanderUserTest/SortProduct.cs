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
       // Log in first
        Login();
       
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