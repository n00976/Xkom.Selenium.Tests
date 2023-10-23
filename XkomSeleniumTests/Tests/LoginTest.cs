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
    public class LoginTest : BaseTest<LoginPage>
    {
        [Test]
        public void LoginWithCorrectData()
        {
            var existingText = TestedPage.CheckIfLoggedOnCorrectAccount();
            var expectedText = "Tester";
            Assert.AreEqual(expectedText, existingText);
        }

    }
}
