using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Tests
{
    public class Tests
    {
        IWebDriver driver;



        [SetUp]
        public void Setup()
        {
            this.driver = GetChromeDriver();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://localhost:44359/");
            var xx = driver.FindElement(By.Id("counterNavigationId"));
            xx.Click();

            var button = driver.FindElement(By.Id("btn btn-primary"));
            HighlighElementUsingJavaScript(By.Id("btn btn-primary"), 5);
            for (int i = 0; i < 100; i++)
            {
                button.Click();
            }

            Assert.Pass("X");
        }

        [TearDown]
        public void Down()
        {
            driver.Close();
        }

        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driver = new ChromeDriver(outputDirectory);

            return driver;
        }

        private void HighlighElementUsingJavaScript(By locationStrategy, int duration = 2)
        {
            var element = this.driver.FindElement(locationStrategy);
            var originalStyle = element.GetAttribute("style");

            IJavaScriptExecutor javaScriptExecutor = driver as IJavaScriptExecutor;

            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                element,
                "style",
                "border: 7px solid yellow; border-style: dashed;");

            if (duration <= 0) return;

            Thread.Sleep(TimeSpan.FromSeconds(2));

            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])",
                element,
                "style",
                originalStyle);

        }
    }
}