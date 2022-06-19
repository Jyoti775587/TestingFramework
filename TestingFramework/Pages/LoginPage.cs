using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestingFramework.Pages
{
    internal class LoginPage
    {
        public LoginPage(IWebDriver driver)

        {
            this.driver = driver;
        }

        
        public IWebDriver driver { get; set; }

        public IWebElement Txt_UserName => driver.FindElement(By.Name("login"));
        public IWebElement Txt_Password => driver.FindElement(By.Name("password"));
        public IWebElement Btn_login => driver.FindElement(By.XPath("//button[@type='submit']"));
        public IWebElement Validation_Error => driver.FindElement(By.XPath(" //form[@class='form-inline']/div/span"));
        public IWebElement Card_PopularMake => driver.FindElement(By.XPath("//div[@class='card']/h2[text()='Popular Make']"));

        public HomePage Login(string username, string password)
        {


            Txt_UserName.EnterText(username);
            Txt_Password.EnterText(password);
            Btn_login.Submits();


            return new HomePage(driver);


        }

        public string GetValidationError()
        {           
            return Validation_Error.GetText();
        }

        public string GetPopularMakeCardText()
        {
            return Card_PopularMake.GetText();
        }


    }

}

