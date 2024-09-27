using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SwagLabE2ETesting.PageObject;

public class ProductsPage
{
    private IWebDriver _driver;

    //the card title and add to cart
    private readonly By cardTitle = By.ClassName("inventory_item_name");
    private readonly By addToCart = By.ClassName("btn_primary");
    private readonly By checkoutCart = By.ClassName("shopping_cart_link");


    public ProductsPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void WaitToCheckout()
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.FindElements(checkoutCart).Count > 0);
    }

    // Get products from the page
    public IList<IWebElement> GetProducts()
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        return wait.Until(_driver => _driver.FindElements(By.ClassName("inventory_item")));
    }


    // Get card title
    public By GetCardTitle()
    {
        return cardTitle;
    }

    // Get add to cart
    public By GetAddToCart()
    {
        return addToCart;
    }

    // Get checkout button
    public CheckoutPage GetCheckout()
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        IWebElement checkoutBtn = wait.Until(_driver => _driver.FindElement(checkoutCart));
        checkoutBtn.Click();
        return new CheckoutPage(_driver);
    }
}