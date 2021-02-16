using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using WebAPiHW_ShikhaSingh;
using WebAPiHW_ShikhaSingh.Controllers;

namespace WebApi_HW_Backend_Shikhasingh.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            StudentsController controller = new StudentsController();

            // Act
            IQueryable<Student> result = controller.GetStudents();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
        }

        [TestMethod]
        public void GetById()
        {
            StudentsController controller = new StudentsController();

            // Act
            IQueryable<Student> result = (IQueryable<Student>)controller.GetStudent(1001);

            // Assert
            Assert.AreEqual("Tarang Singh", result.Select(x => x.NAME).First());
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            StudentsController controller = new StudentsController();

            // Act
            controller.DeleteStudent(1002);

            // Assert
        }
    }
}
