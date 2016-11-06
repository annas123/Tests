using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestProject.Util;
using Microsoft.Practices.Unity;
using TestProject.Login;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium.Chrome;

namespace ChromeTest
{
    [TestClass]
    public class ChromeTests
    {
        #region members
        private IWebDriver driver;
        private string baseURL;
        private IHelperSelenium iHelper;
        private IContact iContact;
        private ExtentTest test, incorrectcontact, correctcontact;
        private ExtentReports extent;
        #endregion

        [TestInitialize]
        public void TestSepUP()
        {
            #region containers
            var container = new UnityContainer();
            container.RegisterType<IHelperSelenium, HelperSelenium>();
            container.RegisterType<IContact, Contact>();
            #endregion
            #region resolve container
            iHelper = container.Resolve<IHelperSelenium>();
            iContact = container.Resolve<IContact>();
            #endregion
            this.extent = new ExtentReports(@".\results.html");                    
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(59));
            driver.Manage().Window.Maximize();
            baseURL = "http://qaworks.com/";    
         }

        [TestCleanup]
        public void TestTearDown()
        {
            driver.Close();
            driver.Quit();
        }


        [TestMethod]
        public void TestCreateContact()
        {
            this.test = this.extent.StartTest("TA01", "Contact Page");
            test.Log(LogStatus.Info, "Show logs of the test");
            this.incorrectcontact = this.extent.StartTest("Incorrect contact");
            iContact.TestIncorrectContact(driver, baseURL, this.incorrectcontact);
            this.correctcontact = this.extent.StartTest("Correct contact");
            iContact.TestCorrectContact(driver, baseURL, this.correctcontact);
            this.test.AppendChild(this.incorrectcontact)
                     .AppendChild(this.correctcontact);
            extent.EndTest(this.test);
            extent.Flush();
        }

    }
}
