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
    class UploadTestClass
    {
        public static void Upload(IWebDriver driver, IWebElement element, string progname, string recalctype, string filepath, ExtentReportExecutor test)
        {
            // Data
            string mainpanelID = "TabHome";
            string settingsID = "Settings";
            string rightnavigID = "detailActionGroupControl_rightNavContainer";
            string datauplconfigID = "ddsm_datauploaderconfiguration";
            string newbuttonID = "ddsm_datauploaderconfiguration|NoRelationship|HomePageGrid|ddsm.ddsm_datauploaderconfiguration.Button1.Button";
            string typeuploaddataID = "Combo_TypeofUploadedData-trigger-picker";
            string typeuploaddataRecalculationID = "Combo_ddsm_DataUploaderESPRecalculation-trigger-picker";
            string lastwindow;
            string expected;
            List<IWebElement> programNameOptions;
            IList<IWebElement> recalculationTypeOptions;
            string inputE1ID = "Combo_TypeofUploadedData-inputEl";
            string inputESPrecalcID = "Combo_ddsm_DataUploaderESPRecalculation-inputEl";
            string selectconfigfileID = "uploadBtn-fileInputEl";
            string inputE1CSS = "#boundlist-1012-listEl .x-boundlist-item";
            string inputESPrecalcCSS = "#boundlist-1013-listEl .x-boundlist-item";
            string savenewconfigbuttonCSS = "#button-1081-btnInnerEl";
            string configsavedbuttonXPATH = ".//*[@id='alertJs-tdDialogFooter']/button"; // The path also uses for the "Excel File Upload Completed" button.
            string statusfiledatauplID = "ddsm_statusfiledatauploading";

            // Report starting
            test.StartReport("AGS_E1_ARET_TC1", "Run Upload File within the Uploader", "Vladimir/Izotov");

            // Main panel click
            try
            {
                element = Wait.ElementToBeClickable(driver, By.Id(mainpanelID));
                element.Click();
                test.WriteLog(Status.Pass, "Main panel click");
            }
            catch(Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Settings click
            try
            {
                Thread.Sleep(1000);
                element = Wait.ElementToBeClickable(driver, By.Id(settingsID));
                element.Click();
                test.WriteLog(Status.Pass, "Settings click");
            }
            catch(Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Right panel click
            try
            {
                element = Wait.ElementToBeClickable(driver, By.Id(rightnavigID));
                element.Click();
                test.WriteLog(Status.Pass, "Main panel click");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Data Uploader Configuration click
            try
            {
                Thread.Sleep(1000);
                element = Wait.ElementToBeClickable(driver, By.Id(datauplconfigID));
                element.Click();
                test.WriteLog(Status.Pass, "Data Uploader Configuration click");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // NEW button click
            try
            {
                element = Wait.ElementToBeClickable(driver, By.Id(newbuttonID));
                Thread.Sleep(1500);
                element.Click();
                test.WriteLog(Status.Pass, "NEW button click");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Last opened tab selection 
            try
            {
                lastwindow = driver.WindowHandles.Last();
                driver.SwitchTo().Window(lastwindow);
                test.WriteLog(Status.Pass, "Last opened tab selection");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // First field drop down menu expanding
            try
            {
                element = Wait.ElementToBeClickable(driver, By.Id(typeuploaddataID));
                element.Click();
                test.WriteLog(Status.Pass, "First field drop down menu expanding");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Select configuration first field (E1-Form)
            try
            {
                Wait.ElementIsVisible(driver, By.Id(inputE1ID));
                programNameOptions = driver.FindElements(By.CssSelector(inputE1CSS)).ToList();
                element = programNameOptions.SingleOrDefault(item => item.Text == progname);
                element.Click();
                test.WriteLog(Status.Pass, "Select configuration first field (E1-Form)");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Second field drop down menu expanding
            try
            {
                element = Wait.ElementToBeClickable(driver, By.Id(typeuploaddataRecalculationID));
                element.Click();
                test.WriteLog(Status.Pass, "Second field drop down menu expanding");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Select configuration second field (Select ESP Recalculation Type)
            try
            {
                Wait.ElementIsVisible(driver, By.Id(inputESPrecalcID));
                recalculationTypeOptions = driver.FindElements(By.CssSelector(inputESPrecalcCSS)).ToList();
                element = recalculationTypeOptions.SingleOrDefault(item => item.Text == recalctype);
                element.Click();
                test.WriteLog(Status.Pass, "Select configuration second field (Select ESP Recalculation Type)");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Select Configuration File
            try
            {
                element = driver.FindElement(By.Id(selectconfigfileID));
                element.SendKeys(filepath);
                Thread.Sleep(20000);
                test.WriteLog(Status.Pass, "Select Configuration File");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Create and save new configuration 
            try
            {
                element = Wait.ElementToBeClickable(driver, By.CssSelector(savenewconfigbuttonCSS));
                element.Click();
                test.WriteLog(Status.Pass, "Create and save new configuration");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Configuration has been saved button click
            try
            {
                element = Wait.ElementToBeClickable(driver, By.XPath(configsavedbuttonXPATH));
                element.Click();
                test.WriteLog(Status.Pass, "Configuration has been saved button click");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Last opened tab selection (second opening)
            try
            {
                lastwindow = driver.WindowHandles.Last();
                driver.SwitchTo().Window(lastwindow);
                test.WriteLog(Status.Pass, "Last opened tab selection (second opening)");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // First field drop down menu expanding (second opening)
            try
            {
                element = Wait.ElementToBeClickable(driver, By.Id(typeuploaddataID));
                element.Click();
                test.WriteLog(Status.Pass, "First field drop down menu expanding (second opening)");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Select configuration first field (E1-Form) (second opening)
            try
            {
                Wait.ElementIsVisible(driver, By.Id(inputE1ID));
                programNameOptions = driver.FindElements(By.CssSelector(inputE1CSS)).ToList();
                element = programNameOptions.SingleOrDefault(item => item.Text == progname);
                element.Click();
                test.WriteLog(Status.Pass, "Select configuration first field (E1-Form) (second opening)");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Select Configuration File (second opening)
            try
            {
                element = driver.FindElement(By.Id(selectconfigfileID));
                element.SendKeys(filepath);
                test.WriteLog(Status.Pass, "Select Configuration File (second opening)");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Excel File Upload Completed. Start remote parsing excel file button click
            try
            {
                element = Wait.ElementToBeClickable(driver, By.XPath(configsavedbuttonXPATH));
                element.Click();
                Thread.Sleep(140000);
                test.WriteLog(Status.Pass, "Excel File Upload Completed. Start remote parsing excel file button click");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Last opened tab selection (third opening) and frame selection
            try
            {
                lastwindow = driver.WindowHandles.Last();
                driver.SwitchTo().Window(lastwindow);
                driver.SwitchTo().Frame("contentIFrame0");
                test.WriteLog(Status.Pass, "Last opened tab selection (third opening) and frame selection");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            // Import Completed Successfully verification
            try
            {
                expected = "15. Import Completed Successfully";
                Wait.ElementIsVisible(driver, By.Id(statusfiledatauplID));
                element = driver.FindElement(By.Id(statusfiledatauplID));
                Assert.AreEqual(expected, element.Text, "Uploading not completed");
                test.WriteLog(Status.Pass, "Import Completed Successfully verification");
            }
            catch (Exception ex)
            {
                test.WriteLog(Status.Fail, ex.Message);
                test.FinishReport();
            }

            //End reporting
            test.FinishReport();
        }
    }
}
