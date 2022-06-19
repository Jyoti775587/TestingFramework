using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestingFramework.Pages
{
    internal class HomePage
    {
        public HomePage(IWebDriver driver)
        {

            this.driver = driver;
        }

     
        public IWebDriver driver { get; set; }


        public IWebElement Welcome_Txt => driver.FindElement(By.XPath("//div[@class='pull-xs-right']/ul/li[1]/span"));
        public IWebElement Lnk_Profile => driver.FindElement(By.XPath("//*[@class='nav-link'][text()='Profile']"));
        public IWebElement TitleId => driver.FindElement(By.Id("TitleId"));
        public IWebElement TxtInitial => driver.FindElement(By.Name("Initial"));
        public IWebElement TxtFirstName => driver.FindElement(By.Name("FirstName"));
        public IWebElement TxtMiddleName => driver.FindElement(By.Name("MiddleName"));
        public IWebElement btn_save => driver.FindElement(By.Name("Save"));
        public IWebElement OverallRating => driver.FindElement(By.XPath("//div[@class='card']/a[@href='/overall']"));


        public void FillDetails(string Initial, string middlename, string firstname)
        {
            TxtInitial.EnterText(Initial);
            TxtFirstName.EnterText(firstname);
            TxtMiddleName.EnterText(middlename);

        }
        public string GetWelcomeText()
        {
            return Welcome_Txt.GetText();
           
        }

        public ProfilePage ClickProfile()
        {
            Thread.Sleep(10000);
           
            //Lnk_Profile.WaitUntilVisible();
            Lnk_Profile.Click();
            return new ProfilePage(driver);
        }

        public OverallRatingPage ClickOverallRating()
        {
            Thread.Sleep(10000);
            OverallRating.Click();
            return new OverallRatingPage(driver);
        }

    }
}

