using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace SeleniumGridParallel
{
    [TestFixture("chrome")]
    [TestFixture("edge")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class UnitTest1
    {
        private RemoteWebDriver driver;
        private readonly string browser;
        private readonly string gridUrl = "http://192.168.29.218:4444/wd/hub";

        public UnitTest1(string browser)
        {
            this.browser = browser;
        }

        [SetUp]
        public void Setup()
        {
            if (browser == "chrome")
            {
                var options = new ChromeOptions();
                driver = new RemoteWebDriver(new Uri(gridUrl), options);
            }
            else if (browser == "edge")
            {
                var options = new OpenQA.Selenium.Edge.EdgeOptions();
                driver = new RemoteWebDriver(new Uri(gridUrl), options);
            }

        }

        [Test]
        public void OpenGoogleDotCom()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Assert.IsTrue(driver.Title.Contains("Google"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void OpenExampleDotCom()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org");
            Assert.AreEqual("Wikipedia", driver.Title);
        }

        [TearDown]
        public void Teardown()
        {
            if (driver != null)
            {
                driver?.Quit();
                driver?.Dispose();
            }
        }
    }
}