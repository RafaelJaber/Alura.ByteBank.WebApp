﻿using OpenQA.Selenium;
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
    }
}