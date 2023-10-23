using BaseTemplate.Pages;
using BasicSeleniumTest.Helpers;
using BasicSeleniumTest.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Tests
{
	public class AccountTest : BaseTest<AccountPage>
	{
		[Test]
		public void ClickSaveMarketingConsents_VerifyConfirmationMessageDisplayed()
		{
			TestedPage.SaveMarketingConsents();
			var existingMessageText = TestedPage.VerifyConfirmationMessage();
			var expectedMessageText = "Zmieniliśmy ustawienia powiadomień.";
			Assert.AreEqual(expectedMessageText, existingMessageText);	
			Assert.IsFalse(TestedPage.CloseMessageBox());
        }

        [Test]
        public void AddProductToFavorites_VerifyProductInFavoritesTab()
		{
			var availableProduct = Configuration.GetAppSettings().AvailableProduct;

			if (availableProduct == null)
			{
				throw new Exception("Product in configuration is empty, plaese verify appSettings.json");
			}

            var searchPage = NavigationBar.SearchForProduct(availableProduct);
			searchPage.AddProductToFavorites();
			TestedPage.GoTo();
			string existingFavoriteProduct = TestedPage.VerifyProductInFavoritesTab();
			Assert.AreEqual(Configuration.GetAppSettings().AvailableProduct, existingFavoriteProduct);
        }
		
	}
}
