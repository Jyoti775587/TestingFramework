using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingFramework.Pages
{
    internal class ModelPage
    {
        public ModelPage(IWebDriver driver)
        {

            this.driver = driver;
        }

        public IWebDriver driver { get; set; }
        public IWebElement Votes => driver.FindElement(By.XPath("//h4[contains(text(),'Votes')]/strong"));
        public IWebElement Txt_Comment => driver.FindElement(By.Id("comment"));
        public IWebElement Btn_Vote => driver.FindElement(By.XPath("//button[contains(text(),'Vote!')]"));
        public IWebElement VoteDate => driver.FindElement(By.XPath("//table[@class='table']//tr[1]//td[1]"));
        public IWebElement VoteAuthor => driver.FindElement(By.XPath("//table[@class='table']//tr[1]//td[2]"));
        public IWebElement VoteComment => driver.FindElement(By.XPath("//table[@class='table']//tr[1]//td[3]"));

        public int getTotalVotes()

        {
            Thread.Sleep(10000);
            return int.Parse(Votes.GetText());

        }

        public String GetLatestVoteDate()
        {
            return VoteDate.GetText();
        }

        public String GetLatestVoteAuthor()
        {
            return VoteAuthor.GetText();
        }

        public String GetLatestVoteComment()
        {
            return VoteComment.GetText();
        }

        public ModelPage ClickVote()
        {
            Btn_Vote.Click();
            return new ModelPage(driver);
        }

        public ModelPage EnterComment(string comment)
        {
           
            Txt_Comment.EnterText(comment);
            return new ModelPage(driver);
        }

        public int VoteIncrement(int oldvotes)
        {
            return (getTotalVotes() - oldvotes);
        }

    }
}
