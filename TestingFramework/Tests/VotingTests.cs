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
    internal class VotingTests
    {
        private const string User = "jj";
        private const string password = "Password123!";
        private const string comment = "Test Comment";
        private const string make = "Alfa Romeo";
        private const string model = "Giulietta";
        private const string model2 = "Mito";



        IWebDriver driver;

        [SetUp]
        public void initialize()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://buggy.justtestit.org/");
        }


        [Test]
        public void VotingWithCommentAndVerifying()
        {
            LoginPage login = new LoginPage(driver);
            OverallRatingPage OverallRating = new OverallRatingPage(driver);
            ModelPage ModelPage = new ModelPage(driver);

            login.Login(User, password)
           .ClickOverallRating()
           .SelectCar(make, model);

            int beforeVotes = ModelPage.getTotalVotes();
            string beforeDate = ModelPage.GetLatestVoteDate();
            string beforeComment = ModelPage.GetLatestVoteComment();

            ModelPage.EnterComment(comment).ClickVote();

            Thread.Sleep(10000);
            Assert.AreEqual(1, ModelPage.VoteIncrement(beforeVotes));
            Assert.AreNotEqual(beforeVotes, ModelPage.getTotalVotes());
            Assert.AreNotEqual(beforeDate, ModelPage.GetLatestVoteDate());
            Assert.AreNotEqual(beforeComment, ModelPage.GetLatestVoteComment());


        }

        [Test]
        public void VotingWithoutCommentAndVerifying()
        {
            LoginPage login = new LoginPage(driver);
            OverallRatingPage OverallRating = new OverallRatingPage(driver);
            ModelPage ModelPage = new ModelPage(driver);

            login.Login(User, password)
           .ClickOverallRating()
           .SelectCar(make, model2);

            int beforeVotes = ModelPage.getTotalVotes();


            ModelPage.ClickVote();

            Thread.Sleep(10000);
            Assert.AreEqual(1, ModelPage.VoteIncrement(beforeVotes));
        }


        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }


















    }
}
