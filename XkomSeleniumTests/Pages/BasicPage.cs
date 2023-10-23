using BaseTemplate.Interfaces;
using BasicSeleniumTest.Helpers;
using BasicSeleniumTest.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BasicSeleniumTest.Pages
{
    public abstract class BasicPage : IPage
    {

        public BasicPage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            _appSettings = Configuration.GetAppSettings();
        }
        protected readonly AppSettings _appSettings;
        protected IWebDriver Driver;
        protected WebDriverWait Wait;
        protected void Click(By locator) => Driver.FindElement(locator).Click();
        protected bool IsElementDisplayedAfterWaiting(By locator) => Wait.Until(EC.ElementIsVisible(locator)).Displayed;
        protected IWebElement LocateElement(By locator) => Driver.FindElement(locator);
        protected void SetText(By locator, string text) => LocateElement(locator).SendKeys(text);
        protected void ClickOnElementAfterWaiting(By locator) => Wait.Until(EC.ElementIsVisible(locator)).Click();
        protected string GetTextOfElement(By locator) => LocateElement(locator).Text;
        protected IWebElement GetChildOfParent(By currentChild, By destinationChild)
        {
            IWebElement childElement = Driver.FindElement(currentChild);

            IWebElement parentElement = childElement.FindElement(By.XPath(".."));

            IWebElement childOfParentElement = parentElement.FindElement(destinationChild);

            return childOfParentElement;
        }
        protected bool IsElementExists(By locator)
        {
            try
            {
                var element = Driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
        protected string GetAlertTextAndAcceptAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            var alertMessage = alert.Text;
            alert.Accept();
            return alertMessage;
        }

        public virtual void GoTo()
        {
            Driver.Navigate().GoToUrl(_appSettings.HomePage);
        }

        public void AcceptCookies()
        { 
            bool IsCookieAcceptanceNeeded = IsElementExists(By.XPath("//h3[contains(text(),'Dostosowujemy się do Ciebie')]"));
            if (IsCookieAcceptanceNeeded == true)
            {
                Click(By.XPath("//button[contains(text(),'W porządku')]"));
            }
        }
    }
}