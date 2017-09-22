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


namespace DynamicsCRMAutotesting
{
    class UploadTestClass
    {
        public static void Upload(IWebDriver driver, IWebElement element, string progname, string recalctype, string filepath)
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
            string inputE1ID = "Combo_TypeofUploadedData-inputEl";
            string inputESPrecalcID = "Combo_ddsm_DataUploaderESPRecalculation-inputEl";
            string selectconfigfileID = "uploadBtn-fileInputEl";
            string inputE1CSS = "#boundlist-1012-listEl .x-boundlist-item";
            string inputESPrecalcCSS = "#boundlist-1013-listEl .x-boundlist-item";
            string savenewconfigbuttonCSS = "#button-1081-btnInnerEl";
            string configsavedbuttonXPATH = ".//*[@id='alertJs-tdDialogFooter']/button"; // This path also uses for the "Excel File Upload Completed" button.
            string statusfiledatauplID = "ddsm_statusfiledatauploading";

            // first element
            element = Wait.ElementToBeClickable(driver, By.Id(newbuttonID));
            Thread.Sleep(1500);
            element.Click();

            // Main panel click
            element = Wait.ElementToBeClickable(driver, By.Id(mainpanelID));
            element.Click();

            // Settings click
            Thread.Sleep(1000);
            element = Wait.ElementToBeClickable(driver, By.Id(settingsID));
            element.Click();

            // Right panel click
            element = Wait.ElementToBeClickable(driver, By.Id(rightnavigID));
            element.Click();

            // Data Uploader Configuration click
            Thread.Sleep(1000);
            element = Wait.ElementToBeClickable(driver, By.Id(datauplconfigID));
            element.Click();

            // NEW button click
            element = Wait.ElementToBeClickable(driver, By.Id(newbuttonID));
            Thread.Sleep(1500);
            element.Click();

            // Last opened tab selection
            lastwindow = driver.WindowHandles.Last();
            driver.SwitchTo().Window(lastwindow);

            // First field drop down menu expanding
            element = Wait.ElementToBeClickable(driver, By.Id(typeuploaddataID));
            element.Click();

            // Select configuration first field (E1-Form) Спросить у Ильи!!!
            Wait.ElementIsVisible(driver, By.Id(inputE1ID));
            List<IWebElement> programNameOptions = driver.FindElements(By.CssSelector(inputE1CSS)).ToList();
            element = programNameOptions.SingleOrDefault(item => item.Text == progname);
            element.Click();

            // Second field drop down menu expanding
            element = Wait.ElementToBeClickable(driver, By.Id(typeuploaddataRecalculationID));
            element.Click();

            // Select configuration second field (Select ESP Recalculation Type)
            Wait.ElementIsVisible(driver, By.Id(inputESPrecalcID));
            IList<IWebElement> recalculationTypeOptions = driver.FindElements(By.CssSelector(inputESPrecalcCSS)).ToList();
            element = recalculationTypeOptions.SingleOrDefault(item => item.Text == recalctype);
            element.Click();

            // Select Configuration File
            element = driver.FindElement(By.Id(selectconfigfileID));
            element.SendKeys(filepath);
            Thread.Sleep(20000);

            // Create and save new configuration 
            element = Wait.ElementToBeClickable(driver, By.CssSelector(savenewconfigbuttonCSS));
            element.Click();

            // Configuration has been saved button click
            element = Wait.ElementToBeClickable(driver, By.XPath(configsavedbuttonXPATH));
            element.Click();

            // Last opened tab selection (second opening)
            lastwindow = driver.WindowHandles.Last();
            driver.SwitchTo().Window(lastwindow);

            // First field drop down menu expanding (second opening)
            element = Wait.ElementToBeClickable(driver, By.Id(typeuploaddataID));
            element.Click();

            // Select configuration first field (E1-Form) (second opening)
            Wait.ElementIsVisible(driver, By.Id(inputE1ID));
            programNameOptions = driver.FindElements(By.CssSelector(inputE1CSS)).ToList();
            element = programNameOptions.SingleOrDefault(item => item.Text == progname);
            element.Click();

            // Select Configuration File (second opening)
            element = driver.FindElement(By.Id(selectconfigfileID));
            element.SendKeys(filepath);

            // Excel File Upload Completed. Start remote parsing excel file button click
            element = Wait.ElementToBeClickable(driver, By.XPath(configsavedbuttonXPATH));
            element.Click();
            Thread.Sleep(140000);

            // Last opened tab selection (third opening) and frame selection
            lastwindow = driver.WindowHandles.Last();
            driver.SwitchTo().Window(lastwindow);
            driver.SwitchTo().Frame("contentIFrame0");

            // Import Completed Successfully verification
            expected = "15. Import Completed Successfully";
            Wait.ElementIsVisible(driver, By.Id(statusfiledatauplID));
            element = driver.FindElement(By.Id(statusfiledatauplID));
            Assert.AreEqual(expected, element.Text, "Uploading not completed");
        }
    }
}
