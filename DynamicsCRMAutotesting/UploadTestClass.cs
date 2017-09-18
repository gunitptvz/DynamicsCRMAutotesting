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


namespace DynamicsCRMAutotesting
{
    class UploadTestClass
    {
        public static void Upload(IWebDriver driver, IWebElement element, string login, string password, string progname, string recalctype, string filepath,
            int itercount, int itertime, string uploadframe, string uploadstatus)
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
            string inputE1ID = "Combo_TypeofUploadedData-inputEl";
            string inputESPrecalcID = "Combo_ddsm_DataUploaderESPRecalculation-inputEl";
            string selectconfigfileID = "uploadBtn-fileInputEl";
            string savenewconfigbuttonID = "button-1082-btnInnerEl";

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
            Thread.Sleep(1000);
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
            ReadOnlyCollection<IWebElement> programNameOptions = driver.FindElements(By.CssSelector("#boundlist-1012-listEl .x-boundlist-item"));
            element = programNameOptions.SingleOrDefault(item => item.Text == progname);
            element.Click();

            // Second field drop down menu expanding
            Wait.ElementIsVisibleID(driver, typeuploaddataRecalculationID);
            element = driver.FindElement(By.Id(typeuploaddataRecalculationID));
            element.Click();

            // Select configuration second field (Select ESP Recalculation Type)
            Wait.ElementIsVisibleID(driver, inputESPrecalcID);
            ReadOnlyCollection<IWebElement> recalculationTypeOptions = driver.FindElements(By.CssSelector("#boundlist-1013-listEl .x-boundlist-item"));
            element = recalculationTypeOptions.SingleOrDefault(item => item.Text == recalctype);
            element.Click();

            // Select Configuration File
            element = driver.FindElement(By.Id(selectconfigfileID));
            element.SendKeys(filepath);
            Thread.Sleep(20000);

            // Create and save new configuration 
            //Wait.ElementIsVisibleID(driver, savenewconfigbuttonID);
            element = driver.FindElement(By.CssSelector("#button-1081-btnInnerEl"));
            //Wait.ElementToBeClickableID(driver, savenewconfigbuttonID);
            element.Click();

            /*//Click on Create & Save new configuration
            IWebElement saveSettings = waitDriver.Until(ExpectedConditions.ElementToBeClickable(
                  By.CssSelector(savebutton)));
            saveSettings.Click();

            //------------------------- Stop 2/20/17

            CheckDialogWindow(driver, waitDriver, itercount, TimeSpan.FromSeconds(itertime)); //<<<<==== added

            string childWindow = driver.WindowHandles.Last();
            driver.SwitchTo().Window(childWindow);
            //driver.Manage().Window.Maximize();

            // Expand drop down list
            WebDriverWait waitDriverUpload = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement selectUploadProgramMenu = waitDriver.Until(ExpectedConditions.ElementToBeClickable(
                By.Id("Combo_TypeofUploadedData-trigger-picker")));
            selectUploadProgramMenu.Click();

            waitDriver.Until(ExpectedConditions.ElementIsVisible(
                By.Id("Combo_TypeofUploadedData-bodyEl")
            ));
            By selectorUploadProgram = By.CssSelector("#boundlist-1012-listEl .x-boundlist-item");
            ReadOnlyCollection<IWebElement> uploadProgramOptions = driver.FindElements(selectorUploadProgram);

            IWebElement elementProgramName = uploadProgramOptions.SingleOrDefault(item => item.Text == progname); //<<<<<<<<<<<<<<<<<<<<==================
            elementProgramName.Click();
            // ----------------------------------------------------------------------------
            IWebElement uploadElement = driver.FindElement(By.Id("uploadBtn-fileInputEl"));
            uploadElement.SendKeys(filepath);

            Console.WriteLine("Wait until dialog window wasn't show");
            // Wait until dialog window wasn't show
            CheckDialogWindow(driver, waitDriver, itercount, TimeSpan.FromSeconds(itertime));
            // ----------------------------------------------------------------------------

            Console.WriteLine("Wait until status is not equal <param>");
            // Wait until status is not equal <param>
            string childWindowUploder = driver.WindowHandles.Last();
            driver.SwitchTo().Window(childWindowUploder);
            //driver.Manage().Window.Maximize();
            waitDriver.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id(uploadframe)));

            string status = uploadstatus;
            CheckStatus(driver, itercount, TimeSpan.FromSeconds(itertime), status);



            // ----------------------------------------------------------------------------
            Console.WriteLine();*/
        }

        public static void CheckDialogWindow(IWebDriver driver, WebDriverWait waitDriver, int count, TimeSpan time)
        {
            Thread.Sleep(time.Milliseconds);

            string childWindow = driver.WindowHandles.Last();
            driver.SwitchTo().Window(childWindow);

            try
            {
                IWebElement btn = waitDriver.Until(ExpectedConditions.ElementToBeClickable(
                    By.CssSelector("#alertJs-tdDialogFooter button")
                ));
                btn.Click();

                return;
            }
            catch (WebDriverTimeoutException)
            {
                if (count > 0)
                {
                    CheckDialogWindow(driver, waitDriver, --count, time);
                }
                else
                {
                    throw new WebDriverTimeoutException();
                }
            }
        }

        public static void CheckStatus(IWebDriver driver, int iterationCount, TimeSpan time, string status)
        {
            int milliseconds = Convert.ToInt32(time.TotalMilliseconds);
            Thread.Sleep(milliseconds);
            //WebDriverWait waitDriver = new WebDriverWait(driver, time);

            IWebElement statusElement = null;
            try
            {
                //IWebElement statusElement = waitDriver.Until(ExpectedConditions.ElementIsVisible(By.Id(
                //    "ddsm_statusfiledatauploading")));
                //waitDriver.Until(ExpectedConditions.TextToBePresentInElement(statusElement, status));

                statusElement = driver.FindElement(By.Id("ddsm_statusfiledatauploading"));
                if (statusElement.Text != status)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                if (iterationCount > 0)
                {
                    CheckStatus(driver, --iterationCount, time, status);
                }
                else
                {
                    throw new Exception("************** Upload status is wrong, expected - " + status
                        + ", actual - " + statusElement.Text);
                }
            }
        }
    }
}
