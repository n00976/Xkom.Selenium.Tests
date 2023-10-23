using BaseTemplate.Pages;
using BasicSeleniumTest.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Tests
{
    public class SearchTest : BaseTest<HomePage>
    {

        [Test]
        public void FindProductAndCheckTheAmountOfDisplayedResults_AmountIsCorrect()
        {
            TestedPage.AcceptCookies();
            var expectedValues = TestedPage.AppSettings.ExpectedAmountOfProduct;
            var searchPage = NavigationBar.SearchForProduct(expectedValues.ProductName);
            var givenAmountOfProducts = searchPage.GetAmountOfProducts();
            var expectedAmountOfProducts = expectedValues.ExpectedAmount;

            Assert.AreEqual(expectedAmountOfProducts, givenAmountOfProducts);
        }


        protected override HomePage SelectTestedAppPage()
        {
            return NavigationBar.GetHomePage();
        }
    }
}
