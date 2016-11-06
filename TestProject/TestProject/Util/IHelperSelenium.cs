using OpenQA.Selenium;

namespace TestProject.Util
{
    public interface IHelperSelenium
    {
        string CreatePhoto(IWebDriver driver);
        string FindId(IWebDriver webdriver, string whereFind, string textToFind);
        void sleepWhileExits(IWebDriver driver, string idXpath);
        void TryClear(IWebDriver driver, string idXpath);
        void TryClick(IWebDriver driver, string idXpath);
        void TryClick(IWebDriver driver, IWebElement element);
        void TryClick(IWebDriver driver, By Id);
        void TrySendKeys(IWebDriver driver, string idXpath, string name);
        void WaitUntil(IWebDriver webdriver, string idXpath, int time);
        void WaitUntil(IWebDriver webdriver, IWebElement element, int time);
        void WaitUntil(IWebDriver webdriver, By Id, int time);
        void TryFind(IWebDriver driver, string idXpath);
    }
}