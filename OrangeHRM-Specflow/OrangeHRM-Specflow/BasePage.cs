using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OrangeHRM_Specflow.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALD_Belgium
{
    class BasePage
    {

        public static IWebDriver driver { get; set; }

        /*
         * @return the application URL
         * 
         * */
        public static string BaseAddress
        {
            get { return Constants.Url; }
        }
        /*
         * Intitialize the browser
         * */
        public static void Intitialize()
        {
            if (Constants.BROWSER.Equals(Constants.CHROME))
            {
                driver = new ChromeDriver();
                Console.WriteLine("Chromer Driver created.");
            }
            else if (Constants.BROWSER.Equals(Constants.FIREFOX))
            {
                driver = new FirefoxDriver();
                Console.WriteLine("Firefox Driver created.");
            }
            else if (Constants.BROWSER.Equals(Constants.InternetExplorer))
            {
                driver = new InternetExplorerDriver();
                Console.WriteLine("Internet Explorer Driver created.");
            }


            driver.Manage().Window.Maximize();
            TurnOnWait();
        }

        /*
         * Navigate to the Base URl
         * **/
        public static void Navigate()
        {
            driver.Navigate().GoToUrl(BaseAddress);

        }

        /*
         * Close the Browser
         * **/
        public static void Close()
        {
            driver.Close();
        }

        /*
         * Quit the Browser session
         * **/
        public static void Quit()
        {
            driver.Quit();
        }

        /*
         * Wait for Page Load
         * */
        public static void TurnOnWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);
        }

        public IWebDriver getWebDriver()
        {

            return getDriver();
        }

        public static IWebDriver getDriver()
        {
            return driver;
        }
    }
}
