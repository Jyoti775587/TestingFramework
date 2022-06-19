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
    internal class ProfileTests
    {
        private const string User = "jj";
        private const string password = "Password123!";

        IWebDriver driver;

        [SetUp]
        public void initialize()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://buggy.justtestit.org/");
        }


        [Test]
        public void ChangeProfileSettingsAndVerify()
        {
            LoginPage login = new LoginPage(driver);
            ProfilePage profile = new ProfilePage(driver);

            login.Login(User, password)
           .ClickProfile()
           .EnterDetails("Female", "25", "abcd", "12345678", "Reading")
           .Save();
            Thread.Sleep(10000);
            Assert.AreEqual("The profile has been saved successful", profile.GetSuccessMessage());
            Assert.AreEqual("Female", profile.GetGender());
            Assert.AreEqual("25", profile.GetAge());
            Assert.AreEqual("abcd", profile.GetAddress());
            Assert.AreEqual("Reading", profile.GetHobby());
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }
}
}
