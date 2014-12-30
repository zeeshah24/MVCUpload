using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCFileUpload;
using MVCFileUpload.Controllers;
using MVCFileUpload.Models;
using System.IO;

namespace MVCFileUpload.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void FakeUploadFiles()
        {
            HomeController controller = new HomeController();

            //ViewResult result = controller.UploadFiles() as ViewResult;
            //var uploadedResult = result.ViewData.Model as List<FileUploadResult>;
            ContentResult result = controller.UploadFiles() as ContentResult;
            var r = new List<FileUploadResult>();

            Assert.AreEqual(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "foo.doc"), result.Content.Length);
            Assert.AreEqual(8192, result.Content.Length);
        }
    }
}
