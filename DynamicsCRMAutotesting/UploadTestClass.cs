using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using NUnit.Framework;


namespace DynamicsCRMAutotesting
{
    class UploadTestClass
    {
        public static void Upload(IWebDriver driver, IWebElement element, string login, string password, string progname, string recalctype, string filepath)
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

            // Main panel click
            Wait.ElementIsVisibleID(driver, mainpanelID);
            element = driver.FindElement(By.Id(mainpanelID));
            Wait.ElementToBeClickableID(driver, mainpanelID);
            element.Click();

            // Settings click
            Thread.Sleep(1000);
            Wait.ElementIsVisibleID(driver, settingsID);
            element = driver.FindElement(By.Id(settingsID));
            Wait.ElementToBeClickableID(driver, settingsID);
            element.Click();

            // Right panel click
            Wait.ElementIsVisibleID(driver, rightnavigID);
            element = driver.FindElement(By.Id(rightnavigID));
            Wait.ElementToBeClickableID(driver, rightnavigID);
            element.Click();

            // Data Uploader Configuration click
            Thread.Sleep(1000);
            Wait.ElementIsVisibleID(driver, datauplconfigID);
            element = driver.FindElement(By.Id(datauplconfigID));
            Wait.ElementToBeClickableID(driver, datauplconfigID);
            element.Click();

            // NEW button click
            Wait.ElementIsVisibleID(driver, newbuttonID);
            element = driver.FindElement(By.Id(newbuttonID));
            Wait.ElementToBeClickableID(driver, newbuttonID);
            Thread.Sleep(1500);
            element.Click();

            // Last opened tab selection
            lastwindow = driver.WindowHandles.Last();
            driver.SwitchTo().Window(lastwindow);

            // First field drop down menu expanding
            Wait.ElementToBeClickableID(driver, typeuploaddataID);
            element = driver.FindElement(By.Id(typeuploaddataID));
            element.Click();

            // Select configuration first field (E1-Form) Спросить у Ильи!!!
            Wait.ElementIsVisibleID(driver, inputE1ID);
            ReadOnlyCollection<IWebElement> programNameOptions = driver.FindElements(By.CssSelector(inputE1CSS));
            element = programNameOptions.SingleOrDefault(item => item.Text == progname);
            element.Click();

            // Second field drop down menu expanding
            Wait.ElementIsVisibleID(driver, typeuploaddataRecalculationID);
            element = driver.FindElement(By.Id(typeuploaddataRecalculationID));
            element.Click();

            // Select configuration second field (Select ESP Recalculation Type)
            Wait.ElementIsVisibleID(driver, inputESPrecalcID);
            ReadOnlyCollection<IWebElement> recalculationTypeOptions = driver.FindElements(By.CssSelector(inputESPrecalcCSS));
            element = recalculationTypeOptions.SingleOrDefault(item => item.Text == recalctype);
            element.Click();

            // Select Configuration File
            element = driver.FindElement(By.Id(selectconfigfileID));
            element.SendKeys(filepath);
            Thread.Sleep(20000);

            // Create and save new configuration 
            Wait.ElementIsVisibleCSS(driver, savenewconfigbuttonCSS);
            element = driver.FindElement(By.CssSelector(savenewconfigbuttonCSS));
            Wait.ElementToBeClickableCSS(driver, savenewconfigbuttonCSS);
            element.Click();

            // Configuration has been saved button click
            Wait.ElementIsVisibleXPATH(driver, configsavedbuttonXPATH);
            element = driver.FindElement(By.XPath(configsavedbuttonXPATH));
            Wait.ElementToBeClickableXPATH(driver, configsavedbuttonXPATH);
            element.Click();

            // Last opened tab selection (second opening)
            lastwindow = driver.WindowHandles.Last();
            driver.SwitchTo().Window(lastwindow);

            // First field drop down menu expanding (second opening)
            Wait.ElementToBeClickableID(driver, typeuploaddataID);
            element = driver.FindElement(By.Id(typeuploaddataID));
            element.Click();

            // Select configuration first field (E1-Form) (second opening)
            Wait.ElementIsVisibleID(driver, inputE1ID);
            programNameOptions = driver.FindElements(By.CssSelector(inputE1CSS));
            element = programNameOptions.SingleOrDefault(item => item.Text == progname);
            element.Click();

            // Select Configuration File (second opening)
            element = driver.FindElement(By.Id(selectconfigfileID));
            element.SendKeys(filepath);

            // Excel File Upload Completed. Start remote parsing excel file button click
            Wait.ElementIsVisibleXPATH(driver, configsavedbuttonXPATH);
            element = driver.FindElement(By.XPath(configsavedbuttonXPATH));
            Wait.ElementToBeClickableXPATH(driver, configsavedbuttonXPATH);
            element.Click();

            // Last opened tab selection (third opening) and frame selection
            lastwindow = driver.WindowHandles.Last();
            driver.SwitchTo().Window(lastwindow);
            driver.SwitchTo().Frame("contentIFrame0");
            Thread.Sleep(70000);

            // Import Completed Successfully verification
            expected = "15. Import Completed Successfully";
            Wait.ElementIsVisibleID(driver, statusfiledatauplID);
            element = driver.FindElement(By.Id(statusfiledatauplID));
            Assert.AreEqual(expected, element.Text, "Uploading not completed");
        }
    }
}
