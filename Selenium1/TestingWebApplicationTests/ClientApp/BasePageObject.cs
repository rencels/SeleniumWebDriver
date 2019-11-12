using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingWebApplicationTests.ClientApp
{
    public class BasePageObject
    {
        public IWebDriver driver { protected set; get; }

        public BasePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Close()
        {
            this.driver.Close();
        }
    }
}
