using BaseTemplate.Pages;
using BasicSeleniumTest.Pages;
using BasicSeleniumTest.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTemplate.Tests
{
    internal class ContactTest : BaseTest<ContactPage>
    {
        [Test]
        public void Test()
        {
            TestedPage.AcceptCookies();
            TestedPage.FillContactForm();
            string outputMessage = TestedPage.GetOutputMessage();
            string expectedOutputMessage = "Otrzymaliśmy Twoją wiadomość";
            Assert.IsTrue(expectedOutputMessage == outputMessage);
        }

       
    }
}
