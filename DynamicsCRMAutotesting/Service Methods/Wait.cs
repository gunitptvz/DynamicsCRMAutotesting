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
        static double seconds = 90;

        /// <summary>
        /// Method for wait element is visible
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        public static void ElementIsVisible(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement txt = wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Method for wait element is clickable
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        public static IWebElement ElementToBeClickable(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            IWebElement txt = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            return txt; // comment
        }
    }
}
