using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SeleniumTest
{
    public class LoginTest
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
        public void UserLogin_TakesToHomePage()
        {
            //hitta elementen att testa för att logga in 

            driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();


            // checka ifall vi kommit in till sidan /inventory 
            Assert.IsTrue(driver.Url.Contains("inventory"));
            
        }
        [TearDown]
        public void Teardown()
        {
            driver.Quit();  
            driver.Dispose(); 
        }

    }
}
