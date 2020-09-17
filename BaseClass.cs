using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace HybridCSharpFramework
{
  
   public class BaseClass
    {
        
       
        public static IWebDriver driver;
      // public static IWebDriver driver;
 
       
        public void  GetBrowser(String browserName)
        {
            if (browserName.Equals("chrome"))
                
            {
                driver = new ChromeDriver();
            }

            else if (browserName.Equals("firefox"))
            {
                driver = new FirefoxDriver();
                
            }

            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait.Add(System.TimeSpan.FromSeconds(20));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);



        }



        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        public static IEnumerable<String> BrowserToRunWith()
        {
            String[] browsers = { "chrome", "firefox" };
            foreach (String b in browsers)
            {
                yield return b;

            }
        }
    }
}
