using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using DynamicsCRMAutotesting.Service_Methods;

namespace DynamicsCRMAutotesting.Test_Methods
{
    class AccountTestClass
    {
        public static void Account(IWebDriver driver, IWebElement element, ExtentReportExecutor test)
        {
            // Data


            // Report starting
            test.StartReport("AGS_E1_ARET_TC2", "Accounts", "Vladimir/Izotov");

            //
            try
            {
                
                test.WriteLog(Status.Pass, "");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            //
            try
            {

                test.WriteLog(Status.Pass, "");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }
        }
    }
}
