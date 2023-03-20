using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project1;

using RestSharp;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class RegressionTests
    {
        public TestContext TestContext { get; set; }


        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            var dir = testContext.TestRunDirectory;
            Reporter.SetupExtentReport("API Regression Test", "API Regression Test Report", dir);
        }


        [TestInitialize]
        public void SetupTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            Status logStatus;

            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    logStatus = Status.Fail;
                    Reporter.TestStatus(logStatus.ToString());
                    break;
                case UnitTestOutcome.Passed:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    break;

            }
        }


        [ClassCleanup]
        public static void Cleanup()
        {
            Reporter.FlushReport();
        }


        [TestMethod]
        public void VerifyListOfUsers()
        {
            var demo = new Demo<ListOfUsersDTO>();
            var user = demo.GetUsers("api/users?page=2");
            Assert.IsNotNull(user);
            Reporter.LogToReport(Status.Pass, "response is not null");
            Assert.AreEqual(2, user.Page);
            Reporter.LogToReport(Status.Pass, "page=2 Assert is equal");
            Assert.AreEqual("Michael", user.Data[0].first_name);
            Reporter.LogToReport(Status.Pass, "first name is equal");
        }

        
        
        
        [DeploymentItem("D:\\visual studio IDE\\LearningRestSharp\\UnitTestProject\\TestData\\TestCase.csv"), 
            DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestCase.csv", "TestCase#csv",
            DataAccessMethod.Sequential)]


        

        [TestMethod]

        public void CreateNewUser()
        {
            //string payload = @"{
            //                        ""name"": ""Mike"",
            //                        ""job"": ""Team leader""
            //                    }";

           
            var users = new CreateUserRequestDTO();
            users.name = TestContext.DataRow["name"].ToString();
            Reporter.LogToReport(Status.Info, "test data for name is "+ users.name);
            users.job = TestContext.DataRow["job"].ToString();

            var demo = new Demo<CreateUserDTO>();
            var user = demo.CreateUser("api/users",users);

            //Assert.IsNotNull(user);
            //Assert.AreEqual("Mike",user.name);
            //Assert.AreEqual("Team leader", user.job);


            var demoOne = new Demo<ListOfUsersDTO>();
            var userOne = demoOne.GetUsers("api/users?page=2");
            Assert.IsNotNull(userOne);
            Assert.AreEqual(2, userOne.Page);
            Assert.AreEqual("Michael", userOne.Data[0].first_name);
        }
    }
}
