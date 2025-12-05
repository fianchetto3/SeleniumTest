using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{

    
    public class LoginFailUserNameTest
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void UserWithWrongUsername()
        {
            //hitta elementen att testa för att logga in 

            driver.FindElement(By.Id("user-name")).SendKeys("standard_users"); // fel användarnamn
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();
          
            // hämta elementet för error boxen som kommer fram när man failar en login
            var error = driver.FindElement(By.CssSelector("[data-test='error']"));

            // is true ifall boxen finns på sidan
            Assert.IsTrue(error.Displayed);
        }
        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
