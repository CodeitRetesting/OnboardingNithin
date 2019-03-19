using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddEducationSteps
    {
        [Given(@"I clicked on the education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Education tab
            Driver.driver.FindElement(By.XPath("//a[@class][@data-tab='third']")).Click();
        }
        
        [When(@"I add a new education")]
        public void WhenIAddANewEducation()
        {
            //Click on Add Education Tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='third']")).Click();
            Thread.Sleep(1500);
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[4]/div[1]/div[2]/div[1]/table[1]/thead[1]/tr[1]/th[6]/div[1]")).Click();

            //Add University Name
            Driver.driver.FindElement(By.XPath("//input[@placeholder='College/University Name']")).SendKeys("RMIT");

            //Add Degree Name
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Degree']")).SendKeys("MTECH");

            //Click on Country Of College
            Driver.driver.FindElement(By.XPath("//select[@name='country']")).Click();
            Thread.Sleep(1000);

            //Choose the college                             
            IWebElement coll = Driver.driver.FindElements(By.XPath("//select[@name='country']/option"))[10];
            coll.Click();

            //Click on year of graduation
            Driver.driver.FindElement(By.XPath("//select[@name='yearOfGraduation']")).Click();
            Thread.Sleep(1000);

            //Choose the year of graduation                             
            IWebElement  yea= Driver.driver.FindElements(By.XPath("//select[@name='yearOfGraduation']/option"))[2];
            yea.Click();

            Thread.Sleep(1000);

            //Click on Title of graduation
            Driver.driver.FindElement(By.XPath("//select[@name='title']")).Click();
            Thread.Sleep(1000);

            //Choose the Title of graduation                             
            IWebElement tle = Driver.driver.FindElements(By.XPath("//select[@name='title']/option"))[7];
            tle.Click();


            //Click on Add button
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[4]/div[1]/div[2]/div[1]/div[1]/div[3]/div[1]/input[1]")).Click();
        }
        
        [Then(@"that education should be displayed on my listings")]
        public void ThenThatEducationShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Education");

                Thread.Sleep(1000);
                string ExpectedValue = "MTECH";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[contains(text(),'MTECH')]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Education Sucessfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
