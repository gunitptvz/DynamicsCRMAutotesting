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
        static double seconds = 15;

        /// <summary>
        /// Method for wait element is visible with ClassName
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="classnamepath"></param>
        public static void ElementIsVisibleClassName(IWebDriver driver, string classnamepath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement txt = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(classnamepath)));
        }

        /// <summary>
        /// Method for wait element is clickable with ClassName
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="classnamepath"></param>
        public static void ElementToBeClickableClassName(IWebDriver driver, string classnamepath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement txt = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(classnamepath)));
        }

        /// <summary>
        /// Method for wait element is visible with CSS
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="csspath"></param>
        public static void ElementIsVisibleCSS(IWebDriver driver, string csspath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement txt = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(csspath)));
        }

        /// <summary>
        /// Method for wait element is clickable with CSS
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="csspath"></param>
        public static void ElementToBeClickableCSS(IWebDriver driver, string csspath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement txt = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(csspath)));
        }

        /// <summary>
        /// Method for wait element is visible with ID
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="idpath"></param>
        public static void ElementIsVisibleID(IWebDriver driver, string idpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement txt = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idpath)));
        }

        /// <summary>
        /// Method for wait element is clickable with ID
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="idpath"></param>
        public static void ElementToBeClickableID(IWebDriver driver, string idpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement txt = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(idpath)));
        }

        /// <summary>
        /// Method for wait element is visible with XPATH
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="xpath"></param>
        public static void ElementIsVisibleXPATH(IWebDriver driver, string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement txt = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }

        /// <summary>
        /// Method for wait element is clickable with XPATH
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="xpath"></param>
        public static void ElementToBeClickableXPATH(IWebDriver driver, string xpath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement txt = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
        }
    }
}
