using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFramework.Pages
{
    internal class ProfilePage
    {
        public ProfilePage(IWebDriver driver)
        {


            this.driver = driver;
        }
        public IWebDriver driver { get; set; }




        public IWebElement Lnk_Profile => driver.FindElement(By.XPath("//*[@class='nav-link'][text()='Profile']"));
        public IWebElement Lnk_Logout => driver.FindElement(By.XPath("//*[@class='nav-link'][text()='Profile']"));
        public IWebElement Txt_Gender => driver.FindElement(By.XPath("//input[@id='gender']"));
        public IWebElement Txt_Age => driver.FindElement(By.XPath("//input[@id='age']"));
        public IWebElement Txt_Address => driver.FindElement(By.Id("address"));
        public IWebElement Txt_Phone => driver.FindElement(By.XPath("//input[@id='phone']"));
        public IWebElement Select_Hobby => driver.FindElement(By.XPath("//select[@id='hobby']"));
        public IWebElement Btn_Save => driver.FindElement(By.XPath("//button[@type='submit']"));
        public IWebElement Sucess_Message => driver.FindElement(By.XPath("//div[contains(text(),'The profile has been saved successful')]"));





        public ProfilePage EnterDetails(string gender, string age, string address, string phone, string hobby)
        {
            Thread.Sleep(10000);
            Txt_Gender.Clear();
            Txt_Age.Clear();
            Txt_Address.Clear();
            Txt_Phone.Clear();
            Txt_Gender.EnterText(gender);
            Txt_Age.EnterText(age);
            Txt_Address.EnterText(address);
            Txt_Phone.EnterText(phone);
            Select_Hobby.SelectFromDropdown(hobby);
            return new ProfilePage(driver);
        }

        public ProfilePage Save()
        {
            Btn_Save.Click();
            return new ProfilePage(driver);
        }

        public string GetSuccessMessage()
        {

            return Sucess_Message.GetText();

        }

        public string GetGender()
        {
            return Txt_Gender.GetTextValue();
        }

        public string GetAge()
        {
            return Txt_Age.GetTextValue();
        }

        public string GetAddress()
        {
            return Txt_Address.GetTextValue();
        }

        public string GetHobby()
        {
            return Select_Hobby.GetTextFromDDL();




        }



    } }
