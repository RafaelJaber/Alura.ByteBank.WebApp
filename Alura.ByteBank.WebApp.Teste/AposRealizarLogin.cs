using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.WebApp.Teste
{
    public class AposRealizarLogin
    {
        private IWebDriver _driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        [Fact]
        public void AposRealizarLoginVerificaSeExisteOpcaoAgenciaMenu()
        {
            // Arrange
            IWebDriver driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

            var login = driver.FindElement(By.Id("Email"));
            var senha = driver.FindElement(By.Id("Senha"));
            var btnLogar = driver.FindElement(By.Id("btn-logar"));

            login.SendKeys("rafael@email.com");
            senha.SendKeys("senha01");

            // Act
            btnLogar.Click();

            // Assert
            Assert.Contains("Agência", driver.PageSource);
            driver.Close();
        }

        [Fact]
        public void TentaRealizarLoginSemPreencherCampos()
        {
            // Arrange
            IWebDriver driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

            
            var btnLogar = driver.FindElement(By.Id("btn-logar"));


            // Act
            btnLogar.Click();

            // Assert
            Assert.Contains("The Email field is required.", driver.PageSource);
            Assert.Contains("The Senha field is required.", driver.PageSource);
            driver.Close();
        }

        [Fact]
        public void TentaRealizarLoginComSenhaInvalida()
        {
            // Arrange
            IWebDriver driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

            var login = driver.FindElement(By.Id("Email"));
            var senha = driver.FindElement(By.Id("Senha"));

            login.SendKeys("rafael@email.com");
            senha.SendKeys("senha02");
            var btnLogar = driver.FindElement(By.Id("btn-logar"));

            // Act
            btnLogar.Click();

            // Assert
            Assert.Contains("Login", driver.PageSource);
            driver.Close();
        }

        [Fact]
        public void RealizarLoginAcessaMenuECadastraCliente()
        {
            // Arrange
            _driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

            var login = _driver.FindElement(By.Name("Email"));
            var senha = _driver.FindElement(By.Name("Senha"));

            login.SendKeys("rafael@email.com");
            senha.SendKeys("senha01");

            _driver.FindElement(By.Id("btn-logar")).Click();

            
            _driver.FindElement(By.Id("clientes")).Click();
            _driver.FindElement(By.LinkText("Adicionar Cliente")).Click();
            _driver.FindElement(By.Id("Identificador")).Click();
            _driver.FindElement(By.Id("Identificador")).SendKeys("2df71922-ca7d-4d43-b142-0767b32f822a");
            _driver.FindElement(By.Id("CPF")).Click();
            _driver.FindElement(By.Id("CPF")).SendKeys("69981034096");
            _driver.FindElement(By.Id("Nome")).Click();
            _driver.FindElement(By.Id("Nome")).SendKeys("Fulano de Tal");
            _driver.FindElement(By.Id("Profissao")).Click();
            _driver.FindElement(By.Id("Profissao")).SendKeys("DBA");

            // Act
            _driver.FindElement(By.CssSelector(".btn-primary")).Click();
            _driver.FindElement(By.Id("home")).Click();

            // Assert
            Assert.Contains("Logout", _driver.PageSource);
            _driver.Close();
        }
    }
}
