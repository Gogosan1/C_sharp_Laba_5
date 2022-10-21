using C_sharp_laba_5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrolSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static PayrolSystem.Worker;

namespace Tests
{
    [TestClass()]
    public class MenuTests
    {

        [TestMethod()]
        public void NameTestHourlyWageWorker()
        {
            string name = "";
            int normalWage = 120;
            int OvertimeWage = 40;
            int standardOfWorkingHours = 23;
            Assert.ThrowsException<ArgumentException>(() =>
                        new HourlyWageWorker(ref name, Worker.Gender.Male, normalWage, OvertimeWage, standardOfWorkingHours));
        }

        [TestMethod()]
        public void NormalWageTestHourlyWageWorker()
        {
            string name = "Tom";
            int normalWage = 0;
            int OvertimeWage = 320;
            int standardOfWorkingHours = 10;
            Assert.ThrowsException<ArgumentException>(() =>
                       new HourlyWageWorker(ref name, Worker.Gender.Male, normalWage, OvertimeWage, standardOfWorkingHours));
        }
        [TestMethod()]
        public void OvertimeWageTestHourlyWageWorker()
        {
            string name = "Tom";
            int normalWage = 40;
            int OvertimeWage = -450;
            int standardOfWorkingHours = 8;
            Assert.ThrowsException<ArgumentException>(() =>
                        new HourlyWageWorker(ref name, Worker.Gender.Male, normalWage, OvertimeWage, standardOfWorkingHours));
        }
        [TestMethod()]
        public void standardOfWorkingHours()
        {
            string name = "Tom";
            int normalWage = 40;
            int OvertimeWage = 450;
            int standardOfWorkingHours = 43;
            Assert.ThrowsException<ArgumentException>(() =>
                        new HourlyWageWorker(ref name, Worker.Gender.Male, normalWage, OvertimeWage, standardOfWorkingHours));
        }
    }
    public class MenuTests1
    {
        [TestMethod()]
        public void NameTestCommissionWageWorker()
        {
            string name = "";
            int salary = 40;
            int percentage = 50;
            Assert.ThrowsException<ArgumentException>(() =>
                        new CommissionWageWorker(ref name, Worker.Gender.Male, salary, percentage));
        }
        [TestMethod()]
        public void SalaryTestCommissionWageWorker()
        {
            string name = "Tod";
            int salary = -40;
            int percentage = 50;
            Assert.ThrowsException<ArgumentException>(() =>
                        new CommissionWageWorker(ref name, Worker.Gender.Male, salary, percentage));
        }
        [TestMethod()]
        public void PercentageTestCommissionWageWorker()
        {
            string name = "Tom";
            int salary = 40;
            int percentage = 150;
            Assert.ThrowsException<ArgumentException>(() =>
                        new CommissionWageWorker(ref name, Worker.Gender.Male, salary, percentage));
        }
    }
}
