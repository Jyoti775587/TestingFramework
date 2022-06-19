using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFramework.Pages
{
    internal static class BaseClass
    {
         public static IWebDriver driver;
              

        public static void EnterText( this IWebElement element, string value)
        {

            element.SendKeys(value);

        }

        public static void Click(this IWebElement element)
        {

            element.Click();

        }

        public static void Submits(this IWebElement element)
        {

            element.Submit();

        }

        public static void SelectFromDropdown(this IWebElement element, string value)
        {

            new SelectElement(element).SelectByText(value);

        }



        public static string GetText(this IWebElement element)
        {

            // return element.GetAttribute("value");
            return element.Text;


        }

        public static string GetTextValue(this IWebElement element)
        {

            return element.GetAttribute("value");
          


        }
        public static string GetTextFromDDL(this IWebElement element)
        {

            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;

        }

        public static void ClearText(this IWebElement element)
        {


            string text = element.GetAttribute("value");
            
            for(int i = 0; i < text.Length; i++)
            {
                element.SendKeys(Keys.Backspace);
            }


        }
       
        public static void WaitUntilVisible(this IWebElement element)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(driver => element.Displayed);
        }

        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

    }
}

