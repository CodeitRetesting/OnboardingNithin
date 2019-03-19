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
    public class AddDescriptionSteps
    {
        [Given(@"I clicked on the description tab under Profile page")]
        public void GivenIClickedOnTheDescriptionTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Description tab
            Driver.driver.FindElement(By.XPath("//h3[@class='ui dividing header']//i[@class='outline write icon']")).Click();
        }
        
        [When(@"I add a new description")]
        public void WhenIAddANewDescription()
        {
            //Add Descriptionn 
            Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/form[1]/div[1]/div[1]/div[2]/div[1]/textarea[1]")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/form[1]/div[1]/div[1]/div[2]/div[1]/textarea[1]")).Clear();

            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/form[1]/div[1]/div[1]/div[2]/div[1]/textarea[1]")).SendKeys("HI IM TESTER");
            //Click on Save button
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/div[1]/div[1]/form[1]/div[1]/div[1]/div[2]/button[1]")).Click();
        }
        
        [Then(@"that description should be displayed on my listings")]
        public void ThenThatDescriptionShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Description");

                Thread.Sleep(1000);
                string ExpectedValue = "HI IM TESTER";
                string ActualValue = Driver.driver.FindElement(By.XPath("//span[contains(text(),'HI IM TESTER')]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue.Equals(ActualValue))
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Description Sucessfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "DescriptionAdded");
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
