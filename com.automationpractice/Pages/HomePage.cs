using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace com.automationpractice.Pages
{
    public class HomePage
    {
        private DSL dsl;
        IWebDriver _Driver;

        public HomePage(IWebDriver driver)
        {
            dsl = new DSL(driver);
        }


        public string obterTituloBrowser()
        {
            return dsl.ObterTituloAba();
        }


        public void ClicarLinkSign_in()
        {
            dsl.ClicarLink("Sign in");   //("//button[@id='SubmitLogin']/span"); 
        }

        public bool LinkLogin()
        {
            return dsl.IsLinkExiste("Sign in");  //=> lnkLogin.Displayed;
        }


        public string TextVisivelCabecalho() 
        {
            return dsl.ObterTexto(".page-heading");
        }


    }
}
