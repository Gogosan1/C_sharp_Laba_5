using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_sharp_laba_5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrolSystem;

namespace C_sharp_laba_5.Tests
{
    [TestClass()]
    public class CompanyTests
    {
        
        private Company company = new Company();
        
        static string name = "Tom";
        
        [TestMethod()]
        public void GetWorkedDaysCountTest()
        {
            int expect = 0;
            int actual = company.GetWorkedDaysCount();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod()]
        public void RecruitWorkerTest()
        {
            Worker Tetser1 = new CommissionWageWorker(ref name, Worker.Gender.Male, 15, 7);
            Worker Tester2 = new CommissionWageWorker(ref name, Worker.Gender.Male, 10, 7);
            
            company.RecruitWorker(Tetser1);

            Assert.ThrowsException<ArgumentException>(() => company.RecruitWorker(Tester2));

        }

        [TestMethod()]
        public void FireWorkerTest()
        {

            Assert.ThrowsException<ArgumentException>(() => company.FireWorker(ref name));
        }

    }
}