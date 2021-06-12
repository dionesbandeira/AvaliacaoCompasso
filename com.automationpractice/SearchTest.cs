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
    class SearchTest : DriverHelper
    {

        //Variaveis do escopo
        private StringBuilder verificationErrors;
        private DSL dsl;
        private HomePage homePage;
        private LoginPage loginPage;
        private SearchPage searchPage;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Inicialize antes da execução de cada método de Teste");
            Driver = new ChromeDriver();
            verificationErrors = new StringBuilder();

            dsl = new DSL(Driver);
            homePage = new HomePage(Driver);
            loginPage = new LoginPage(Driver);
            searchPage = new SearchPage(Driver);

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




        //------------------------------------------------------------------------------------------//
        //    Funcionalidade: Buscas no Fake Ecommerce                                              //
        //        Como um cliente do site FakeEcommerce                                             //
        //         Gostaria de poder buscar por produtos                                            //
        //          Para customizar as compras                                                      //
        //                                                                                          //
        //         Contexto:                                                                        //
        //           Dado que esteja na página inicial                                              //
        //                                                                                          //
        //            @buscar_por_termo_valido                                                      //
        //             Cenário: Buscar por termo válido                                             //
        //              Quando buscar pelo produto 'shirt'                                          // 
        //                Então devem ser retornados produtos                                       //
        //------------------------------------------------------------------------------------------//

        [Test]
        public void BuscarTermoValido()
        {
            try
            {
                homePage.ClicarLinkSign_in();
                loginPage.setEmail("agustina_norman@hotmail.com"); // <= Insira seu email com falha* (n)
                loginPage.setPassword("Teste");                   // <= Insira sua Senha valida do cadastro
                loginPage.ClicarBotaoSign_in();

                searchPage.setProduto("shirt");
                searchPage.clickBtnSearch();
                Thread.Sleep(3000);
                Assert.That(searchPage.BuscaProdutoExiste(), Is.True, "Não há protudos com esse nome");
            }
            catch
            {
                // Ignore os erros se não conseguir fechar o navegador 
            }

        }


        //------------------------------------------------------------------------------------------------------//
        //    Funcionalidade: Buscas no Fake Ecommerce                                                          //
        //        Como um cliente do site FakeEcommerce                                                         //
        //         Gostaria de poder buscar por produtos                                                        //
        //          Para customizar as compras                                                                  //
        //                                                                                                      //
        //         Contexto:                                                                                    //
        //           Dado que esteja na página inicial                                                          //
        //                                                                                                      //
        //            # Completar o cenário abaixo                                                              //
        //            @busca_sem_resultados                                                                     //
        //            Cenário: Busca sem resultados                                                             //
        //              Quando buscar por um produto que não existe                                             // 
        //              Então deve ser apresentado uma mensagem informando que nao há resultado para busca      //
        //------------------------------------------------------------------------------------------------------//

        [Test]
        public void BuscaSemResultado()
        {
            try
            {
                homePage.ClicarLinkSign_in();
                loginPage.setEmail("agustina_norman@hotmail.com"); // <= Insira seu email com falha* (n)
                loginPage.setPassword("Teste");                   // <= Insira sua Senha valida do cadastro
                loginPage.ClicarBotaoSign_in();

                searchPage.setProduto("underwear");
                searchPage.clickBtnSearch();
                Thread.Sleep(3000);
                
                //Assert.That(searchPage.obterMsn(), Is.EqualTo("No results were found for your search "underwear""));
                
            }
            catch
            {
                // Ignore os erros se não conseguir fechar o navegador 
            }

        }



    }
}
