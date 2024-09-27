using NUnit.Framework;
using OpenQA.Selenium;
using SwagLabE2ETesting.PageObject;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SwagLabE2ETesting.Utilties;

public class E2ETest : Base
{
    [Test]
    public void EndToEndTest()
    {
        String[] expectedProducts = { "Backpack", "Jacket" };
        String[] actualProducts = new String[2];

        LoginPage loginPage = new LoginPage(getDriver());
        ProductsPage productsPage = loginPage.Login("standard_user", "secret_sauce");

        productsPage.WaitToCheckout();


        IList<IWebElement> products = productsPage.GetProducts();

        try
        {
            foreach (IWebElement product in products)
            {
                if (expectedProducts.Contains(
                        product.FindElement(productsPage.GetCardTitle()).Text)) ;
                {
                    product.FindElement(productsPage.GetAddToCart()).Click();
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        CheckoutPage checkoutPage = productsPage.GetCheckout();

        IList<IWebElement> checkoutProducts = checkoutPage.Finish();

        for (int i = 0; i < checkoutProducts.Count; i++)
        {
            actualProducts[i] = checkoutProducts[i].Text;
        }

        //Assert.AreEqual(expectedProducts, actualProducts);
        checkoutPage.Checkout();

        PurchasePage purchasePage = new PurchasePage(getDriver());
        purchasePage.FinishPurchase("Ehab", "Khallaf", "12345");

    }
}