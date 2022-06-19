using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFramework.Pages
{
    internal class OverallRatingPage
    {
        public OverallRatingPage(IWebDriver driver) { 

        this.driver = driver;
    }

    public IWebDriver driver { get; set; }


    public ModelPage SelectCar(string make, string model)
    {
        Thread.Sleep(10000);
        if (driver.FindElements(By.LinkText(model)).Count != 0)
        {
            driver.FindElement(By.LinkText(model)).Click();
        }
        else if (driver.FindElements(By.LinkText(make)).Count != 0)
        {
            driver.FindElement(By.LinkText(make)).Click();
            driver.FindElement(By.LinkText(model)).Click();
        }
        return new ModelPage(driver);
    }
}
}
