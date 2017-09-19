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
           UploadTestClass.Upload(browser, element, login, password, progname, recalctype, filepath, itercount, itertime, uploadframe, uploadstatus);
        }

        [Test]
        public void TestMethod1()
        {
            /*browser.Navigate().GoToUrl("https://dev3.ddsm.online/EfficiencyOneDDSM/main.aspx?etn=ddsm_datauploader&extraqs=&histKey=701914286&id=b57f0178-1d9d-e711-8171-3a3035663562&newWindow=true&pagetype=entityrecord#825826692");
            Thread.Sleep(4000);
            Wait.ElementIsVisibleID(browser, "header_crmFormSelector");
            element = browser.FindElement(By.Id("header_crmFormSelector"));
            Wait.ElementToBeClickableID(browser, "tab0");
            element.Click();*/
        }

        [TearDown, Description("Time sleep and close browser method")]
        public void Closebrowser()
        {
            Thread.Sleep(3000);
            browser.Quit();
        }
    }
}

        
