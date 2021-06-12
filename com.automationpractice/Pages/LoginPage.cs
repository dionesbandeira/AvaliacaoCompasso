using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace com.automationpractice.Pages
{
    public class LoginPage
    {

        private DSL dsl;

        public LoginPage(IWebDriver driver)
        {
            dsl = new DSL(driver);
        }



        public void setEmail(string textoEmail)
        {
            dsl.Escrever("email", textoEmail);
        }

        public void setPassword(string textoPassword)
        {
            dsl.Escrever("passwd", textoPassword);
        }

        public void ClicarBotaoSign_in()
        {
            dsl.ClicarBotao("SubmitLogin");        //("//button[@id='SubmitLogin']/span"); 
        }


        public string obterTextoSucessologin()
        {
            return dsl.ObterTexto(".info-account");
        }


        public string obterTextoErroLogin()
        {
            return dsl.ObterTexto("ol > li");
        }

        public bool obterNomeUsuario()
        {

            if (dsl.ObterTexto(".account > span") == "Diones Bandeira" || dsl.ObterTexto(".account > span") == "DIONES BANDEIRA") 
            { return true; }
            else { return false; }

            //  t(By.CssSelector(".account > span")).Text == "Diones Bandeira");
        }



    }
}
