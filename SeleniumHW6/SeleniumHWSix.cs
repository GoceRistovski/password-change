using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHWSix
{
    [TestFixture]

    public class HWSix
    {
        IWebDriver Driver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            Driver.Manage().Window.Maximize();
        }
        [Test]
        public void DomasnaLozinka()
        {



            Driver.Navigate().GoToUrl("http://18.156.17.83:9095/");
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            IWebElement Najava = Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("span[translate=	'global.menu.account.login']")));
            Najava.Click();

            IWebElement KorisnickoIme = Driver.FindElement(By.Id("username"));
            KorisnickoIme.Clear();
            KorisnickoIme.SendKeys("ristovski.goce@gmail.com");

            IWebElement Lozinka = Driver.FindElement(By.Id("password"));
            Lozinka.Clear();
            Lozinka.SendKeys("Pass123");

            IWebElement NajaviSe = Driver.FindElement(By.CssSelector("button[translate='login.form.button']"));
            NajaviSe.Click();

            IWebElement Najavuvanje = Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("nav[role='navigation']")));

            IWebElement MojProfil = Driver.FindElement(By.CssSelector("span[translate='provider.myAccount']"));
            MojProfil.Click();

            IWebElement Changepassword = Driver.FindElement(By.ClassName("account-screen__password-update"));
            Changepassword.Click();

            IWebElement NovaLozinka = Driver.FindElement(By.Id("password"));
            NovaLozinka.Clear();
            NovaLozinka.SendKeys("q!w2e3r");

            IWebElement PotvrdaNaNovataLozinka = Driver.FindElement(By.Id("confirmPassword"));
            PotvrdaNaNovataLozinka.Clear();
            PotvrdaNaNovataLozinka.SendKeys("q!w2e3r");

            List<IWebElement> panel = Driver.FindElements(By.CssSelector("div[Id='strength']")).ToList();
            IWebElement jacinaNaLozinkata = panel.First(el => el.Text.Contains("Јачина на лозинката"));

            List<IWebElement> panel2 = Driver.FindElements(By.CssSelector("li[style='background-color: rgb(153, 255, 0);']")).ToList();
            IWebElement jacinaNaLozinkataElement = panel2.Last();

            Assert.IsTrue(jacinaNaLozinkataElement.Displayed);

            IWebElement Zacuvaj = Driver.FindElement(By.CssSelector("button[type='submit']"));
            Zacuvaj.Click();

            Wait.Until(ExpectedConditions.ElementExists(By.CssSelector(("div[translate = 'password.messages.success']"))));




            IWebElement OdjaviSe = Driver.FindElement(By.CssSelector("span[translate='global.menu.account.logout']"));
            OdjaviSe.Click();

            Driver.Navigate().GoToUrl("http://18.156.17.83:9095/");

            IWebElement Najava1 = Driver.FindElement(By.CssSelector("span[translate='global.menu.account.login']"));
            Najava1.Click();

            IWebElement KorisnickoIme1 = Driver.FindElement(By.Id("username"));
            KorisnickoIme1.Clear();
            KorisnickoIme1.SendKeys("ristovski.goce@gmail.com");

            IWebElement Lozinka1 = Driver.FindElement(By.Id("password"));
            Lozinka1.Clear();
            Lozinka1.SendKeys("q!w2e3r");

            IWebElement NajaviSe1 = Driver.FindElement(By.CssSelector("button[translate='login.form.button']"));
            NajaviSe1.Click();


            IWebElement WelcomeMessage = Driver.FindElement(By.CssSelector("h2[translate='provider.welcomeMessage']"));
            Assert.AreEqual("Добредојдовте на cargodom.com", WelcomeMessage.Text);

            IWebElement OdjaviSe2 = Driver.FindElement(By.CssSelector("span[translate='global.menu.account.logout']"));
            OdjaviSe2.Click();

        }

        [TearDown]
        public void Reset()
        {

            Driver.Navigate().GoToUrl("http://18.156.17.83:9095/");
            WebDriverWait Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            IWebElement Najava = Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("span[translate=	'global.menu.account.login']")));
            Najava.Click();

            IWebElement KorisnickoIme = Driver.FindElement(By.Id("username"));
            KorisnickoIme.Clear();
            KorisnickoIme.SendKeys("ristovski.goce@gmail.com");

            IWebElement Lozinka = Driver.FindElement(By.Id("password"));
            Lozinka.Clear();
            Lozinka.SendKeys("q!w2e3r");

            IWebElement NajaviSe = Driver.FindElement(By.CssSelector("button[translate='login.form.button']"));
            NajaviSe.Click();

            IWebElement Najavuvanje = Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("nav[role='navigation']")));

            IWebElement MojProfil = Driver.FindElement(By.CssSelector("span[translate='provider.myAccount']"));
            MojProfil.Click();

            IWebElement Changepassword = Driver.FindElement(By.ClassName("account-screen__password-update"));
            Changepassword.Click();

            IWebElement NovaLozinka1 = Driver.FindElement(By.Id("password"));
            NovaLozinka1.Clear();
            NovaLozinka1.SendKeys("Pass123");

            IWebElement PotvrdaNaNovataLozinka1 = Driver.FindElement(By.Id("confirmPassword"));
            PotvrdaNaNovataLozinka1.Clear();
            PotvrdaNaNovataLozinka1.SendKeys("Pass123");

            IWebElement Zacuvaj = Driver.FindElement(By.CssSelector("button[type='submit']"));
            Zacuvaj.Click();

            IWebElement OdjaviSe1 = Driver.FindElement(By.CssSelector("span[translate='global.menu.account.logout']"));
            OdjaviSe1.Click();

            Driver.Close();
            Driver.Dispose();

        }
    }
}
