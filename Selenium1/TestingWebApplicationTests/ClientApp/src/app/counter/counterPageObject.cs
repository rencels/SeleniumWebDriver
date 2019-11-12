using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingWebApplicationTests.ClientApp.src.app.counter
{
    public class counterPageObject : BasePageObject
    {
        public counterPageObject(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement HomeButton
        {
            get
            {
                return driver.FindElement(By.Id("btn btn-primary"));
            }
        }

        public IWebElement CurrentCountLabel
        {
            get
            {
                return driver.FindElement(By.Id("currentCountId"));
            }
        }

        public IWebElement NameInput
        {
            get
            {
                return driver.FindElement(By.Id("nameId"));
            }
        }

    }
}
