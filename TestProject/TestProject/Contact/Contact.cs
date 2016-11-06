using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestProject.Util;

namespace TestProject.Login
{
    public class Contact : IContact
    {
        private IHelperSelenium iHelperSelenium;

        public Contact(IHelperSelenium _iHelperSelenium)
        {
            this.iHelperSelenium = _iHelperSelenium;
        }
        /// <summary>
        /// Test: Incorrect name, incorrect email and incorrect message
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="baseURL"></param>
        public void TestIncorrectContact(IWebDriver driver, string baseURL, ExtentTest test)
        {
            try
            {
                driver.Navigate().GoToUrl(baseURL);
                driver.Navigate().GoToUrl(baseURL + "/");
                string id = this.iHelperSelenium.FindId(driver, "menu", "Contact");
                this.iHelperSelenium.TryClick(driver, id);
                this.iHelperSelenium.TryClear(driver, "//div[@id='ContactNameBox']/input");
                this.iHelperSelenium.TrySendKeys(driver, "//div[@id='ContactNameBox']/input", "addgdfg");
                this.iHelperSelenium.TryClear(driver, "//div[@id='ContactEmailBox']/input");
                this.iHelperSelenium.TrySendKeys(driver, "//div[@id='ContactEmailBox']/input", "addgdfg");
                this.iHelperSelenium.TryClear(driver, "//div[@id='ContactMessageBox']/textarea");
                this.iHelperSelenium.TrySendKeys(driver, "//div[@id='ContactMessageBox']/textarea", "addgdfg");
                test.Log(LogStatus.Info, "Before sending incorrect Contact", test.AddScreenCapture(this.iHelperSelenium.CreatePhoto(driver)));
                this.iHelperSelenium.TryClick(driver, "//div[@id='ContactSend']/input");
                test.Log(LogStatus.Info, "Result, after sending incorrect Contact", test.AddScreenCapture(this.iHelperSelenium.CreatePhoto(driver)));
                id = this.iHelperSelenium.FindId(driver, "ContactEmailBox", "Invalid Email Address");
                this.iHelperSelenium.TryFind(driver, id);
                test.Log(LogStatus.Pass, "Pass");
            }
            catch
            {
                test.Log(LogStatus.Fail, "Fail");
            }
        }
        /// <summary>
        /// Test: Correct name, incorrect email and incorrect message
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="baseURL"></param>
        public void TestCorrectContact(IWebDriver driver, string baseURL, ExtentTest test)
        {
            try
            {
                driver.Navigate().GoToUrl(baseURL);
                driver.Navigate().GoToUrl(baseURL + "/");
                string id = this.iHelperSelenium.FindId(driver, "menu", "Contact");
                this.iHelperSelenium.TryClick(driver, id);
                this.iHelperSelenium.TryClear(driver, "//div[@id='ContactNameBox']/input");
                this.iHelperSelenium.TrySendKeys(driver, "//div[@id='ContactNameBox']/input", "j.Bloggs");
                this.iHelperSelenium.TryClear(driver, "//div[@id='ContactEmailBox']/input");
                this.iHelperSelenium.TrySendKeys(driver, "//div[@id='ContactEmailBox']/input", "j.Bloggs@qaworks.com");
                this.iHelperSelenium.TryClear(driver, "//div[@id='ContactMessageBox']/textarea");
                this.iHelperSelenium.TrySendKeys(driver, "//div[@id='ContactMessageBox']/textarea", "please contact me I want to find out more");
                test.Log(LogStatus.Info, "Before sending correct Contact", test.AddScreenCapture(this.iHelperSelenium.CreatePhoto(driver)));
                this.iHelperSelenium.TryClick(driver, "//div[@id='ContactSend']/input");
                test.Log(LogStatus.Info, "Result, after sending correct Contact", test.AddScreenCapture(this.iHelperSelenium.CreatePhoto(driver)));
                driver.FindElement(By.XPath("//div[@id='ContactSend']/input"));
                test.Log(LogStatus.Pass, "Pass");

            }
            catch
            {
                test.Log(LogStatus.Fail, "Fail");
            }
}
    }
}
