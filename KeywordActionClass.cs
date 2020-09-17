using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HybridCSharpFramework
{
    [TestFixture]
    [Parallelizable]
    class KeywordActionClass
    {
        IWebDriver driver;

        public KeywordActionClass()
        {
            driver = BaseClass.driver;
        }

        /*
         *Used for launching the application
         * @parameter url 
         */
        public void launchApplication(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        /*
         * Used to perform click opertation on links,buttons,chckbox
         * @param locator
         */
         
        public void click(By locator)
        {
            driver.FindElement(locator).Click();
        }
        /**
         * set text in textbox or text area
         * @param locator
         * @param testData from Excel/DB
         */
        public void type(By locator, string testData)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(testData);
        }

        public void mouseHover(By locator)
        {
            Actions a = new Actions(driver);
            IWebElement ab = driver.FindElement(locator);
            a.MoveToElement(ab).Build().Perform();

        }

    }
}
