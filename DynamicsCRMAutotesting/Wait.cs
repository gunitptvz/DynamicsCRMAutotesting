using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DynamicsCRMAutotesting
{
    class Wait
    {
        public static void ElementIsVisibleID(IWebDriver driver, string idpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            IWebElement txt = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idpath)));
        }

        public static void ElementToBeClickableID(IWebDriver driver, string idpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            IWebElement txt = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(idpath)));
        }

        public static void ElementIsVisibleXPATH(IWebDriver driver, string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            IWebElement txt = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(xpath)));
        }

        public static void ElementToBeClickableXPATH(IWebDriver driver, string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            IWebElement txt = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(xpath)));
        }
    }
}
