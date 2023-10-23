using BaseTemplate.Models.Consts;
using BasicSeleniumTest.Helpers;
using BasicSeleniumTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Pages
{
	public class AccountPage : BasicPage
	{
		public AccountPage(IWebDriver driver) : base(driver)
		{
            _navigationBar = new NavigationBar(driver);
		}

		private readonly NavigationBar _navigationBar;

        public override void GoTo()
		{
			base.GoTo();

			AcceptCookies();			
            var loginPage = _navigationBar.GetLoginPage();

			bool isNotLogged = loginPage.CheckIfNotLogged();
			if (isNotLogged == true) 
			{
                loginPage.LoginByCorrectCredentials();
            }
            

            var urlAccountPage = string.Join("/", _appSettings.HomePage, Subsite.Account);
            Driver.Navigate().GoToUrl(urlAccountPage);

        }

		public void SaveMarketingConsents()
		{
			Click(By.XPath("//a[@title='Ustawienia konta']"));
			ClickOnElementAfterWaiting(By.XPath("//button[@class='sc-fzpans hxckzp sc-fznyAO enUIgr sc-8ly4mb-4 cHrPJR']//div[@class='sc-fzoLsD dAZHqx']"));
		}

		public string VerifyConfirmationMessage()
		{
            return GetTextOfElement(By.XPath("//div[@class='sc-1rbdfu2-1 fAeTTM']"));
		}
		
		public bool CloseMessageBox()
		{
            Click(By.XPath("//button[@title='Zamknij']"));
			return IsElementExists(By.XPath("//div[@class='sc-1rbdfu2-0 eCbVbD']"));
        }

		public string VerifyProductInFavoritesTab()
		{
			ClickOnElementAfterWaiting(By.XPath("//a[@class='sc-1h16fat-0 dNrrmO sc-1vth0-1 fzlvxz']"));
			Task.Delay(1000);
			if (!IsElementExists(By.XPath(("//a[normalize-space()='Sigma S 70-200mm f/2.8 DG OS HSM Canon']"))))
				return string.Empty;

			return GetTextOfElement(By.XPath("//a[normalize-space()='Sigma S 70-200mm f/2.8 DG OS HSM Canon']"));

		}

    }
}
