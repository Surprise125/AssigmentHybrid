using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace HybridAutomationCSharpAssessment
{
    [SetUpFixture]
    public class ReportingClass
    {



        public string Capture(IWebDriver driver, string screenShotName)
        {


            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalPath = pth.Substring(0, pth.LastIndexOf("bin")) + "Screenshots\\" + screenShotName + ".png";
            string localPath = new Uri(finalPath).LocalPath;
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;
        }
        public ExtentReports startReport()
        {
            ExtentReports extent;
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports\\ExtentReports.html";

            extent = new ExtentReports();
            return extent;
        }
        public void reportPass(ExtentReports extent, string reportName, ExtentTest test)
        {

            test = extent.CreateTest("Start  Test");
            test.Log(Status.Pass, "test passed" + test.AddScreenCaptureFromPath(reportName));

           // extent.EndTest(test);
            extent.Flush();
        }
        public void reportFail(ExtentReports extent, string reportName, ExtentTest test)
        {

            test = extent.CreateTest("Fail Test");
            test.Log(Status.Fail, "test failed" + test.AddScreenCaptureFromPath(reportName));
           // extent.AttachReporter(test);
            extent.Flush();
        }
        public void EndReport(ExtentReports extent)
        {


            extent.Flush();

        }
    }
}

