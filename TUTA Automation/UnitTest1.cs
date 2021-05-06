using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TUTA_Automation
{
    public class Tests
    {
        private IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            
            driver.Url = "http://automationpractice.com/index.php";
            
        }

        [Test]
        public void TestLogin()

        {
            driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div:nth-child(1) > a")).Click();

            driver.FindElement(By.Id("email")).SendKeys("Ponasmakaronas@tuta.com");

            driver.FindElement(By.Id("passwd")).SendKeys("qweqwe");

            driver.FindElement(By.Id("SubmitLogin")).Click();

            IWebElement accountInfo = driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div:nth-child(1) > a"));

            Assert.AreEqual("Ponas Makaronas", accountInfo.Text, "Account info is Incorrect");

            driver.FindElement(By.CssSelector("#block_top_menu > ul > li:nth-child(3) > a")).Click();

            driver.FindElement(By.CssSelector("#center_column > ul > li > div > div.right-block > h5 > a")).Click();

            IWebElement TshirtName = driver.FindElement(By.CssSelector("#center_column > div > div > div.pb-center-column.col-xs-12.col-sm-4 > h1"));

            Assert.AreEqual("Faded Short Sleeve T-shirts", TshirtName.Text, "Incorrect Item");

            driver.FindElement(By.CssSelector("#add_to_cart > button > span")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a")).Click();

            driver.FindElement(By.CssSelector("#center_column > p.cart_navigation.clearfix > a.button.btn.btn-default.standard-checkout.button-medium")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.CssSelector("#center_column > form > p > button")).Click();

            driver.FindElement(By.CssSelector("#cgv")).Click();

            driver.FindElement(By.CssSelector("#form > p > button")).Click();

            driver.FindElement(By.CssSelector("#HOOK_PAYMENT > div:nth-child(2) > div > p > a")).Click();

            driver.FindElement(By.CssSelector("#cart_navigation > button")).Click();

            IWebElement confirmationText = driver.FindElement(By.CssSelector("#center_column > p.alert.alert-success"));

            Assert.AreEqual("Your order on My Store is complete.", confirmationText.Text, "Order is incomplete");

        }

        [TearDown]
        public void CloseBrowse()
        {
            //driver.Close();
        }
    }
}