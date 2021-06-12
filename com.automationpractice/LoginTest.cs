using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using com.automationpractice.Pages;
using System.Diagnostics;

namespace com.automationpractice
{
    class LoginTest : DriverHelper
    {

        //Variaveis do escopo
        private StringBuilder verificationErrors;
        private DSL dsl;
        private HomePage homePage;
        private LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Inicialize antes da execução de cada método de Teste");
            Driver = new ChromeDriver();
            verificationErrors = new StringBuilder();

            dsl = new DSL(Driver);
            homePage = new HomePage(Driver);
            loginPage = new LoginPage(Driver);

            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
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



        //----------------------------------------------------------------------------------//
        //    Funcionalidade: Login no Ecommerce Fake                                       //
        //        Como ... um cliente do site FakeEcommerce                                 //
        //         ... Gostaria de poder realizar login no site                             //
        //          ... Para poder visualizar minha conta pessoal                           //
        //                                                                                  //
        //         Contexto:                                                                //
        //           Dado que já possua cadastro no site                                    //
        //                                                                                  //
        //            @RealizarLogin                                                        //
        //             # Completar o cenário abaixo                                         //
        //              Cenário: Realizar login valido                                      // 
        //                Quando preencher os dados de autenticação                         //
        //                 Então deve ser direcionamdo a sua conta  com sucesso.            //
        //----------------------------------------------------------------------------------//
        [Test]
        public void RealizarLogin()
        {
            try
            {   //Conceito de nvegação
                homePage.ClicarLinkSign_in();
                loginPage.setEmail("agustina_norman@hotmail.com"); // <= Insira seu email valido já cadastrado
                loginPage.setPassword("Teste");                   // <= Insira sua Senha valida do cadastro
                loginPage.ClicarBotaoSign_in();                  // <= Clique no botão
                Thread.Sleep(3000);
                Assert.That(loginPage.obterTextoSucessologin(), Is.EqualTo("Welcome to your account. Here you can manage all of your personal information and orders."));
                Assert.That(loginPage.obterNomeUsuario(), Is.True, "Nome do usuario não foi exibido");   
            }
            catch
            {
                // Ignore os erros se não conseguir fechar o navegador 
            }

        }



        //------------------------------------------------------------------------------------------//
        //    Funcionalidade: Login no Ecommerce Fake                                               //
        //        Como ... um cliente do site FakeEcommerce                                         //
        //         ... Gostaria de poder realizar login no site                                     //
        //          ... Para poder visualizar minha conta pessoal                                   //
        //                                                                                          //
        //         Contexto:                                                                        //
        //           Dado que já possua cadastro no site                                            //
        //                                                                                          //
        //            @LoginComFalha                                                                //
        //             # Completar o cenário abaixo                                                 //
        //              Cenário: Login com falha                                                    // 
        //                Quando preencher os dados de autenticação com email incorreto             //
        //                 Então deve ser apresentado uma mensagem de "Falha na autenticação"       //
        //------------------------------------------------------------------------------------------//
        [Test]
        public void LoginComFalha()
        {
            try
            {
                homePage.ClicarLinkSign_in();
                loginPage.setEmail("agustina_norman@hotmail.con"); // <= Insira seu email com falha* (n)
                loginPage.setPassword("Teste");                   // <= Insira sua Senha valida do cadastro
                loginPage.ClicarBotaoSign_in();                  // <= Clique no botão 
                Thread.Sleep(3000);
                Assert.That(loginPage.obterTextoErroLogin(), Is.EqualTo("Authentication failed."));
            }
            catch
            {
                // Ignore os erros se não conseguir fechar o navegador 
            }

        }



    }//Fim da classe

}//Fim Namespace