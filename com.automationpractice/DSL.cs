using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Essentials;

namespace com.automationpractice
{
    class DSL
    {
         //DSL é uma linguagem propria criada especificamente para resolver um problema,
        //criando métodos bens discritivos que facilitam nossa interação com os métodos do Selenium. (CustomControl)

        private IWebDriver _Driver;

        //Contrutor recebendo o driver
        public DSL(IWebDriver driver)
        {
            this._Driver = driver;
        }


        /********* TEXTFIELD E TEXTAREA ************/

        public void Escrever(By by, String texto)
        {
            _Driver.FindElement(by).Clear();
            _Driver.FindElement(by).SendKeys(texto);
        }

        public void Escrever(String id_campo, String texto)
        {
            Escrever(By.Id(id_campo), texto);
            //Escrever(By.XPath(id_campo), texto);
        }

        public String ObterValorCampo(String id_campo)
        {
            return _Driver.FindElement(By.Id(id_campo)).GetAttribute("Value");
        }




        /********* BOTÃO ************/

        public void ClicarBotao(By by)
        {
            _Driver.FindElement(by).Click();
        }

        public void ClicarBotao(String id_botao)
        {
            ClicarBotao(By.Id(id_botao));
        }

        public void ClicarBotaoSearch(String name_botao) 
        {
            ClicarBotao(By.Name(name_botao));
        }

        public String ObterValueElemento(String id_elemento)
        {
            return _Driver.FindElement(By.CssSelector(id_elemento)).GetAttribute("value");
        }



        /********** LINK *************/

        public void ClicarLink(String link)
        {

            _Driver.FindElement(By.LinkText(link)).Click();
        }

        public bool IsLinkExiste(String id_link)
        {
            return _Driver.FindElement(By.LinkText(id_link)).Displayed;  //True ou False
        }

        public bool IsPresentProduto(String css_Produto)
        {
            return _Driver.FindElement(By.CssSelector(css_Produto)).Displayed;  //True ou False
        }

        /********* TEXTOS ************/

        public String ObterTexto(By by)
        {
            return _Driver.FindElement(by).Text;
        }

        public String ObterTexto(String cssSeletor_elemento)
        {
            return ObterTexto(By.CssSelector(cssSeletor_elemento));
        }

        public String ObterTituloAba()
        {
            return _Driver.Title;
        }












    }


}
