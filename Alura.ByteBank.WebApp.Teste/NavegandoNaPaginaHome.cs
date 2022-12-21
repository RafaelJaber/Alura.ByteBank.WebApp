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
    }
}
