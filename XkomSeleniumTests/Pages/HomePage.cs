using BasicSeleniumTest.Helpers;
using BasicSeleniumTest.Models;
using BasicSeleniumTest.Pages;
using OpenQA.Selenium;

namespace BaseTemplate.Pages
{
    public class HomePage : BasicPage
    {
        public HomePage(IWebDriver driver) : base(driver) { }


        public AppSettings AppSettings => _appSettings;

        public override void GoTo()
        {
            var homepage = Configuration.GetAppSettings().HomePage;
            Driver.Navigate().GoToUrl(homepage);
        }
    }
}
