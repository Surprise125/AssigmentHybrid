
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace HybridCSharpFramework
{


    [TestFixture]
    [Parallelizable]
    public class Tests : BaseClass

    {

        [Test]
        [TestCaseSource(typeof(BaseClass), "BrowserToRunWith")]
        public void TestMethod(String browserName)
        {
           
            GetBrowser(browserName);
           

            KeywordActionClass actionObj = new KeywordActionClass();

            
            actionObj.launchApplication("https://www.ilabquality.com/");


            
            actionObj.click(ApplyOnline.lnkCareer);
            actionObj.click(ApplyOnline.lnkCountry);
            actionObj.click(ApplyOnline.lnkJobTitle);
            actionObj.click(ApplyOnline.lnkToApply);


           
            GetDataFromExcel.PopulateInCollection(@"C:\\Users\\Suprise.Maapola\\source\\repos\\HybridCSharp\\iLABTestInputdata.xlsx");
            actionObj.type(ApplyOnline.txtName, GetDataFromExcel.ReadData(1, "FirstName"));
            actionObj.type(ApplyOnline.txtEmail, GetDataFromExcel.ReadData(1, "Email"));


           
            string phoneNumber = AutoGenerateNumber();
            actionObj.type(ApplyOnline.txtPhone, phoneNumber);

          
            actionObj.click(ApplyOnline.btnSubmitApplication);

            
            String txtMessge = ApplyOnline.txtMessge.ToString();
            Assert.That(driver.PageSource.Contains("You need to upload at least one file."), Is.EqualTo(true), txtMessge);
          


        }
        public string AutoGenerateNumber()
        {
            Random randomNo = new Random();

            string PhoneNum = "";
            string phoneFormat = "00# ### ####";
            Regex regexObj = new Regex(@"[^\d]");
            PhoneNum = regexObj.Replace(PhoneNum, "");


            for (int i = 0; i < 10; i++)
            {

                PhoneNum = randomNo.Next().ToString(phoneFormat);


            }
            return PhoneNum;
        }
    }
}