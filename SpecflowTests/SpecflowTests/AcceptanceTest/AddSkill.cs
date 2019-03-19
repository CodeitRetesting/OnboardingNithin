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
    public class AddSkillFeatureSteps
    {
        [Given(@"I clicked on the Skill tab under Profile page")]
        public void GivenIClickedOnTheSkillTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

        }

        [When(@"I add a new skill")]
        public void WhenIAddANewSkill()
        {
            //Click on Skills Tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='second']")).Click();
           
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//div[@class='ui teal button']")).Click();

            //Add Skill
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']")).SendKeys("Tester");
            
            //Click on Skill Level
            Driver.driver.FindElement(By.XPath("//select[@name='level']")).Click();
            Thread.Sleep(1000);

            //Choose the Skill level                             
            IWebElement L = Driver.driver.FindElements(By.XPath("//select[@name='level']/option"))[2];
            L.Click();


            //Click on Add button
            Thread.Sleep(1000);
           Driver.driver.FindElement(By.XPath("//input[@type='button']")).Click();

        }

        [Then(@"that skill should be displayed on my listings")]
        public void ThenThatSkillShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Tester";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[contains(text(),'Tester')]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Sucessfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
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
