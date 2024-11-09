using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AssetManagement.Core
{
    public class DriverManager
    {
        private static IWebDriver _driver;

        public static IWebDriver GetDriver(bool headless = true, string browserType = "chrome")
        {
            if (_driver == null)
            {
                InitDriver(headless, browserType);
            }
            return _driver;
        }

        private static void InitDriver(bool headless, string browserType)
        {
            switch (browserType.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    if (headless)
                    {
                        chromeOptions.AddArgument("--headless");
                    }
                    _driver = new ChromeDriver(chromeOptions);
                    break;
                case "firefox":
                    var fireFoxOptions = new FirefoxOptions();
                    if (headless)
                    {
                        fireFoxOptions.AddArgument("--headless");
                    }
                    _driver = new FirefoxDriver(fireFoxOptions);
                    break;
                case "edge":
                    var edgeOptions = new EdgeOptions();
                    if (headless)
                    {
                        edgeOptions.AddArgument("--headless");
                    }
                    _driver = new EdgeDriver(edgeOptions);
                    break;
            }
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}
