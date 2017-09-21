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
        static string jsonfilepath = "aret_upload.json";//@"c:\\Users\\hoswt\\Source\\Repos\\DynamicsCRMAutotesting\\DynamicsCRMAutotesting\\bin\\Debug\\aret_upload.json";
        DataModel data = Mapping.MapJson(jsonfilepath);


        [SetUp, Description("Open browser method")]
        public void Openbrowser()
        {
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl("https://" + data.Login + ":" + data.Password + "@" + data.Url);
            //browser.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5));
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [Test, Description("Run Upload File within the Uploader")]
        public void RunUplFileWithinUpl()
        {
           UploadTestClass.Upload(browser, element, data.Progname, data.Recalctype, data.Filepath);
        }

        /*[Test]
        public void TestMethod1()
        {
            browser.Navigate().GoToUrl("");
            Thread.Sleep(4000);
            Wait.ElementIsVisibleID(browser, "header_crmFormSelector");
            element = browser.FindElement(By.Id("header_crmFormSelector"));
            Wait.ElementToBeClickableID(browser, "tab0");
            element.Click();
        }*/

        [TearDown, Description("Time sleep and close browser method")]
        public void Closebrowser()
        {
            //Thread.Sleep(3000);
            browser.Quit();
        }
    }
}

        
