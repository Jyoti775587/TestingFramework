using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingFramework.Pages;

namespace TestingFramework.Tests
{
    internal class LoginTests

    {
        IWebDriver driver;
        private const string User = "jj";
        private const string InvalidUser = "j";
        private const string password = "Password123!";

        [SetUp]
        public void initialize()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://buggy.justtestit.org/");
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            LoginPage login = new LoginPage(driver);
            HomePage home = login.Login(User, password);
                      
            Thread.Sleep(10000);           

            Assert.AreEqual("Hi, Jyoti", home.GetWelcomeText());

        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            LoginPage login = new LoginPage(driver);
            HomePage home = login.Login(InvalidUser, password);
            Thread.Sleep(1000);        

            Assert.AreEqual("Invalid username/password", login.GetValidationError());

        }



        [TearDown]
        public void CleanUp()
        {
            driver.Close();

        }


    }
}
