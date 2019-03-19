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
    public class AddCertificationSteps
    {
        [Given(@"I clicked on the certification tab under Profile page")]
        public void GivenIClickedOnTheCertificationTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Certification tab
            Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[1]/a[4]")).Click();
        }
        
        [When(@"I add a new certification")]
        public void WhenIAddANewCertification()
        {
            

            //Click on Add New button
            Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[5]/div[1]/div[2]/div[1]/table[1]/thead[1]/tr[1]/th[4]/div[1]")).Click();

            //Add Certification or Award Text Box Name
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Certificate or Award']")).SendKeys("CERT");

            //Add Certification from Text box
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Certified From (e.g. Adobe)']")).SendKeys("ISTQB");

            //Click on Year obtained
            Driver.driver.FindElement(By.XPath("//select[@name='certificationYear']")).Click();
            Thread.Sleep(1000);

            //Choose the Year                           
            IWebElement c1 = Driver.driver.FindElements(By.XPath("//select[@name='certificationYear']/option"))[2];
            c1.Click();

            //Click on Add button
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[5]/div[1]/div[2]/div[1]/div[1]/div[3]/input[1]")).Click();
        }
        
        [Then(@"that certification should be displayed on my listings")]
        public void ThenThatCertificationShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Certification");

                Thread.Sleep(1000);
                string ExpectedValue = "ISTQB";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[contains(text(),'ISTQB')]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Certification Sucessfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificationAdded");
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
