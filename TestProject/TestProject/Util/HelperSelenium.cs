using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Threading;

namespace TestProject.Util
{
    public class HelperSelenium : IHelperSelenium
    {
        public void WaitUntil(IWebDriver webdriver, By Id, int time)
        {
            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromMinutes(time));
            wait.Until(ExpectedConditions.ElementToBeClickable(Id));
        }
        public void WaitUntil(IWebDriver webdriver, string idXpath, int time)
        {
            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromMinutes(time));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(idXpath)));
        }
       public void WaitUntil(IWebDriver webdriver, IWebElement element, int time)
       {
            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromMinutes(time));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        public void TryClick(IWebDriver driver, By Id)
        {
            for (int i=0; i<10; i++)
            {
                try
                {
                    driver.FindElement(Id).Click();
                    return;
                }
                catch
                {
                    WaitUntil(driver, Id, 1);
                }
            }

            throw new Exception("Can't find the element.");
        }
        public void TryFind(IWebDriver driver, string idXpath)
        {
            for (int i = 0; i < 2; i++)
            {

                try
                {
                    driver.FindElement(By.XPath(idXpath));
                    return;
                }
                catch
                {
                    WaitUntil(driver, idXpath, 1);
                }
            }

            throw new Exception("Can't find the element.");
        }
        public void sleepWhileExits(IWebDriver driver, string idXpath)
        {
            for (int i = 0; i < 50; i++)
            {

                try
                {
                    driver.FindElement(By.XPath(idXpath));
                    WaitUntil(driver, idXpath, 1);
                }
                catch
                {
                    return;
                    
                }
            }

            throw new Exception("Can't find the element.");
        }

        public void TryClick(IWebDriver driver, string idXpath)
        {
            for (int i = 0; i < 10; i++)
            {

                try
                {
                    driver.FindElement(By.XPath(idXpath)).Click();
                    return;
                }
                catch
                {
                    WaitUntil(driver, idXpath, 1);
                }
            }

            throw new Exception("Can't find the element.");
        }

        public void TryClear(IWebDriver driver, string idXpath)
        {
            for (int i = 0; i < 3; i++)
            {

                try
                {
                    driver.FindElement(By.XPath(idXpath)).Clear();
                    return;
                }
                catch
                {
                    WaitUntil(driver, idXpath, 1);
                }
            }

            throw new Exception("Can't find the element.");
        }
        public void TrySendKeys(IWebDriver driver, string idXpath, string name)
        {
            for (int i = 0; i < 3; i++)
            {

                try
                {
                    driver.FindElement(By.XPath(idXpath)).SendKeys(name);
                    return;
                }
                catch
                {
                    WaitUntil(driver, idXpath, 1);
                }
            }

            throw new Exception("Can't find the element.");
        }
        public void TryClick(IWebDriver driver, IWebElement element)
        {
            for (int i = 0; i < 10; i++)
            {

                try
                {
                    element.Click();
                    return;
                }
                catch
                {
                    WaitUntil(driver, element, 1);
                }
            }

            throw new Exception("Can't find the element.");
        }

        public string FindId(IWebDriver webdriver, string whereFind, string textToFind)
        {

            string cadena = "";

            cadena = "//*[@id='" + whereFind + "']//*[normalize-space(text())='" + textToFind + "']";

            return cadena;
        }

       public String CreatePhoto(IWebDriver driver)
        {

            int number = DateTime.Now.Second;
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string location = (@".");

            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(location + number + ".png", ImageFormat.Png); 
            
            return location + number + ".png";

        }
    }
}
