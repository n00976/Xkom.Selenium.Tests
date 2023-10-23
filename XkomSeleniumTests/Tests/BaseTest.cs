using BaseTemplate.Interfaces;
using BaseTemplate.Pages;
using BasicSeleniumTest.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BasicSeleniumTest.Tests
{
    public abstract class BaseTest<T> where T: IPage
	{
        private IWebDriver _driver = new ChromeDriver();

        protected T? TestedPage { get; set; } 
        protected NavigationBar? NavigationBar { get; set; }
        private HomePage? _homePage;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");

            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            NavigationBar = new NavigationBar(_driver);
            TestedPage = SelectTestedAppPage();
            _homePage = new HomePage(_driver);
            TestedPage.GoTo();
        }


        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
        protected virtual T SelectTestedAppPage()
        {
            return (T)Activator.CreateInstance(typeof(T),_driver);
		}


    }
}
