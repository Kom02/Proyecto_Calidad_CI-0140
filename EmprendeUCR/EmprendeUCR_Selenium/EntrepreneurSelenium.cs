using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using System.Threading.Tasks;

namespace EmprendeUCR_Selenium
{
    [TestClass]
    public class EntrepreneurSelenium
    {
        IWebDriver driver;
        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
                driver.Quit();
        }
        [Fact]
        public async Task WebAppStartChrome()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AcceptInsecureCertificates = true;
            ///Arrange
            /// Crea el driver de Chrome
            driver = new ChromeDriver();
            ///Arrange
            /// Pone la pantalla en full screen
            driver.Manage().Window.Maximize();
            ///Act
            /// Se va a la URL de la aplicacion
            driver.Url = "http://localhost:44171/";
            await Task.Delay(5000);
            ///Assert
            Xunit.Assert.Equal(driver.FindElement(By.XPath("/html/body/app/div/div[1]/div/div/div[1]/a")).Text, "EMPRENDEUCR");
        }
        [Fact]
        public async Task LoginTestAsync()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AcceptInsecureCertificates = true;
            ///Arrange
            /// Crea el driver de Chrome
            driver = new ChromeDriver();
            ///Arrange
            /// Pone la pantalla en full screen
            driver.Manage().Window.Maximize();
            ///Act
            /// Se va a la URL de la aplicacion
            driver.Url = "http://localhost:44171/";
            await Task.Delay(5000);
            // Enter the login page
            driver.FindElement(By.XPath("//button[contains(.,'Iniciar Sesión')]")).Click();

            await Task.Delay(2000);

            driver.FindElement(By.CssSelector(".marginElements:nth-child(1) > #exampleInputEmail1")).Click();
            await Task.Delay(2000);

            driver.FindElement(By.CssSelector(".marginElements:nth-child(1) > #exampleInputEmail1")).SendKeys("dario.matamo18@gmail.com");
            await Task.Delay(2000);

            driver.FindElement(By.XPath("(//input[@id='exampleInputEmail1'])[2]")).Click();
            await Task.Delay(2000);
            driver.FindElement(By.XPath("(//input[@id='exampleInputEmail1'])[2]")).SendKeys("Dario123");
            await Task.Delay(2000);

            driver.FindElement(By.XPath("//input[@id='flexRadioDefault2']")).Click();
            await Task.Delay(2000);

            driver.FindElement(By.XPath("//button[contains(.,'Ingresar')]")).Click();

        }
        [Fact]
        public async Task NavigateViewOffer()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AcceptInsecureCertificates = true;
            ///Arrange
            /// Crea el driver de Chrome
            driver = new ChromeDriver();
            ///Arrange
            /// Pone la pantalla en full screen
            driver.Manage().Window.Maximize();
            ///Act
            /// Se va a la URL de la aplicacion
            driver.Url = "http://localhost:44171/";
            await Task.Delay(5000);
            // Enter the login page
            driver.FindElement(By.XPath("//button[contains(.,'Iniciar Sesión')]")).Click();

            await Task.Delay(2000);

            driver.FindElement(By.CssSelector(".marginElements:nth-child(1) > #exampleInputEmail1")).Click();
            await Task.Delay(2000);

            driver.FindElement(By.CssSelector(".marginElements:nth-child(1) > #exampleInputEmail1")).SendKeys("dario.matamo18@gmail.com");
            await Task.Delay(2000);

            driver.FindElement(By.XPath("(//input[@id='exampleInputEmail1'])[2]")).Click();
            await Task.Delay(2000);
            driver.FindElement(By.XPath("(//input[@id='exampleInputEmail1'])[2]")).SendKeys("Dario123");
            await Task.Delay(2000);

            driver.FindElement(By.XPath("//input[@id='flexRadioDefault2']")).Click();
            await Task.Delay(2000);

            driver.FindElement(By.XPath("//button[contains(.,'Ingresar')]")).Click();
            await Task.Delay(5000);
            driver.FindElement(By.XPath("//li[9]/a")).Click();
            }
        [Fact]
        public async Task NavigateViewAlliance()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AcceptInsecureCertificates = true;
            ///Arrange
            /// Crea el driver de Chrome
            driver = new ChromeDriver();
            ///Arrange
            /// Pone la pantalla en full screen
            driver.Manage().Window.Maximize();
            ///Act
            /// Se va a la URL de la aplicacion
            driver.Url = "http://localhost:44171/";
            await Task.Delay(5000);
            // Enter the login page
            driver.FindElement(By.XPath("//button[contains(.,'Iniciar Sesión')]")).Click();

            await Task.Delay(2000);

            driver.FindElement(By.CssSelector(".marginElements:nth-child(1) > #exampleInputEmail1")).Click();
            await Task.Delay(2000);

            driver.FindElement(By.CssSelector(".marginElements:nth-child(1) > #exampleInputEmail1")).SendKeys("dario.matamo18@gmail.com");
            await Task.Delay(2000);

            driver.FindElement(By.XPath("(//input[@id='exampleInputEmail1'])[2]")).Click();
            await Task.Delay(2000);
            driver.FindElement(By.XPath("(//input[@id='exampleInputEmail1'])[2]")).SendKeys("Dario123");
            await Task.Delay(2000);

            driver.FindElement(By.XPath("//input[@id='flexRadioDefault2']")).Click();
            await Task.Delay(2000);

            driver.FindElement(By.XPath("//button[contains(.,'Ingresar')]")).Click();
            await Task.Delay(5000);
            //Here the user is already logged in
            driver.FindElement(By.XPath("//a[contains(@href, '/My_Alliance')]")).Click();
            
        }

    }
}