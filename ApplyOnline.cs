using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace HybridCSharpFramework
{
    [TestFixture]
    [Parallelizable]
    class ApplyOnline
    {

        public static By lnkCareer = By.XPath("/html/body/header/div/div/div[3]/nav/ul/li[4]/a");
        public static By lnkCountry = By.XPath("/html/body/section/div[2]/div/div/div/div[3]/div[2]/div/div/div[3]/div[2]/div/div/div[4]/a");
        public static By lnkJobTitle = By.XPath("/html/body/section/div[2]/div/div/div/div[3]/div[2]/div/div/div/div/div/div[1]/div[1]/div[2]/div[1]/a");
        public static By lnkToApply = By.XPath("/html/body/section[2]/div[2]/div/div/div/div/div[2]/div[1]/a");

        public static By txtName = By.XPath("/html/body/section[2]/div[2]/div/div/div/div/div[2]/div[2]/form/fieldset[1]/div[1]/div/input");
        public static By txtEmail = By.XPath("/html/body/section[2]/div[2]/div/div/div/div/div[2]/div[2]/form/fieldset[1]/div[2]/div/input");
        public static By txtPhone = By.XPath("/html/body/section[2]/div[2]/div/div/div/div/div[2]/div[2]/form/fieldset[1]/div[3]/div/input");
        public static By btnSubmitApplication = By.XPath("/html/body/section[2]/div[2]/div/div/div/div/div[2]/div[2]/form/fieldset[2]/input");
        public static By txtMessge = By.XPath("/html/body/section[2]/div[2]/div/div/div/div/div[2]/div[2]/form/fieldset[1]/div[5]/div/ul/li");

    }
}
