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
    internal class RegistrationTests
    {


        private const string User = "JJ";
        private const string firstname = "Jyoti";
        private const string lastname = "Jyoti";
        private const string password = "Password123!";



        IWebDriver driver;

        [SetUp]
        public void initialize()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://buggy.justtestit.org/");
        }

        [Test]
        public void RegisterNewUser()
        {
            RegistrationPage registration = new RegistrationPage(driver);
            registration.ClickRegister()
           .EnterRegistrationDetails(8, true, firstname, lastname, password, password)
           .SubmitRegistration();
            Thread.Sleep(1000);
            string RegistrationSuccessful = registration.GetResultAlertText();
            Assert.AreEqual("Registration is successful", RegistrationSuccessful);
        }


        [Test]
        public void RegisterExistingUser()
        {
            RegistrationPage registration = new RegistrationPage(driver);
            registration.ClickRegister()
           .EnterExistingUserRegistrationDetails(User, firstname, lastname, password, password)
           .SubmitRegistration();
            Thread.Sleep(1000);
            string UserExists = registration.GetResultAlertText();
            Assert.AreEqual("UsernameExistsException: User already exists", UserExists);

        }

        [Test]
        public void VerifyLoginFieldValidationError()
        {
            RegistrationPage registration = new RegistrationPage(driver);
            registration.ClickRegister()
           .EnterExistingUserRegistrationDetails(User, firstname, lastname, password, password)
           .ClearLoginField();

            Thread.Sleep(10000);
            string LoginValidation = registration.GetLoginValidation();
            Assert.AreEqual("Login is required", LoginValidation);

        }

        [Test]
        public void VerifyLoginFieldMaxLimit()
        {
            RegistrationPage registration = new RegistrationPage(driver);
            registration.ClickRegister()
           .EnterLoginFeild(51, true);

            Thread.Sleep(10000);

            Assert.AreEqual("Login cannot be more than 50 characters long", registration.GetLoginCharLimitValidationErr());

        }

        [Test]
        public void VerifyFirstNameFieldValidationError()
        {
            RegistrationPage registration = new RegistrationPage(driver);
            registration.ClickRegister()
           .EnterExistingUserRegistrationDetails(User, firstname, lastname, password, password)
           .ClearFirstNameField();
            Thread.Sleep(10000);
            string FirstNameValidation = registration.GetFirstNameValidation();
            Assert.AreEqual("First Name is required", FirstNameValidation);

        }

        [Test]
        public void VerifyLastNameFieldValidationError()
        {
            RegistrationPage registration = new RegistrationPage(driver);
            registration.ClickRegister()
           .EnterExistingUserRegistrationDetails(User, firstname, lastname, password, password)
           .ClearLastNameField();
            Thread.Sleep(10000);
            string LastNameValidation = registration.GetLastNameValidation();
            Assert.AreEqual("Last Name is required", LastNameValidation);

        }

        [Test]
        public void VerifyPasswordFieldValidationError()
        {
            RegistrationPage registration = new RegistrationPage(driver);
            registration.ClickRegister()
           .EnterExistingUserRegistrationDetails(User, firstname, lastname, password, password)
           .ClearPasswordField();
            Thread.Sleep(10000);
            string PasswordValidation = registration.GetPasswordValidation();
            Assert.AreEqual("Password is required", PasswordValidation);

        }

        [Test]
        public void VerifyConfirmPasswordFieldValidationError()
        {
            RegistrationPage registration = new RegistrationPage(driver);
            registration.ClickRegister()
           .EnterExistingUserRegistrationDetails(User, firstname, lastname, password, password)
           .ClearConfirmPasswordField();
            Thread.Sleep(10000);
            string PasswordValidation = registration.GetConfirmPasswordValidation();
            Assert.AreEqual("Passwords do not match", PasswordValidation);

        }

        [Test]
        public void VerifyConfirmPasswordDoNotMatchError()
        {
            RegistrationPage registration = new RegistrationPage(driver);
            registration.ClickRegister()
           .EnterExistingUserRegistrationDetails(User, firstname, lastname, password, "passowrd");

            Thread.Sleep(10000);
            string PasswordValidation = registration.GetConfirmPasswordValidation();
            Assert.AreEqual("Passwords do not match", PasswordValidation);

        }

        [Test]
        public void VerifyAllAlphabetPasswordLowercase()
        {
            RegistrationPage registration = new RegistrationPage(driver);
            registration.ClickRegister()
           .EnterExistingUserRegistrationDetails(User, firstname, lastname, "password", "password")
           .SubmitRegistration();
            Thread.Sleep(10000);
            string PasswordValidation = registration.GetResultAlertText();
            Assert.AreEqual("InvalidPasswordException: Password did not conform with policy: Password must have uppercase characters", PasswordValidation);

        }

        [Test]
        public void VerifyAllAlphabetPasswordUppercase()
        {
            RegistrationPage registration = new RegistrationPage(driver);
            registration.ClickRegister()
           .EnterExistingUserRegistrationDetails(User, firstname, lastname, "Password", "Password")
           .SubmitRegistration();
            Thread.Sleep(10000);
            string PasswordValidation = registration.GetResultAlertText();
            Assert.AreEqual("InvalidPasswordException: Password did not conform with policy: Password must have numeric characters", PasswordValidation);

        }

        [Test]
        public void VerifyAlphanumericPassword()
        {
            RegistrationPage registration = new RegistrationPage(driver);
            registration.ClickRegister()
           .EnterExistingUserRegistrationDetails(User, firstname, lastname, "Password123", "Password123")
           .SubmitRegistration();
            Thread.Sleep(10000);
            string PasswordValidation = registration.GetResultAlertText();
            Assert.AreEqual("InvalidPasswordException: Password did not conform with policy: Password must have symbol characters", PasswordValidation);

        }

        [Test]
        public void ClickingCancelOnRegistrationPage()
        {
            RegistrationPage registration = new RegistrationPage(driver);
            LoginPage login = registration.ClickRegister()
            .CancelRegistration();

            Thread.Sleep(10000);

            Assert.AreEqual("Popular Make", login.GetPopularMakeCardText());

        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }


    }
}
