using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SwagLabE2ETesting.PageObject;

public class PurchasePage
{
    private IWebDriver _driver;

    public PurchasePage(IWebDriver driver)
    {
        this._driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    [FindsBy(How = How.Id, Using = "first-name")]
    private IWebElement _firstName;

    [FindsBy(How = How.Id, Using = "last-name")]
    private IWebElement _lastName;

    [FindsBy(How = How.Id, Using = "postal-code")]
    private IWebElement _zipCode;

    [FindsBy(How = How.Id, Using = "continue")]
    private IWebElement _checkoutButton;


    public void FinishPurchase(string firstName, string lastName, string zipCode)
    {
        _firstName.SendKeys(firstName);
        _lastName.SendKeys(lastName);
        _zipCode.SendKeys(zipCode);
        _checkoutButton.Click();
    }

}