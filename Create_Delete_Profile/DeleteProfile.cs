using System.Threading.Tasks;
using static System.Console;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;
using System.Threading;
using Create_Delete_Profile_test.Interfaces;
using System;

namespace Create_Delete_Profile_test.Create_Delete_Profile
{
    class DeleteProfile : IMetode
    {
        //profile page check
        public bool Profile{get; set;}
       //Here I left this two methods in case of the future developments testing of new feature 
       //(example delete only input data, not hole profile)
        public void InitCreateDelAccHalfData() { }
        public void ResultsIncomplete() { }

        public void InitCreateDelAcc()
        {
            CreateAcc.BlueColor("Test scenario: Delete profile");

            try
            {
                Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"C:\Selenium\chromedriver.exe");
                ChromeOptions options = new();
                options.AddArguments("start-maximized");
                options.AddArguments("disable-infobars");
                options.AddArguments("--disable-extensions");
                options.AddArguments("--disable-gpu");
                options.AddArguments("--disable-dev-shm-usage");
                options.AddArguments("--no-sandbox");
                IWebDriver driver = new ChromeDriver("c:/Selenium", options);

                driver.Navigate().GoToUrl("https://qa-interview.united.cloud/login");
                Clear();

                IWebElement element = driver.FindElement(By.ClassName("form"));


                element.FindElement(By.Id("username")).SendKeys("danijel.tomic");
                element.FindElement(By.Id("password")).SendKeys("Lozinka123");
                element.FindElement(By.XPath("/html/body/div/div/div/div/div[2]/form/button")).Click();

                Thread.Sleep(3000);

                IWebElement elementChoosePro = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[2]/div"));

                if (elementChoosePro.Displayed)

                    CreateAcc.GreenMessage("I see element delete!");
                else
                    CreateAcc.RedColor("I don't see element delete!");

                elementChoosePro.Click();
                Thread.Sleep(3000);

                IWebElement elementDeletePro = driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[2]/button[1]"));
                Profile = elementDeletePro.Displayed;

                IJavaScriptExecutor jse =(IJavaScriptExecutor) driver;
                jse.ExecuteScript("arguments[0].click();", elementDeletePro);
                
                Thread.Sleep(3000);


                IWebElement elementFamily = driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div/div/img"));
                if (elementFamily.Displayed)

                    CreateAcc.GreenMessage("I am not on profile page!");
                else
                    CreateAcc.RedColor("I am on profile page!");
                

                Thread.Sleep(3000);

                driver.Navigate().Refresh();
                WriteLine();
                driver.Quit();

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
              
            } }

        public void ResultsAll() {

            CreateAcc.Yellow("Test case ID: 3");
            CreateAcc.Yellow("Test case name: Delete profile");

            if (Profile)
            {
                CreateAcc.GreenMessage("Test passed");
            }

            else
            {
                CreateAcc.RedColor("Test failed");

            }
        }
    }
}
