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
using DynamicsCRMAutotesting.Data;
using DynamicsCRMAutotesting.Service_Methods;
using DynamicsCRMAutotesting.Test_Methods;

namespace DynamicsCRMAutotesting
{
    [TestFixture]
    public class TestClass
    {
        IWebDriver browser = new ChromeDriver();
        IWebElement element = null;
        DataModel data = null;
        ExtentReportExecutor repexecute = null;
        // mongodb://195.88.73.175:27017

        static string aretuploadfilepath = "C:\\Users\\hoswt\\Source\\Repos\\DynamicsCRMAutotesting\\aret_upload.json"; //"aret_upload.json";
        static string aretaccountfilepath = "C:\\Users\\hoswt\\Source\\Repos\\DynamicsCRMAutotesting\\aret_account.json";

        [SetUp, Description("Open browser method")]
        public void Openbrowser()
        {
            data = Mapping.MapJson(aretuploadfilepath);
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("https://" + data.Login + ":" + data.Password + "@" + data.Url);
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [Test]
        public void Run_Upload_File_Within_Uploader()
        {
            data = Mapping.MapJson(aretuploadfilepath);
            repexecute = new ExtentReportExecutor(data.Reporthost);
            UploadTestClass.Upload(browser, element, data.Progname, data.Recalctype, data.Filepath, repexecute);
        }

        [Test]
        public void Accounts()
        {
            data = Mapping.MapJson(aretaccountfilepath);
            repexecute = new ExtentReportExecutor(data.Reporthost);
            AccountTestClass.Account(browser, element, repexecute);
        }

        [TearDown, Description("Time sleep and close browser method")]
        public void Closebrowser()
        {
            //Thread.Sleep(3000);
            browser.Quit();
        }
    }
}

        
