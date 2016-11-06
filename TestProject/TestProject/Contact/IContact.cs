using OpenQA.Selenium;
using RelevantCodes.ExtentReports;

namespace TestProject.Login
{
    public interface IContact
    {
        void TestIncorrectContact(IWebDriver driver, string baseURL, ExtentTest test);
        void TestCorrectContact(IWebDriver driver, string baseURL, ExtentTest test);
    }
}