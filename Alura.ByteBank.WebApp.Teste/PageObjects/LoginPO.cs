using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Teste.PageObjects
{
    public class LoginPO
    {
        private IWebDriver driver;
        private By campoEmail;
        private By campoSenha;
        private By btnLogar;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            this.campoEmail = By.Id("Email");
            this.campoSenha = By.Id("Senha");
            this.btnLogar = By.Id("btn-logar");
        }

        public void Navegar(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void PreencherCampos(string email, string senha)
        {
            driver.FindElement(campoEmail).SendKeys(email);
            driver.FindElement(campoSenha).SendKeys(senha);
        }

        public void btnClick()
        {
            driver.FindElement(btnLogar).Click();
        }
    }
}
