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
    class CreateAcc : IMetode
    {
        //confirmation form validate
        bool ImgSuccess { get; set; }

        //fill data form validate
        bool Submit { get; set; }
        public  void InitCreateDelAcc()
        {
            BlueColor("Test scenario: Create new profile");

            {
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

                    //Create profile
                    IWebElement createProfil = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/button"));

                    if (createProfil.Displayed)

                        GreenMessage("I see element Create new profile");
                    else
                        RedColor("I don't see element Create new profile!");

                    createProfil.Click();

                    Thread.Sleep(3000);

                    //Fill form

                    //Name element
                    IWebElement fillName = driver.FindElement(By.Id("profile-name"));

                    if (fillName.Displayed)

                        GreenMessage("I see element Name!");
                    else
                        RedColor("I don't see element Name!");

                    fillName.SendKeys("Danijel");

                    //Age element
                    IWebElement fillAge = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[2]/div/div[2]/label"));

                    if (fillAge.Displayed)

                        GreenMessage("I see element Age!");
                    else
                        RedColor("I don't see element Age!");

                    fillAge.Click();
                    Thread.Sleep(3000);

                    //Avatar               
                    bool staleElement = true;
                    while (staleElement)
                    {
                        try
                        {
                            IWebElement fillAvatar = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[3]/div/div[3]/label/div/img"));
                            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                            jse.ExecuteScript("arguments[0].click();", fillAvatar);

                            if (fillAvatar.Displayed)

                                GreenMessage("I see element Avatar!");
                            else
                                RedColor("I don't see element Avatar!");


                            staleElement = false;

                        }
                        catch (StaleElementReferenceException e)
                        {
                            WriteLine(e.Message);
                            staleElement = true;
                        }

                    }


                    //Submit (kreiraj profil)
                    IWebElement submit = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/button"));

                    if (submit.Displayed)

                        GreenMessage("I see element button create profile!");
                    else
                        RedColor("I don't see button create profile!");


                    submit.Click();
                    Thread.Sleep(3000);
                    //Prikaz card korisnika
                    IWebElement card = driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]/img"));
                    ImgSuccess = card.Displayed;
                    WriteLine();
                    driver.Quit();

                }

                catch (Exception e)
                {

                    WriteLine(e.Message);
                }
            }

        }

        public  void InitCreateDelAccHalfData()
        {
            BlueColor("Test scenario: Create new profile");
            
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

                    //Create profile
                    IWebElement createProfil = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/button"));

                    if (createProfil.Displayed)

                        GreenMessage("I see element Create new profile");
                    else
                        RedColor("I don't see element Create new profile!");

                    createProfil.Click();

                    Thread.Sleep(3000);
                    WriteLine();

                    //Fill form
                    //Name element
                    IWebElement fillName = driver.FindElement(By.Id("profile-name"));

                    if (fillName.Displayed)

                        GreenMessage("I see element Name!");
                    else
                        RedColor("I don't see element Name!");

                    fillName.SendKeys("");

                    //Submit (kreiraj profil)
                    IWebElement submit = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/button"));

                    submit.Click();                  
                  
                    if (!submit.Displayed)
                        GreenMessage("I see element confirmation form after no name input!");
                    else
                        RedColor("I don't see element confirmation form after no name input!");

                    fillName.SendKeys("Danijel");
                    submit.Click();

                    if (!submit.Displayed)
                        GreenMessage("I see element confirmation form after only name input!!");
                    else
                        RedColor("I don't see elementconfirmation form after only name input!");

                    //Age element
                    IWebElement fillAge = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/div[2]/div/div[2]/label"));

                    if (fillAge.Displayed)

                        GreenMessage("I see element Age!");
                    else
                        RedColor("I don't see element Age!");

                    fillAge.Click();
                    Thread.Sleep(3000);
                    submit.Click();

                    if (!submit.Displayed)
                        GreenMessage("I see element confirmation form after name input and age!!");
                    else
                        RedColor("I don't see element confirmation form after name input and age!");

                WriteLine();
                Submit = submit.Displayed;
                Thread.Sleep(5000);
                WriteLine();
                driver.Quit();
                }

                catch (Exception e)
                {

                    WriteLine(e.Message);
                }

        } 

        public void ResultsAll()
        {
            Yellow("Test case ID: 1");
            Yellow("Test case name: Create profile on all input data");

            if (ImgSuccess)
            {
                GreenMessage("Test passed");
            }

            else
            {
                RedColor("Test failed");
                
            }        

        }

        public void ResultsIncomplete()
        {
           Yellow("Test case ID: 2");
           Yellow("Test case name: Create profile on incomplete input data");

            if (Submit)
            {
                GreenMessage("Test passed");
            }

            else
            {
                RedColor("Test failed");

            }
        }

        public static void RedColor(string message)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine(message);
            ForegroundColor = ConsoleColor.White;
        }

        public static void GreenMessage(string message)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine(message);
            ForegroundColor = ConsoleColor.White;
        }


        public static void BlueColor(string message)
        {
            ForegroundColor = ConsoleColor.Blue;
            WriteLine(message);
            ForegroundColor = ConsoleColor.White;
        }

        public static void Yellow(string message) { 
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine(message);
            ForegroundColor = ConsoleColor.White;
        }
    }
}
