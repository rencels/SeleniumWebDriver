using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingWebApplicationTests.ClientApp.src.app.nav_menu
{
    public class nav_menuPageObject : BasePageObject
    {

        public nav_menuPageObject(IWebDriver driver) 
            : base(driver)
        {

        }

        public IWebElement HomeButton
        {
            get
            {
                return driver.FindElement(By.Id("homeNavigationId"));
            }
        }

        public IWebElement CounterButton
        {
            get
            {
                return driver.FindElement(By.Id("counterNavigationId"));
            }
        }

        public IWebElement FetchDataNavigation
        {
            get
            {
                return driver.FindElement(By.Id("fetchNavigationId"));
            }
        }


    }
}
