using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

namespace DynamicsCRMAutotesting
{
    [TestFixture]
    public class TestClass
    {
        IWebDriver browser = new ChromeDriver();
        IWebElement element = null;
        string url = "dev3.ddsm.online/EfficiencyOneDDSM/main.aspx#650497072";
        string login = "Administrator";
        string password = "Rjnecz1219694";
        string progname = "E1-ARet";
        string recalctype = "Force ESP Recalculation";
        string filepath = "C:\\Selenium\\Output_ARET_Upload.xls";
        string savebutton = "#button-1081-btnInnerEl";
        int itercount = 10;
        int itertime = 1;
        string uploadframe = "contentIFrame0";
        string uploadstatus = "15. Import Completed Successfully";

        [SetUp, Description("Open browser method")]
        public void Openbrowser()
        {
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("https://" + login + ":" + password + "@" + url);
            //browser.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5));
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [Test]
        public void TestMethod()
        {
           UploadTestClass.Upload(browser, element, login, password, progname, recalctype, filepath, savebutton, itercount, itertime, uploadframe, uploadstatus);
        }
        [TearDown, Description("Time sleep and close browser method")]
        public void Closebrowser()
        {
            Thread.Sleep(3000);
            browser.Quit();
        }
    }
}

        
