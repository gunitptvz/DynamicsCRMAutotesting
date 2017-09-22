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

namespace DynamicsCRMAutotesting
{
    [TestFixture]
    public class TestClass
    {
        IWebDriver browser = new ChromeDriver();
        IWebElement element = null;
        ExtentReportExecutor repexecute = null;
        // mongodb://195.88.73.175:27017

        static string jsonfilepath = @"c:\\Users\\hoswt\\Source\\Repos\\DynamicsCRMAutotesting\\aret_upload.json"; //"aret_upload.json";
        DataModel data = Mapping.MapJson(jsonfilepath);


        [SetUp, Description("Open browser method")]
        public void Openbrowser()
        {
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("https://" + data.Login + ":" + data.Password + "@" + data.Url);
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [Test]
        public void Run_Upload_File_Within_Uploader()
        {
           repexecute = new ExtentReportExecutor(data.Reporthost);
           UploadTestClass.Upload(browser, element, data.Progname, data.Recalctype, data.Filepath, repexecute);
        }

        [Test]
        public void Accounts()
        {
            
        }

        [TearDown, Description("Time sleep and close browser method")]
        public void Closebrowser()
        {
            //Thread.Sleep(3000);
            browser.Quit();
        }
    }
}

        
