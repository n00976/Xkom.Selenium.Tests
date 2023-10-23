using BaseTemplate.Pages;
using OpenQA.Selenium;

namespace BasicSeleniumTest.Pages
{
    public class NavigationBar : BasicPage
    {
        public NavigationBar(IWebDriver driver) : base(driver) { }

        public HomePage GetHomePage()
        {
            return new HomePage(Driver);
        }

        public ContactPage GetContactPage()
        {
            return new ContactPage(Driver);
        }

        public LoginPage GetLoginPage()
        {
            Click(By.XPath("//a[@href='/konto']"));
            return new LoginPage(Driver);
        }

        public SearchPage SearchForProduct(string productName)
        {
            IsElementDisplayedAfterWaiting(By.XPath("//input[@placeholder='Czego szukasz?']"));
            try
            {
                SetText(By.XPath("//input[@placeholder='Czego szukasz?']"), productName);
            }catch
            {

            }
            
            Click(By.XPath("//button[@class='sc-1p0xkzn-7 ihVVcs']"));
            return new SearchPage(Driver);
        }
    }
}
