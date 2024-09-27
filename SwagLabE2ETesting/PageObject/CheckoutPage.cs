using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SwagLabE2ETesting.PageObject;

public class CheckoutPage
{
    private IWebDriver _driver;

    public CheckoutPage(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    [FindsBy(How = How.ClassName, Using = "shopping_cart_link")]
    private IList<IWebElement> _finishButton;

    [FindsBy(How = How.ClassName, Using = "checkout_button")]
    private IWebElement _checkoutButton;

    public IList<IWebElement> Finish()
    {
        return _finishButton;
    }

    public void Checkout()
    {
        _checkoutButton.Click();

        //return new PurchasePage(_driver);
    }
}