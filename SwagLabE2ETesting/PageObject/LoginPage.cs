using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace SwagLabE2ETesting.PageObject;

public class LoginPage
{
    private IWebDriver _driver;
    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        PageFactory.InitElements(_driver, this);
    }

    [FindsBy(How = How.Id, Using = "user-name")]
    public IWebElement UserName;

    [FindsBy(How = How.Id, Using = "password")]
    public IWebElement Password;

    [FindsBy(How = How.Id, Using = "login-button")]
    public IWebElement loginButton;

    public ProductsPage Login(string username, string password)
    {
        UserName.SendKeys(username);
        Password.SendKeys(password);
        loginButton.Click();

        return new ProductsPage(_driver);
    }
}