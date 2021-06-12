using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace com.automationpractice.Pages
{
    class SearchPage
    {
        private DSL dsl;

        public SearchPage(IWebDriver driver)
        {
            dsl = new DSL(driver);
        }


        public void setProduto(string textoSearch) 
        {
            dsl.Escrever("search_query_top", textoSearch); //pelo Id
        }


        public void clickBtnSearch()
        {
            dsl.ClicarBotaoSearch("submit_search");     //css= .button - search
        }


        public bool BuscaProdutoExiste()
        {
            return dsl.IsPresentProduto(".right-block .product-name"); //css elemento produto
        }

        public string obterMsn() 
        {
            return dsl.ObterTexto("p.alert.alert-warning");
        }

    }

}
