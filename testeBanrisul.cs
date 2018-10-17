using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class testBanrisul
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://automationpractice.com/index.php?";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TestBanrisul()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='More'])[2]/following::img[1]")).Click();
            driver.FindElement(By.Id("group_1")).Click();
            new SelectElement(driver.FindElement(By.Id("group_1"))).SelectByText("M");
            driver.FindElement(By.Id("group_1")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='M'])[1]/following::span[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='$28.00'])[2]/following::span[3]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='$26.00'])[6]/following::span[1]")).Click();
            driver.FindElement(By.Id("email_create")).Click();
            driver.FindElement(By.Id("email_create")).Clear();
            driver.FindElement(By.Id("email_create")).SendKeys("dyeni.souza@gmail.com");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Email address'])[1]/following::span[1]")).Click();
            driver.FindElement(By.Id("id_gender2")).Click();
            driver.FindElement(By.Id("customer_firstname")).Click();
            driver.FindElement(By.Id("customer_firstname")).Clear();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Dyeniffer");
            driver.FindElement(By.Id("customer_lastname")).Clear();
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Souza");
            driver.FindElement(By.Id("passwd")).Clear();
            driver.FindElement(By.Id("passwd")).SendKeys("testebanrisul");
            driver.FindElement(By.Id("days")).Click();
            new SelectElement(driver.FindElement(By.Id("days"))).SelectByText("regexp:16\\s+");
            driver.FindElement(By.Id("days")).Click();
            driver.FindElement(By.Id("months")).Click();
            new SelectElement(driver.FindElement(By.Id("months"))).SelectByText("regexp:August\\s");
            driver.FindElement(By.Id("months")).Click();
            driver.FindElement(By.Id("years")).Click();
            new SelectElement(driver.FindElement(By.Id("years"))).SelectByText("regexp:1994\\s+");
            driver.FindElement(By.Id("years")).Click();
            driver.FindElement(By.Id("company")).Click();
            driver.FindElement(By.Id("company")).Clear();
            driver.FindElement(By.Id("company")).SendKeys("ZAP");
            driver.FindElement(By.Id("address1")).Clear();
            driver.FindElement(By.Id("address1")).SendKeys("Padre Cacique");
            driver.FindElement(By.Id("city")).Click();
            driver.FindElement(By.Id("city")).Clear();
            driver.FindElement(By.Id("city")).SendKeys("Porto Alegre");
            driver.FindElement(By.Id("id_state")).Click();
            new SelectElement(driver.FindElement(By.Id("id_state"))).SelectByText("Washington");
            driver.FindElement(By.Id("id_state")).Click();
            driver.FindElement(By.Id("postcode")).Click();
            driver.FindElement(By.Id("postcode")).Clear();
            driver.FindElement(By.Id("postcode")).SendKeys("83821");
            driver.FindElement(By.Id("other")).Click();
            driver.FindElement(By.Id("other")).Clear();
            driver.FindElement(By.Id("other")).SendKeys("teste");
            driver.FindElement(By.Id("phone_mobile")).Click();
            driver.FindElement(By.Id("phone_mobile")).Clear();
            driver.FindElement(By.Id("phone_mobile")).SendKeys("51992991123");
            driver.FindElement(By.Id("alias")).Click();
            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys("casa");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='DNI / NIF / NIE'])[1]/following::span[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='If you would like to add a comment about your order, please write it in the field below.'])[1]/following::span[1]")).Click();
            driver.FindElement(By.Id("cgv")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='(Read the Terms of Service)'])[1]/following::span[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='(order processing will be longer)'])[1]/following::span[1]")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Dollar'])[1]/following::span[1]")).Click();
            driver.FindElement(By.LinkText("Back to orders")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
