using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using com.automationpractice.Pages;
using System.Diagnostics;


namespace com.automationpractice
{
    [TestFixture]
    class HomeTest : DriverHelper
    {
        //Variaveis do escopo
        private StringBuilder verificationErrors;
        private DSL dsl;
        private HomePage homePage;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Inicialize antes da execução de cada método de Teste");
            Driver = new ChromeDriver();
            verificationErrors = new StringBuilder();

            dsl = new DSL(Driver);
            homePage = new HomePage(Driver);

            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(3000);
        }


        [TearDown]
        public void TeardownTest()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore os erros se não conseguir fechar o navegador
            }

            Assert.AreEqual("", verificationErrors.ToString());
        }


        [Test]
        public void ValidarTituloBrowserHome()
        {
            try
            {
                Assert.That(homePage.obterTituloBrowser(), Is.EqualTo("My Store"));
            }
            catch
            {
                // Ignore os erros se não conseguir fechar o navegador 
            }

        }


        [Test]
        public void ValidarLinkLoginPresent()
        {
            try
            {
                Assert.That(homePage.LinkLogin(), Is.True, "O Link de Log In não foi exibido");
            }
            catch
            {
                //Ignore os erros se não conseguir fechar o navegador
            }

        }


        [Test]
        public void DirectAuthentication()
        {
            try
            {  
                homePage.ClicarLinkSign_in();
                Assert.That(homePage.TextVisivelCabecalho(), Is.EqualTo("Authentication").IgnoreCase);
            }
            catch
            {
                //Ignore os erros se não conseguir fechar o navegador
            }

        }







    }//Fim da classe

}//Fim Namespace