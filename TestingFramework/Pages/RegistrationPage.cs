using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFramework.Pages
{
    internal class RegistrationPage 
    {

        public RegistrationPage(IWebDriver driver) 
        {
            this.driver = driver;
        }
        public IWebDriver driver { get; set; }
        public IWebElement Btn_Register => driver.FindElement(By.XPath("//button[@type='submit']/following-sibling::a"));
        public IWebElement Txt_Login => driver.FindElement(By.Id("username"));
        public IWebElement Txt_FirstName => driver.FindElement(By.Id("firstName"));
        public IWebElement Txt_LastName => driver.FindElement(By.Id("lastName"));
        public IWebElement Txt_Password => driver.FindElement(By.Id("password"));
        public IWebElement Txt_ConFirmPassword => driver.FindElement(By.Id("confirmPassword"));
        public IWebElement Btn_Registration => driver.FindElement(By.XPath("//button[text()='Register']"));
        public IWebElement Btn_Cancel => driver.FindElement(By.XPath("//a[@class='btn'][text()='Cancel']"));
        public IWebElement Alert_LoginRqr => driver.FindElement(By.XPath("//input[@id='username']/following-sibling::div[1]"));
        public IWebElement Alert_LoginCharLmt => driver.FindElement(By.XPath("//input[@id='username']/following-sibling::div[2]"));
        public IWebElement Alert_FirstNameRqr => driver.FindElement(By.XPath("//input[@id='firstName']/following-sibling::div"));
        public IWebElement Alert_LastNameRqr => driver.FindElement(By.XPath("//input[@id='lastName']/following-sibling::div"));
        public IWebElement Alert_PasswordRqr => driver.FindElement(By.XPath("//input[@id='password']/following-sibling::div"));
        public IWebElement Alert_ConfirmPasswordRqr => driver.FindElement(By.XPath("//input[@id='confirmPassword']/following-sibling::div"));
        public IWebElement Alert_Result => driver.FindElement(By.XPath("//a[@class='btn'][text()='Cancel']/following-sibling::div"));


        public RegistrationPage EnterRegistrationDetails(int loginLength, bool ToLowercase, string firstname, string lastname, string password, string confirmPasspwrd)
        {
            Txt_Login.EnterText(BaseClass.RandomString(loginLength, ToLowercase));
            Txt_FirstName.EnterText(firstname);
            Txt_LastName.EnterText(lastname);
            Txt_Password.EnterText(password);   
            Txt_ConFirmPassword.EnterText(confirmPasspwrd);
            return new RegistrationPage(driver);


        }

        public RegistrationPage EnterLoginFeild(int loginLength, bool ToLowercase)
        {
            Txt_Login.EnterText(BaseClass.RandomString(loginLength, ToLowercase));
            return new RegistrationPage(driver);
        }

        public RegistrationPage EnterExistingUserRegistrationDetails(string login, string firstname, string lastname, string password, string confirmPasspwrd)
        {
           
            Txt_Login.EnterText(login);
            Txt_FirstName.EnterText(firstname);
            Txt_LastName.EnterText(lastname);
            Txt_Password.EnterText(password);
            Txt_ConFirmPassword.EnterText(confirmPasspwrd);
            return new RegistrationPage(driver);


        }

        public void ClickCancel()
        {
            Btn_Cancel.Click();
        }

        public RegistrationPage ClickRegister()
        {
            Btn_Register.Click();
            return new RegistrationPage(driver);
        }

        public RegistrationPage SubmitRegistration()
        {
            Btn_Registration.Click();
            return new RegistrationPage(driver);
        }

        public string GetResultAlertText()
        {
            return Alert_Result.GetText();

        }

        public string GetLoginValidation()
        {
            
            return Alert_LoginRqr.GetText();

        }

        public string GetFirstNameValidation() { 
       
            return Alert_FirstNameRqr.GetText();

        }

        public string GetLastNameValidation()
        {
            return Alert_LastNameRqr.GetText();

        }

        public string GetPasswordValidation()
        {
            return Alert_PasswordRqr.GetText();

        }

        public string GetConfirmPasswordValidation()
        {
            return Alert_ConfirmPasswordRqr.GetText();

        }

        public string GetLoginCharLimitValidationErr()
        { 
            return Alert_LoginCharLmt.GetText();

        }


        public RegistrationPage ClearLoginField()
        {

            Txt_Login.ClearText();
            return new RegistrationPage(driver);
        }

        public RegistrationPage ClearFirstNameField()
        {
            Txt_FirstName.ClearText();
            return new RegistrationPage(driver);
        }

        public RegistrationPage ClearLastNameField()
        {
            Txt_LastName.ClearText();
            return new RegistrationPage(driver);
        }

        public RegistrationPage ClearPasswordField()
        {
            Txt_Password.ClearText();
            return new RegistrationPage(driver);
        }

        public RegistrationPage ClearConfirmPasswordField()
        {   
            Txt_ConFirmPassword.ClearText();
            return new RegistrationPage(driver);
        }

        public LoginPage CancelRegistration()
        {
            Btn_Cancel.Click();
            return new LoginPage(driver);
        }










    }
}
