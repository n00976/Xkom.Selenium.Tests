using BaseTemplate.Models.Consts;
using BasicSeleniumTest.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Pages
{
    public class ContactPage : BasicPage
    {
        public ContactPage(IWebDriver driver) : base(driver)
        {
        }
        public void FillContactForm()
        {
            SetText(By.XPath("//input[@placeholder='E-mail']"), "test@wp.pl");
            SetText(By.XPath("//textarea[@name='message']"), "test");
            Click(By.XPath("//div[@class='sc-3qnozx-1 bhmstJ']"));
            Click(By.XPath("//span[contains(text(),'Wyślij wiadomość')]"));
        }

        public string GetOutputMessage()
        {
            IsElementDisplayedAfterWaiting(By.XPath("//div[@class='sc-2dxbwj-3 iMBuVS']"));
            return GetTextOfElement(By.XPath("//p[@class='sc-2dxbwj-4 iNRmvm']"));
        }

        public override void GoTo()
        {
            var url = string.Join("/", _appSettings.HomePage, Subsite.Contact);
            Driver.Navigate().GoToUrl(url);
        }
    }
}
