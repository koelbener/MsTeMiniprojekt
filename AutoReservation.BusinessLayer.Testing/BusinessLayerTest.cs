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
        }
        
        [TestMethod]
        public void UpdateAutoTest()
        {
            Auto auto = Target.getAuto(1);
            auto.Marke = "BMW";
            Target.updateAuto(Target.getAuto(1), auto);

            Assert.AreEqual("BMW", Target.getAuto(1).Marke);
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
            Kunde kunde = Target.getKunde(1);
            kunde.Vorname = "Foobar";
            Target.updateKunde(Target.getKunde(1), kunde);

            Assert.AreEqual("Foobar", Target.getKunde(1).Vorname);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            Reservation reservation = Target.getReservation(1);
            reservation.Bis = new DateTime(2016, 01, 01);
            Target.updateReservation(Target.getReservation(1), reservation);

            Assert.AreEqual(new DateTime(2016, 01, 01), Target.getReservation(1).Bis);
        }

    }
}
