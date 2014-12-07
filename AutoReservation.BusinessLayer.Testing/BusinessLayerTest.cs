using AutoReservation.Dal;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity.Core.Objects;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {
        private AutoReservationBusinessComponent target;
        private AutoReservationEntities context;
        private AutoReservationBusinessComponent Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationBusinessComponent();
                }
                return target;
            }
        }


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();

            context = new AutoReservationEntities();
        }
        
        [TestMethod]
        public void UpdateAutoTest()
        { 
            Auto autoBefore = Target.getAuto(1);
            autoBefore.Marke = "Mercedes";        
            context.SaveChanges();

            Auto autoChanged = Target.getAuto(1);
            Assert.AreEqual(autoBefore, autoChanged);
            Assert.AreEqual(autoChanged.Marke, "Mercedes");
        }

        [TestMethod]
        public void ReadAutoTest()
        {
            Assert.AreEqual("Fiat Punto", Target.getAuto(1).Marke);
            Assert.AreEqual(50, Target.getAuto(1).Tagestarif);
            Assert.AreEqual(ObjectContext.GetObjectType(Target.getAuto(1).GetType()), typeof(AutoReservation.Dal.StandardAuto));
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

    }
}
