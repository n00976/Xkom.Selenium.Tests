using BaseTemplate.Models.Consts;
using BasicSeleniumTest.Helpers;
using BasicSeleniumTest.Models;
using BasicSeleniumTest.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Pages
{
    public class LoginPage : BasicPage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void LoginByCorrectCredentials()
        {
            SetText(By.XPath("(//input[@placeholder='E-mail lub login'])[1]"), Configuration.GetAppSettings().Credentials.Login);
            SetText(By.XPath("//input[@placeholder='Hasło']"), Configuration.GetAppSettings().Credentials.Password);
            Click(By.XPath("//button[@type='submit']"));
        }

        public string CheckIfLoggedOnCorrectAccount()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.LoginByCorrectCredentials();
            IsElementDisplayedAfterWaiting(By.XPath("//p[@class='sc-v1egpg-1 fXYPHR']"));
            IsElementDisplayedAfterWaiting(By.XPath("//p[@class='sc-v1egpg-2 eEnZLj']"));
            return GetTextOfElement(By.XPath("//p[@class='sc-v1egpg-2 eEnZLj']"));

        }

        public bool CheckIfNotLogged()
        {
            return IsElementExists(By.XPath("//h2[contains(text(),'Zaloguj się')]"));
        }

        public override void GoTo()
        {
            var url = string.Join("/", _appSettings.HomePage, Subsite.Login);
            Driver.Navigate().GoToUrl(url);
        }
    }
}
