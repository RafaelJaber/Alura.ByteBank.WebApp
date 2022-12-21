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
    public class NavegandoNaPaginaHome
    {
        [Fact]
        public void CarregaPaginaHomeEVerificaTituloDaPagina()
        {
            // Arrange
            IWebDriver driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            // Act
            driver.Navigate().GoToUrl("https://localhost:44309");

            // Assert
            Assert.Contains("WebApp", driver.Title);
        }

        [Fact]
        public void CarregaPaginaHomeVerificaExistenciaLinkLoginEHome()
        {
            // Arrange
            IWebDriver driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            // Act
             driver.Navigate().GoToUrl("https://localhost:44309");

            //Assert
            Assert.Contains("Login", driver.PageSource);
            Assert.Contains("Home", driver.PageSource);
        }

        [Fact]
        public void Logar()
        {
            // Arrange
            IWebDriver driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            // Act
            driver.Navigate().GoToUrl("https://localhost:44309");

            //Assert
            driver.Navigate().GoToUrl("https://localhost:44309/");
            driver.Manage().Window.Size = new System.Drawing.Size(1080, 631);
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("rafael@email.com");
            driver.FindElement(By.Id("Senha")).SendKeys("senha01");
            driver.FindElement(By.Id("btn-logar")).Click();
        }

        [Fact]
        public void ValidaLinkDeLoginNaHome()
        {
            // Arrange
            IWebDriver driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost:44309");

            var linkLogin = driver.FindElement(By.LinkText("Login"));

            // Act
            linkLogin.Click();

            // Assert
            Assert.Contains("img", driver.PageSource);
            driver.Close();

        }
    }
}
