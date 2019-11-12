using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TestingWebApplicationTests.ClientApp.src.app.nav_menu;

namespace TestingWebApplicationTests.ClientApp.src.app.counter
{
    public class counterTests
    {
        private nav_menuPageObject nav_menu;
        private counterPageObject counterPage;

        [SetUp]
        public void Setup()
        {
            var driver = GetChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44359/");
            nav_menu = new nav_menuPageObject(driver);
            nav_menu.CounterButton.Click();

            this.counterPage = new counterPageObject(driver);
        }

        [Test]
        public void Test1()
        {
            //Arrange
            var initialValue = this.counterPage.CurrentCountLabel;
            var oldValue = initialValue.Text;

            //Act
            this.counterPage.HomeButton.Click();
            var newValue = this.counterPage.CurrentCountLabel.Text;

            //Assert
            Assert.AreEqual("0", oldValue);
            Assert.AreEqual("1", newValue);
        }

        [Test]
        public void Test1_Enter_Text()
        {
            //Arrange

            //Act
            this.counterPage.NameInput.Clear();
            this.counterPage.NameInput.SendKeys("bla bla bla");

            var currentwHandler = this.counterPage.driver.CurrentWindowHandle;
            var windowHandles = this.counterPage.driver.WindowHandles;
            var xx = windowHandles[0];
            var x1 = this.counterPage.driver.PageSource;
            var x2 = this.counterPage.driver.Title;

            //Assert
            Assert.Pass("Pass");
            
        }

        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driver = new ChromeDriver(outputDirectory);

            return driver;
        }

        [TearDown]
        public void Down()
        {
            nav_menu.Close();
        }
    }
}
