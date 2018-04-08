using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMIapp;
using BMIapp.Models;
using BMIapp.Controllers;

namespace BMIapp.Tests.Controllers
{
    [TestClass]
    public class PatientBMITest
    {
        [TestMethod]
        public void CalculateBMI_GivenPatientWeightAndHeight_returnCorrectBMInumber()
        {
            //Arrange
            double weight = 68;
            double height = 1.64;
            double expectedBMI = 25.3;

            //Act
            double result = new PatientBMI(weight, height).BMI;

            //Assert
            Assert.AreEqual(expectedBMI, result);
        }

        [TestMethod]
        public void CalculateBMIcategory_GivenPatient70kg2m_returnUnderweight()
        {
            //Arrange
            double weight = 70;
            double height = 2;
            double expectedBMI = 17.5;
            string expectedBMIcategory = "Underweight";

            //Act
            var result = new PatientBMI(weight, height);

            //Assert
            Assert.AreEqual(expectedBMI, result.BMI);
            Assert.AreEqual(expectedBMIcategory, result.Category.ToString());
        }

        [TestMethod]
        public void CalculateBMIcategory_GivenPatient80kg2m_returnNormalWeight()
        {
            //Arrange
            double weight = 80;
            double height = 2;
            double expectedBMI = 20;
            string expectedBMIcategory = BMICategory.Normal_Weight.ToString();

            //Act
            var result = new PatientBMI(weight, height);

            //Assert
            Assert.AreEqual(expectedBMI, result.BMI);
            Assert.AreEqual(expectedBMIcategory, result.Category);
        }

        [TestMethod]
        public void CalculateBMIcategory_GivenPatient100kg2m_returnPreObesity()
        {
            //Arrange
            double weight = 100;
            double height = 2;
            double expectedBMI = 25;
            string expectedBMIcategory = BMICategory.Pre_obesity.ToString();

            //Act
            var result = new PatientBMI(weight, height);

            //Assert
            Assert.AreEqual(expectedBMI, result.BMI);
            Assert.AreEqual(expectedBMIcategory, result.Category);
        }

        [TestMethod]
        public void CalculateBMIcategory_GivenPatient130kg2m_returnObesityClassI()
        {
            //Arrange
            double weight = 130;
            double height = 2;
            double expectedBMI = 32.5;
            string expectedBMIcategory = BMICategory.Obesity_class_I.ToString();

            //Act
            var result = new PatientBMI(weight, height);

            //Assert
            Assert.AreEqual(expectedBMI, result.BMI);
            Assert.AreEqual(expectedBMIcategory, result.Category);
        }

        [TestMethod]
        public void CalculateBMIcategory_GivenPatient200kg2m_returnnotCategorized()
        {
            //Arrange
            double weight = 200;
            double height = 2;
            double expectedBMI = 50;
            string expectedBMIcategory = "not categorized";

            //Act
            var result = new PatientBMI(weight, height);

            //Assert
            Assert.AreEqual(expectedBMI, result.BMI);
            Assert.AreEqual(expectedBMIcategory, result.Category);
        }
    }
}
