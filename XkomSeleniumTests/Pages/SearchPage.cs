using BasicSeleniumTest.Helpers;
using OpenQA.Selenium;

namespace BasicSeleniumTest.Pages
{
    public class SearchPage : BasicPage
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        public int GetAmountOfProducts()
        {
            var result = Driver.FindElements(By.XPath("(//div[@class='sc-1s1zksu-0 dzLiED sc-162ysh3-1 irFnoT'])"));
            return result.Count();
        }

        public void AddProductToFavorites()
        {
            ClickOnElementAfterWaiting(By.XPath("//div[@class='sc-2ride2-0 dwsfIN sc-1yu46qn-4 gyHdpL']"));
            ClickOnElementAfterWaiting(By.XPath("//div[@class='sc-1s1zksu-0 ecpleP sc-14h089p-0 gybZZY sc-8ngj2v-1 doqQAm']//button[@title='Zapisz na liście']"));
            ClickOnElementAfterWaiting(By.XPath("(//button[@class='sc-15ih3hi-0 sc-14uv5p9-4 fSDviF'])[1]"));
        }


    }
}