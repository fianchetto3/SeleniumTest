using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace SeleniumTest
    {


        public class LoginFailPasswordTest
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
            public void UserWithWrongPassword()
            {
                //hitta elementen att testa för att logga in 

                driver.FindElement(By.Id("user-name")).SendKeys("standard_user"); 
                driver.FindElement(By.Id("password")).SendKeys("secret_sauces"); // fel lösenord
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

}
